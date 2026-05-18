using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers
{
    /// <summary>
    /// map layers supported by this library.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<LayerType>))]
    public enum LayerType
    {
        /// <summary>
        /// Renders point objects as scalable circles.
        /// </summary>
        Bubble,

        /// <summary>
        /// Represent the density of data using different colors.
        /// </summary>
        [Display(Name = "Heat map")]
        HeatMap,

        /// <summary>
        /// Overlays an image on the map with each corner anchored to a coordinate on the map. 
        /// Also known as a ground or image overlay.
        /// </summary>
        Image,

        /// <summary>
        /// Renders line data on the map. Can be used with SimpleLine, SimplePolygon,
        /// CirclePolygon, LineString, MultiLineString, Polygon, and MultiPolygon objects.
        /// </summary>
        Line,

        /// <summary>
        /// Renders filled Polygon and MultiPolygon objects on the map.
        /// </summary>
        Polygon,

        /// <summary>
        /// Renders extruded filled `Polygon` and `MultiPolygon` objects on the map.
        /// </summary>
        [Display(Name = "Polygon Extrusion")]
        PolygonExtrusion,

        /// <summary>
        /// Renders point based data as symbols on the map using text and/or icons.
        /// Symbols can also be created for line and polygon data as well.
        /// </summary>
        Symbol,

        /// <summary>
        /// Renders raster tiled images on top of the map tiles.
        /// </summary>
        Tile,
    }

    /// <summary>
    /// Base interface that all layer objects inherit from.
    /// </summary>
    public interface ILayer : ICloneable
    {
        /// <summary>
        ///  Optionally specify a layer id to insert the new layer(s) before it.
        ///  Specify "labels" to place the new layer(s) just below the default label layer,
        ///  which will allow the labels to be visible on top of the custom layer.
        /// </summary>
        string? Before { get; set; }

        /// <summary>
        /// The unique identifier for the layer.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// <inheritdoc cref="LayerType"/>
        /// </summary>
        LayerType Type { get; }

        /// <summary>
        /// <inheritdoc cref="LayerSourceBase"/>
        /// </summary>
        LayerSourceBase LayerSource { get; }

        /// <summary>
        /// <inheritdoc cref="ILayer.GetOptions"/>
        /// </summary>
        /// <returns></returns>
        LayerOptionsBase? GetOptions();

        /// <summary>
        /// Gets the list of map event definitions.
        /// </summary>
        /// <param name="eventTypes">The events to handle. <see langword="null"/> returns all applicable events.</param>
        /// <returns></returns>
        List<MapEvent> GetMapEvents(IEnumerable<MapEventTypeLayer>? eventTypes = null);
    }

    /// <summary>
    /// Defines a layer that exposes strongly typed options for configuration.
    /// </summary>
    /// <typeparam name="TOptions">The type of options used to configure the layer.</typeparam>
    /// <typeparam name="TSource">The type of data source used by the layer.</typeparam>
    public interface ILayer<TOptions, TSource> : ILayer where TOptions : LayerOptionsBase where TSource : LayerSourceBase, new()
    {
        /// <summary>
        /// <typeparamref name="TSource"/>
        /// </summary>
        TSource DataSource { get; set; }

        /// <summary>
        /// The options for the layer.
        /// </summary>
        TOptions? Options { get; set; }
    }

    /// <summary>
    /// Base class that all layer objects inherit from.
    /// </summary>
    public abstract class LayerBase<TOptions, TSource> : JsInteropBase, ILayer<TOptions, TSource> where TOptions : LayerOptionsBase where TSource : LayerSourceBase, new()
    {
        /// <summary>
        /// <inheritdoc cref="ILayer.Type"/>
        /// </summary>
        public abstract LayerType Type { get; }

        /// <summary>
        /// <inheritdoc cref="ILayer.Before"/>
        /// </summary>
        public string? Before { get; set; }

        /// <summary>
        /// <typeparamref name="TSource"/>
        /// </summary>
        public TSource DataSource { get; set => field = value ?? throw new ArgumentNullException(nameof(DataSource)); } = new TSource();

        /// <summary>
        /// <typeparamref name="TSource"/>
        /// </summary>
        public LayerSourceBase LayerSource => DataSource;

        /// <summary>
        /// <inheritdoc cref="ILayer.GetMapEvents(IEnumerable{MapEventTypeLayer}?)"/>
        /// </summary>
        /// <param name="eventTypes"></param>
        /// <returns></returns>
        public List<MapEvent> GetMapEvents(IEnumerable<MapEventTypeLayer>? eventTypes)
        {
            eventTypes ??= Enum.GetValues<MapEventTypeLayer>();

            var results = eventTypes.Cast<MapEventType>()
                .Select(item => new MapEvent(item, MapEventTarget.layer)
                {
                    PreventDefault = true,
                    TargetId = Id,
                })
                .ToList();
            
            return results;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public abstract object Clone();

        /// <summary>
        /// <typeparamref name="TOptions"/>
        /// </summary>
        /// <returns></returns>
        public LayerOptionsBase? GetOptions() => Options;

        /// <summary>
        /// <typeparamref name="TOptions"/>
        /// </summary>
        public abstract TOptions? Options { get; set; }
    }
}

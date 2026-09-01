using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Animations;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Spatial;
using Marqdouj.DotNet.Web.JsInterop.GeoJson;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Action to perform with the read results on the datasource.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<SpatialReadAction>))]
    public enum SpatialReadAction
    {
        /// <summary>
        /// datasource.Add
        /// </summary>
        Add,

        /// <summary>
        /// datasource.setShapes
        /// </summary>
        SetShapes,
    }

    /// <summary>
    /// Interface for Azure Maps spatial source interactions.
    /// </summary>
    public interface IAzureMapsSpatialSources
    {
        /// <summary>
        /// Loads a GPS trace route.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="parameters"><see cref="LoadGPSTraceParameters"/></param>
        /// <returns></returns>
        ValueTask<LoadGPSTraceResults?> LoadGPSTrace(string mapId, LoadGPSTraceParameters parameters);

        /// <summary>
        /// Read an XML file from a URL or pass in a raw XML string.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="parameters"></param>
        /// <returns><see cref="BoundingBox"/> if one was available for the data.</returns>
        ValueTask<SpatialReadResults?> Read(string mapId, SpatialReadParameters parameters);
    }

    internal class AzSpatialSources(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsSpatialSources
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask<LoadGPSTraceResults?> LoadGPSTrace(string mapId, LoadGPSTraceParameters parameters)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<LoadGPSTraceResults?>(GetJsInteropMethod(), mapId, parameters);
        }

        public async ValueTask<SpatialReadResults?> Read(string mapId, SpatialReadParameters parameters)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<SpatialReadResults?>(GetJsInteropMethod(), mapId, parameters);
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.SpatialSources.GetJsModuleMethod(name);
    }

    /// <summary>
    /// Parameters for Spatial.Read method.
    /// </summary>
    /// <param name="dataSourceId"></param>
    /// <param name="url"><see cref="Url"/></param>
    /// <param name="action"><see cref="Action"/></param>
    /// <param name="options"><see cref="Options"/></param>
    /// <param name="padding"><see cref="Padding"/></param>
    public class SpatialReadParameters(string dataSourceId, string url, SpatialReadAction action, SpatialDataReadOptions? options = null, double padding = 50)
    {
        /// <summary>
        /// DataSource to assign the read data to.
        /// </summary>
        public string DataSourceId { get; } = dataSourceId;

        /// <summary>
        /// A spatial data string or a URL to a file or zipped file and parses the spatial data into GeoJSON objects.
        /// Supported spatial data formats: KML, KMZ, GPX, GeoRSS, GML, spatial delimited files (CSV), GeoJSON.
        /// </summary>
        public string Url { get; } = url;

        /// <summary>
        /// <inheritdoc cref="SpatialReadAction"/>
        /// </summary>
        public SpatialReadAction Action { get; } = action;

        /// <summary>
        /// <inheritdoc cref="SpatialDataReadOptions"/>
        /// </summary>
        public SpatialDataReadOptions? Options { get; } = options;

        /// <summary>
        /// If the bounding box information is known for the data, the map view will be updated to fit it, with the padding.
        /// </summary>
        public double Padding { get; } = padding;

        /// <summary>
        /// <see cref="IAzureMapsAnimations.ExtractRoutePoints(string, string, int, string?)"/> length.
        /// </summary>
        public int RouteLength { get; set; }

        /// <summary>
        /// <see cref="IAzureMapsAnimations.ExtractRoutePoints(string, string, int, string?)"/> timestampProperty.
        /// </summary>
        public string? RouteTimestamp { get; set; }
    }

    /// <summary>
    /// Results from a Spatial read operation.
    /// </summary>
    public class SpatialReadResults
    {
        /// <summary>
        /// <inheritdoc cref="BoundingBox"/>
        /// </summary>
        [JsonInclude]
        public BoundingBox? Bbox { get; internal set; }

        /// <summary>
        /// Point features for the time based route.
        /// </summary>
        [JsonInclude]
        public List<Feature<Point, GeoJsonProperties?>>? Route { get; internal set; }

        /// <summary>
        /// Flag to indicate the read was a success.
        /// </summary>
        [JsonInclude]
        public bool Success { get; internal set; }
    }

    /// <summary>
    /// Parameters for loading a GPS trace route.
    /// </summary>
    /// <param name="animationId"><see cref="LoadGPSTraceParameters.AnimationId"/></param>
    /// <param name="routeSourceId"><see cref="LoadGPSTraceParameters.RouteSourceId"/></param>
    /// <param name="shapeSourceId"><see cref="LoadGPSTraceParameters.ShapeSourceId"/></param>
    /// <param name="url"><see cref="LoadGPSTraceParameters.Url"/></param>
    /// <param name="timestampProperty"><see cref="LoadGPSTraceParameters.TimestampProperty"/></param>
    /// <param name="readOptions"><see cref="LoadGPSTraceParameters.ReadOptions"/></param>
    /// <param name="pathOptions"><see cref="LoadGPSTraceParameters.PathOptions"/></param>
    /// <param name="events"><see cref="LoadGPSTraceParameters.Events"/></param>
    /// <param name="follow"><see cref="LoadGPSTraceParameters.Follow"/></param>
    /// <param name="padding"><see cref="LoadGPSTraceParameters.Padding"/></param>
    public class LoadGPSTraceParameters(
        string animationId,
        string routeSourceId,
        string shapeSourceId,
        string url,
        string? timestampProperty,
        SpatialDataReadOptions? readOptions,
        RoutePathAnimationOptions? pathOptions,
        List<MapEvent>? events,
        bool follow = true,
        int padding = 50)
    {
        /// <summary>
        /// Id used to work with the animation created.
        /// </summary>
        public string AnimationId { get; } = animationId;

        /// <summary>
        /// Id for the DataSource that contains the route data.
        /// </summary>
        public string RouteSourceId { get; } = routeSourceId;

        /// <summary>
        /// Id for the DataSource that contains the pin shape.
        /// </summary>
        public string ShapeSourceId { get; } = shapeSourceId;

        /// <summary>
        /// A spatial data string or a URL to a file or zipped file and parses the spatial data into GeoJSON objects.
        /// Supported spatial data formats: KML, KMZ, GPX, GeoRSS, GML, spatial delimited files (CSV), GeoJSON.
        /// </summary>
        public string Url { get; } = url;

        /// <summary>
        /// The route features property name that contains timestamp information.  If not specified, `_timestamp` will be used.
        /// </summary>
        public string? TimestampProperty { get; } = timestampProperty;

        /// <summary>
        /// <inheritdoc cref="SpatialDataReadOptions"/>
        /// </summary>
        public SpatialDataReadOptions? ReadOptions { get; } = readOptions;

        /// <summary>
        /// <inheritdoc cref="RoutePathAnimationOptions"/>
        /// </summary>
        public RoutePathAnimationOptions? PathOptions { get; } = pathOptions;

        /// <summary>
        /// Events for the animation.
        /// </summary>
        public List<MapEvent>? Events { get; } = events;

        /// <summary>
        /// Assign the map to the animation. Default is 'true'.
        /// </summary>
        public bool Follow { get; } = follow;

        /// <summary>
        /// If the bounding box information is known for the route data, the map view will be updated to fit it, with the padding.
        /// </summary>
        public int Padding { get; } = padding;
    }

    /// <summary>
    /// Results for loading a GPS trace route.
    /// </summary>
    public class LoadGPSTraceResults : SpatialReadResults
    {
        /// <summary>
        /// The shape id for the 'pin' shape added to the map.
        /// </summary>
        public string? ShapeId { get; set; }
    }
}

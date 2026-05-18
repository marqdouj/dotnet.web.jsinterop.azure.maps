using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers;

namespace Sandbox.Components.Pages.AzureMaps.Common
{
    /// <summary>
    /// Provides access to view models for all supported map layer types.
    /// </summary>
    /// <remarks>Use this class to retrieve strongly-typed view models for configuring and interacting with
    /// different types of map layers, such as bubble, heat map, image, line, polygon, polygon extrusion, symbol, and
    /// tile layers. Each property exposes a view model tailored to the corresponding layer type, enabling type-safe
    /// configuration and manipulation within mapping applications.</remarks>
    public class MapLayerViewModels() : ICloneable
    {
        /// <summary>
        /// Gets the view model for the bubble map layer.
        /// </summary>  
        public MapLayerViewModel<BubbleLayerOptions, DataSource> Bubble { get; set => field = value ?? throw new ArgumentNullException(nameof(Bubble)); } = new(new BubbleLayer());
        /// <summary>
        /// Gets the view model for the heat map layer.
        /// </summary>
        public MapLayerViewModel<HeatMapLayerOptions, DataSource> HeatMap { get; set => field = value ?? throw new ArgumentNullException(nameof(HeatMap)); } = new(new HeatMapLayer());
        /// <summary>
        /// Gets the view model for the image map layer.
        /// </summary>
        public MapLayerViewModel<ImageLayerOptions, DataSource> Image { get; set => field = value ?? throw new ArgumentNullException(nameof(Image)); } = new(new ImageLayer());
        /// <summary>
        /// Gets the view model for the line map layer.
        /// </summary>
        public MapLayerViewModel<LineLayerOptions, DataSource> Line { get; set => field = value ?? throw new ArgumentNullException(nameof(Line)); } = new(new LineLayer());
        /// <summary>
        /// Gets the view model for the polygon map layer.
        /// </summary>
        public MapLayerViewModel<PolygonLayerOptions, DataSource> Polygon { get; set => field = value ?? throw new ArgumentNullException(nameof(Polygon)); } = new(new PolygonLayer());
        /// <summary>
        /// Gets the view model for the polygon extrusion map layer.
        /// </summary>
        public MapLayerViewModel<PolygonExtrusionLayerOptions, DataSource> PolygonExtrusion { get; set => field = value ?? throw new ArgumentNullException(nameof(PolygonExtrusion)); } = new(new PolygonExtrusionLayer());
        /// <summary>
        /// Gets the view model for the symbol map layer.
        /// </summary>
        public MapLayerViewModel<SymbolLayerOptions, DataSource> Symbol { get; set => field = value ?? throw new ArgumentNullException(nameof(Symbol)); } = new(new SymbolLayer());
        /// <summary>
        /// Gets the view model for the tile map layer.
        /// </summary>
        public MapLayerViewModel<TileLayerOptions, DataSource> Tile { get; set => field = value ?? throw new ArgumentNullException(nameof(Tile)); } = new(new TileLayer());

        /// <summary>
        /// Gets a list of all map layer view models contained in this class.
        /// </summary>
        /// <returns></returns>
        public List<IMapLayerViewModel> GetModels()
        {
            return [.. GetType().GetProperties()
                .Select(p => p.GetValue(this))
                .OfType<IMapLayerViewModel>()];
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object Clone()
        {
            var clone = new MapLayerViewModels();

            foreach (var p in GetType().GetProperties())
            {
                if (p.GetValue(this) is IMapLayerViewModel model)
                {
                    if (model.Clone() is IMapLayerViewModel clonedModel)
                    {
                        p.SetValue(clone, clonedModel);
                    }
                }
            }

            return clone;
        }
    }
}

using Marqdouj.DotNet.General.CsDoc;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers;

namespace Sandbox.UI.Models
{
    /// <summary>
    /// Interface for a view model that represents a map layer.
    /// </summary>
    public interface IMapLayerViewModel : ICloneable
    {
        /// <summary>
        /// Gets the underlying source layer for this object.
        /// </summary>
        /// <remarks>Use this property to access the original layer that provides the data or features
        /// represented by this object. The returned layer may be used for further queries or operations, depending on
        /// the implementation.</remarks>
        ILayer Source { get; }

        /// <summary>
        /// The camera options for viewing the layer.
        /// </summary>
        CameraOptions? Camera { get; set; }

        /// <summary>
        /// Flag to indicate the view model is the active row.
        /// </summary>
        bool IsActiveRow { get; set; }

        /// <summary>
        /// Flag to indicate the view model is loaded into the map.
        /// </summary>
        bool IsLoaded { get; set; }

        /// <summary>
        /// Indicates whether the layer should be visible on the map.
        /// </summary>
        bool IsVisible { get; set; }

        /// <summary>
        /// Name to display for the layer.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets an alternate name or alias associated with the entity.
        /// </summary>
        string? NameAlias { get; set; }

        /// <summary>
        /// The map event definitions associated with the layer.
        /// </summary>
        List<MapEvent> Events { get; }

        /// <summary>
        /// Creates a LayerGroup object based on the current state of the view model, including the source layer and its associated events.
        /// </summary>
        /// <returns>A LayerGroup object representing the current state of the view model.</returns>
        LayerGroup ToLayerGroup();
    }

    /// <summary>
    /// ViewModel for working with a layer.
    /// </summary>
    /// <param name="layer"></param>
    /// <param name="camera">Camera options for viewing the layer.</param>
    /// <param name="selected">Indicates whether the layer is selected.</param>
    public class MapLayerViewModel<TOptions, TSource>(ILayer<TOptions, TSource> layer) : IMapLayerViewModel where TOptions : LayerOptionsBase where TSource : LayerSourceBase, new()
    {
        /// <summary>
        /// Gets the underlying layer for this view model.
        /// </summary>
        public ILayer<TOptions, TSource> Layer { get; private set; } = layer;

        /// <summary>
        /// <inheritdoc cref="IMapLayerViewModel.Source"/>
        /// </summary>
        public ILayer Source => Layer;

        /// <summary>
        /// Camera used to view the layer.
        /// </summary>
        public CameraOptions? Camera { get; set; }
        
        /// <summary>
        /// <inheritdoc cref="IMapLayerViewModel.IsActiveRow"/>
        /// </summary>
        public bool IsActiveRow { get; set; }

        /// <summary>
        /// <inheritdoc cref="IMapLayerViewModel.IsLoaded"/>
        /// </summary>
        public bool IsLoaded { get; set; }

        /// <summary>
        /// <inheritdoc cref="IMapLayerViewModel.IsVisible"/>
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// <inheritdoc cref="IMapLayerViewModel.Name"/>
        /// </summary>
        public string Name => string.IsNullOrEmpty(NameAlias) ? Layer.Type.GetDisplayName()! : NameAlias;

        /// <summary>
        /// <inheritdoc cref="IMapLayerViewModel.NameAlias"/>
        /// </summary>
        public string? NameAlias { get; set; } = layer.Type.GetDisplayName(false);

        /// <summary>
        /// <inheritdoc cref="IMapLayerViewModel.Events"/>
        /// </summary>
        public List<MapEvent> Events { get; } = layer.GetMapEvents(null);

        /// <summary>
        /// <inheritdoc cref="IMapLayerViewModel.ToLayerGroup"/>
        /// </summary>
        public LayerGroup ToLayerGroup() => new(Source, Events);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <remarks>Creates a shallow copy of the current object. 
        /// The underlying layer reference is shared between the original and the clone, so changes to the layer will affect both instances. 
        /// Use this method when you want to create a new view model with the same layer but potentially different state (e.g., visibility, camera options) 
        /// without duplicating the layer itself.</remarks>
        /// <returns>A shallow copy of the current view model</returns>
        /// <exception cref="NotImplementedException"></exception>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

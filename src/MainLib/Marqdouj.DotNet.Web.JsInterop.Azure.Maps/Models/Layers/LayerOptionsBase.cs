namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers
{
    /// <summary>
    /// A base class which all other layer options inherit from.
    /// </summary>
    public abstract class LayerOptionsBase: ICloneable
    {
        /// <summary>
        /// An expression specifying conditions on source features.
        /// Only features that match the filter are displayed.
        /// </summary>
        public object? Filter { get; set; }

        /// <summary>
        /// An integer specifying the minimum zoom level to render the layer at.
        /// This value is inclusive, i.e. the layer will be visible at 'maxZoom > zoom >= minZoom'.
        /// Default '0'.
        /// </summary>
        public double? MinZoom { get; set; }

        /// <summary>
        /// An integer specifying the maximum zoom level to render the layer at.
        /// This value is exclusive, i.e. the layer will be visible at 'maxZoom > zoom >= minZoom'.
        /// Default '24'.
        /// </summary>
        public double? MaxZoom { get; set; }

        /// <summary>
        /// Specifies if the layer is visible or not.
        /// Default 'true'.
        /// </summary>
        public bool? Visible { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public abstract object Clone();
    }

    /// <summary>
    /// Base class for layer options that support 'source' and 'sourceLayer'.
    /// </summary>
    public abstract class SourceLayerOptions : LayerOptionsBase
    {
        /// <summary>
        /// The id of a data source which the layer will render.
        /// </summary>
        public string? Source { get; set; }

        /// <summary>
        /// Required when the source of the layer is a VectorTileSource.
        /// A vector source can have multiple layers within it, this identifies which one to render in this layer.
        /// Prohibited for all other types of sources.
        /// </summary>
        public string? SourceLayer { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public abstract override object Clone();
    }

    /// <summary>
    /// Base class for layer options that support 'media' options.
    /// </summary>
    public abstract class MediaLayerOptions : LayerOptionsBase
    {
        /// <summary>
        /// A number between -1 and 1 that increases or decreases the contrast of the overlay.
        /// Default 0.
        /// </summary>
        public double? Contrast { get; set; }

        /// <summary>
        /// The duration in milliseconds of a fade transition when a new tile is added.
        /// Must be greater or equal to 0.
        /// Default 300.
        /// </summary>
        public int? FadeDuration { get; set; }

        /// <summary>
        /// Rotates hues around the color wheel.
        /// A number in degrees.
        /// Default 0.
        /// </summary>
        public double? HueRotation { get; set; }

        /// <summary>
        /// A number between 0 and 1 that increases or decreases the maximum brightness of the overlay.
        /// Default 1.
        /// </summary>
        public double? MaxBrightness { get; set; }

        /// <summary>
        /// A number between 0 and 1 that increases or decreases the minimum brightness of the overlay.
        /// Default 0.
        /// </summary>
        public double? MinBrightness { get; set; }

        /// <summary>
        /// A number between 0 and 1 that indicates the opacity at which the overlay will be drawn.
        /// Default 1.
        /// </summary>
        public double? Opacity { get; set; }

        /// <summary>
        /// A number between -1 and 1 that increases or decreases the saturation of the overlay.
        /// Default 0.
        /// </summary>
        public double? Saturation { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public abstract override object Clone();
    }
}

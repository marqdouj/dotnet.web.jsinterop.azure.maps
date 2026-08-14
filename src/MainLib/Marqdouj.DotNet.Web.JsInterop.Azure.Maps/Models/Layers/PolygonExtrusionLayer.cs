using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Sources;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers
{
    /// <summary>
    /// <inheritdoc cref="LayerType.PolygonExtrusion"/>
    /// </summary>
    public class PolygonExtrusionLayer : LayerBase<PolygonExtrusionLayerOptions>
    {
        /// <summary>
        /// <inheritdoc cref="LayerType"/>
        /// </summary>
        public override LayerType Type => LayerType.PolygonExtrusion;

        /// <summary>
        /// <inheritdoc cref="PolygonExtrusionLayerOptions"/>
        /// </summary>
        public override PolygonExtrusionLayerOptions? Options { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var clone = (PolygonExtrusionLayer)MemberwiseClone();
            clone.Options = (PolygonExtrusionLayerOptions?)Options?.Clone();
            return clone;
        }
    }

    /// <summary>
    /// Options used when rendering `Polygon` and `MultiPolygon` objects in a `PolygonExtrusionLayer`.
    /// </summary>
    public class PolygonExtrusionLayerOptions : SourceLayerOptions
    {
        /// <summary>
        /// The height in meters to extrude the base of this layer.
        /// This height is relative to the ground.
        /// Must be greater or equal to 0 and less than or equal to 'height'.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '0'.
        /// </summary>
        public object? Base { get; set; }

        /// <summary>
        /// The color to fill the polygons with.
        /// Ignored if 'fillPattern' is set.
        /// String or DataDrivenPropertyValueSpecification.
        /// Default '#1E90FF'.
        /// </summary>
        public object? FillColor { get; set; }

        /// <summary>
        /// The height in meters to extrude this layer.
        /// This height is relative to the ground.
        /// Must be a number greater or equal to 0.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '0'.
        /// </summary>
        public object? Height { get; set; }

        /// <summary>
        /// A number between 0 and 1 that indicates the opacity at which the fill will be drawn.
        /// Default '1'.
        /// </summary>
        public double? FillOpacity { get; set; }

        /// <summary>
        /// Name of image in sprite to use for drawing image fills.
        /// For seamless patterns, image width must be a factor of two (2, 4, 8, ..., 512).
        /// String or DataDrivenPropertyValueSpecification.
        /// </summary>
        public object? FillPattern { get; set; }

        /// <summary>
        /// The amount of offset in pixels to render the line relative to where it would render normally.
        /// Negative values indicate left and up.
        /// Default '[0,0]'.
        /// </summary>
        public Pixel? Translate { get; set; }

        /// <summary>
        /// Specifies the frame of reference for 'translate'.
        /// "map": Lines are translated relative to the map.
        /// "viewport": Lines are translated relative to the viewport
        /// Default 'map'.
        /// </summary>
        public TranslateAnchor? TranslateAnchor { get; set; }

        /// <summary>
        /// Specifies if the polygon should have a vertical gradient on the sides of the extrusion.
        /// Default 'true'.
        /// </summary>
        public bool? VerticalGradient { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var clone = (PolygonExtrusionLayerOptions)MemberwiseClone();
            clone.Translate = (Pixel?)Translate?.Clone();

            return clone;
        }
    }
}

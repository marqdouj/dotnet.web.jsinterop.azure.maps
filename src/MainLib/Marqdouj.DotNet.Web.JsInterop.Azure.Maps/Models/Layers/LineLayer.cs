using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers
{
    /// <summary>
    /// <inheritdoc cref="LayerType.Line"/>
    /// </summary>
    public class LineLayer : LayerBase<LineLayerOptions>
    {
        /// <summary>
        /// <inheritdoc cref="LayerType"/>
        /// </summary>
        public override LayerType Type => LayerType.Line;

        /// <summary>
        /// <inheritdoc cref="LineLayerOptions"/>
        /// </summary>
        public override LineLayerOptions? Options { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var clone = (LineLayer)MemberwiseClone();
            clone.Options = (LineLayerOptions?)Options?.Clone();
            return clone;
        }
    }

    /// <summary>
    /// Specifies how the ends of the lines are rendered.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<LineCap>))]
    public enum LineCap
    {
        /// <summary>
        /// A cap with a squared-off end which is drawn to the exact endpoint of the line.
        /// </summary>
        [Display(Name = "Butt")]
        butt,

        /// <summary>
        /// A cap with a rounded end which is drawn beyond the endpoint of the line
        /// at a radius of one-half of the lines width and centered on the endpoint of the line.
        /// </summary>
        [Display(Name = "Round")]
        round,

        /// <summary>
        /// A cap with a squared-off end which is drawn beyond the endpoint of the line
        /// at a distance of one-half of the line width.
        /// </summary>
        [Display(Name = "Square")]
        square,
    }

    /// <summary>
    /// Specifies how the joints in the lines are rendered.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<LineJoin>))]
    public enum LineJoin
    {
        /// <summary>
        /// A join with a squared-off end which is drawn beyond the endpoint of the line
        /// at a distance of one-half of the lines width.
        /// </summary>
        [Display(Name = "Bevel")]
        bevel,

        /// <summary>
        /// A join with a rounded end which is drawn beyond the endpoint of the line
        /// at a radius of one-half of the lines width and centered on the endpoint of the line.
        /// </summary>
        [Display(Name = "Round")]
        round,

        /// <summary>
        /// A join with a sharp, angled corner which is drawn with the outer sides
        /// beyond the endpoint of the path until they meet.
        /// </summary>
        [Display(Name = "Miter")]
        miter,
    }

    /// <summary>
    /// Options used when rendering SimpleLine, SimplePolygon, CirclePolygon,
    /// LineString, MultiLineString, Polygon, and MultiPolygon objects in a line layer.
    /// </summary>
    public class LineLayerOptions : SourceLayerOptions
    {
        /// <summary>
        /// The amount of blur to apply to the line in pixels.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '0'.
        /// </summary>
        public object? Blur { get; set; }

        /// <summary>
        /// Specifies how the ends of the lines are rendered.
        /// "butt": A cap with a squared-off end which is drawn to the exact endpoint of the line.
        /// "round": A cap with a rounded end which is drawn beyond the endpoint of the line
        /// at a radius of one-half of the lines width and centered on the endpoint of the line.
        /// "square": A cap with a squared-off end which is drawn beyond the endpoint of the line
        /// at a distance of one-half of the line width.
        /// Default 'round'.
        /// </summary>
        public LineCap? LineCap { get; set; }

        /// <summary>
        /// Specifies how the joints in the lines are rendered.
        /// "bevel": A join with a squared-off end which is drawn beyond the endpoint of the line
        /// at a distance of one-half of the lines width.
        /// "round": A join with a rounded end which is drawn beyond the endpoint of the line
        /// at a radius of one-half of the lines width and centered on the endpoint of the line.
        /// "miter": A join with a sharp, angled corner which is drawn with the outer sides
        /// beyond the endpoint of the path until they meet.
        /// Default 'round'.
        /// </summary>
        public LineJoin? LineJoin { get; set; }

        /// <summary>
        /// Specifies the color of the line.
        /// String or DataDrivenPropertyValueSpecification.
        /// Default '#1E90FF'.
        /// </summary>
        public object? StrokeColor { get; set; }

        /// <summary>
        /// Specifies the lengths of the alternating dashes and gaps that form the dash pattern.
        /// Numbers must be equal or greater than 0. The lengths are scaled by the strokeWidth.
        /// To convert a dash length to pixels, multiply the length by the current stroke width.
        /// </summary>
        public List<double>? StrokeDashArray { get; set; }

        /// <summary>
        /// Defines a gradient with which to color the lines.
        /// Requires the datasource lineMetrics option to be set to true.
        /// Disabled if strokeDashArray is set.
        /// </summary>
        public string? StrokeGradient { get; set; }

        /// <summary>
        /// The line's offset.
        /// A positive value offsets the line to the right, relative to the direction of the line.
        /// A negative value offsets to the left.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '0'.
        /// </summary>
        public object? Offset { get; set; }

        /// <summary>
        /// A number between 0 and 1 that indicates the opacity at which the line will be drawn.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '1'.
        /// </summary>
        public object? StrokeOpacity { get; set; }

        /// <summary>
        /// The amount of offset in pixels to render the line relative to where it would render normally.
        /// Negative values indicate left and up.
        /// Default: '[0,0]'
        /// </summary>
        public Pixel? Translate { get; set; }

        /// <summary>
        /// Specifies the frame of reference for 'translate'.
        /// "map": Lines are translated relative to the map.
        /// "viewport": Lines are translated relative to the viewport
        /// Default: 'map'
        /// </summary>
        public TranslateAnchor? TranslateAnchor { get; set; }

        /// <summary>
        /// The width of the line in pixels. Must be a value greater or equal to 0.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '2'.
        /// </summary>
        public object? StrokeWidth { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var clone = (LineLayerOptions)MemberwiseClone();
            clone.StrokeDashArray = StrokeDashArray?.ToList();
            clone.Translate = (Pixel?)Translate?.Clone();

            return clone;
        }
    }
}

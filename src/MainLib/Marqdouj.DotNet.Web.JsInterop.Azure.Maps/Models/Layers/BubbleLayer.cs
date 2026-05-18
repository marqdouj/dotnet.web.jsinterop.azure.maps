using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers
{
    /// <summary>
    /// <inheritdoc cref="LayerType.Bubble"/>
    /// </summary>
    public class BubbleLayer : LayerBase<BubbleLayerOptions, DataSource>
    {
        /// <summary>
        /// <inheritdoc cref="LayerType"/>
        /// </summary>
        public override LayerType Type => LayerType.Bubble;

        /// <summary>
        /// <inheritdoc cref="BubbleLayerOptions"/>
        /// </summary>
        public override BubbleLayerOptions? Options { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var clone = (BubbleLayer)MemberwiseClone();
            clone.Options = (BubbleLayerOptions?)Options?.Clone();
            return clone;
        }
    }

    /// <summary>
    /// Specifies the orientation of circle when map is pitched.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<BubbleLayerPitchAlignment>))]
    public enum BubbleLayerPitchAlignment
    {
        /// <summary>
        /// The circle is aligned to the plane of the map.
        /// </summary>
        [Display(Name = "map")]
        map,

        /// <summary>
        /// The circle is aligned to the plane of the viewport.
        /// </summary>
        [Display(Name = "viewport")]
        viewport,
    }

    /// <summary>
    /// Options used when rendering point objects in a BubbleLayer.
    /// </summary>
    public class BubbleLayerOptions : SourceLayerOptions
    {
        /// <summary>
        /// The color to fill the circle symbol with.
        /// Default "#1A73AA" (dark Blue).
        /// </summary>
        public string? Color { get; set; }

        /// <summary>
        /// The amount to blur the circles.
        /// A value of 1 blurs the circles such that only the center point is at full opacity.
        /// Default '0'.
        /// </summary>
        public double? Blur { get; set; }

        /// <summary>
        /// A number between 0 and 1 that indicates the opacity at which the circles will be drawn.
        /// Default '1'.
        /// </summary>
        public double? Opacity { get; set; }

        /// <summary>
        /// The color of the circles' outlines.
        /// Default '#FFFFFF'.
        /// </summary>
        public string? StrokeColor { get; set; }

        /// <summary>
        /// A number between 0 and 1 that indicates the opacity at which the circles' outlines will be drawn.
        /// Default '1'.
        /// </summary>
        public double? StrokeOpacity { get; set; }

        /// <summary>
        /// The width of the circles' outlines in pixels.
        /// Default '2'.
        /// </summary>
        public double? StrokeWidth { get; set; }

        /// <summary>
        /// Specifies the orientation of circle when map is pitched.
        /// "map": The circle is aligned to the plane of the map.
        /// "viewport": The circle is aligned to the plane of the viewport.
        /// Default 'viewport'
        /// </summary>
        public BubbleLayerPitchAlignment? PitchAlignment { get; set; }

        /// <summary>
        /// The radius of the circle symbols in pixels.
        /// Must be greater than or equal to 0.
        /// Default '8'.
        /// </summary>
        public double? Radius { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return MemberwiseClone();
        }
    }
}

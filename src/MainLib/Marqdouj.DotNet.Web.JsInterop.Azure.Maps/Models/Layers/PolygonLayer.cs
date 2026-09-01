namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers
{
    /// <summary>
    /// <inheritdoc cref="LayerType.Polygon"/>
    /// </summary>
    public class PolygonLayer : LayerBase<PolygonLayerOptions>
    {
        /// <summary>
        /// <inheritdoc cref="LayerType"/>
        /// </summary>
        public override LayerType Type => LayerType.Polygon;

        /// <summary>
        /// <inheritdoc cref="PolygonLayerOptions"/>
        /// </summary>
        public override PolygonLayerOptions? Options { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var clone = (PolygonLayer)MemberwiseClone();
            clone.Options = (PolygonLayerOptions?)Options?.Clone();
            return clone;
        }
    }

    /// <summary>
    /// Options used when rendering Polygon and MultiPolygon objects in a PolygonLayer.
    /// </summary>
    public class PolygonLayerOptions : SourceLayerOptions
    {
        /// <summary>
        /// The color to fill the polygons with.
        /// String or DataDrivenPropertyValueSpecification.
        /// Default '#1E90FF'.
        /// </summary>
        public object? FillColor { get; set; }

        /// <summary>
        /// A number between 0 and 1 that indicates the opacity at which the fill will be drawn.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '0.5'.
        /// </summary>
        public object? FillOpacity { get; set; }

        /// <summary>
        /// Name of image in sprite to use for drawing image fills.
        /// For seamless patterns, image width must be a factor of two (2, 4, 8, ..., 512).
        /// String or DataDrivenPropertyValueSpecification.
        /// </summary>
        public object? FillPattern { get; set; }

        /// <summary>
        /// Whether or not the fill should be antialiased.
        /// Default 'true'.
        /// </summary>
        public bool? FillAntialias { get; set; }

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

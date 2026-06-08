namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers
{
    /// <summary>
    /// <inheritdoc cref="LayerType.HeatMap"/>
    /// </summary>
    public class HeatMapLayer : LayerBase<HeatMapLayerOptions, DataSource>
    {
        /// <summary>
        /// <inheritdoc cref="LayerType"/>
        /// </summary>
        public override LayerType Type => LayerType.HeatMap;

        /// <summary>
        /// <inheritdoc cref="HeatMapLayerOptions"/>
        /// </summary>
        public override HeatMapLayerOptions? Options { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var clone = (HeatMapLayer)MemberwiseClone();
            clone.Options = (HeatMapLayerOptions?)Options?.Clone();
            return clone;
        }
    }

    /// <summary>
    /// Options used when rendering point objects in a HeatMapLayer.
    /// </summary>
    public class HeatMapLayerOptions : SourceLayerOptions
    {
        /// <summary>
        /// JSON array that specifies the color gradient used to colorize the pixels in the heatmap.
        /// This is defined using an expression that uses ["heatmap-density"] as input.
        /// Default ["interpolate",["linear"],["heatmap-density"],0,"rgba(0,0, 255,0)",0.1,"royalblue",0.3,"cyan",0.5,"lime",0.7,"yellow",1,"red"]
        /// </summary>
        public object? Color { get; set; }

        /// <summary>
        /// Similar to heatmap-weight but specifies the global heatmap intensity.
        /// The higher this value is, the more ‘weight’ each point will contribute to the appearance.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '1'.
        /// </summary>
        public object? Intensity { get; set; }

        /// <summary>
        /// The opacity at which the heatmap layer will be rendered defined as a number between 0 and 1.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '1'.
        /// </summary>
        public object? Opacity { get; set; }

        /// <summary>
        /// The radius in pixels used to render a data point on the heatmap.
        /// The radius must be a number greater or equal to 1.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '30'.
        /// </summary>
        public object? Radius { get; set; }

        /// <summary>
        /// Specifies how much an individual data point contributes to the heatmap.
        /// Must be a number greater than 0. A value of 5 would be equivalent to having 5 points of weight 1 in the same spot.
        /// This is useful when clustering points to allow heatmap rendering or large datasets.
        /// Number or DataDrivenPropertyValueSpecification.
        /// Default '1'.
        /// </summary>
        public object? Weight { get; set; }

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

using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Spatial
{
    /// <summary>
    /// Options for the simple data layer.
    /// </summary>
    public class SimpleDataLayerOptions : ICloneable
    {
        /// <summary>
        /// If a point feature has a `title` or `name` property,
        /// this option specifies if it should be displayed on the map under the marker.
        /// Default: `false`
        /// </summary>
        public bool? ShowPointTitles { get; set; }

        /// <summary>
        /// Specifies if popups should appear when shapes are clicked.
        /// Default: `true`
        /// </summary>
        public bool? EnablePopups { get; set; }

        /// <summary>
        /// Specifies if polygons that have a `height` property should be rendered as extruded polygons.
        /// Default: `true`
        /// </summary>
        public bool? AllowExtrusions { get; set; }

        /// <summary>
        /// A boolean indicating if the layer is visible or not.
        /// Default: `true`
        /// </summary>
        public bool? Visible { get; set; }

        /// <summary>
        /// A popup template that will be used if a shape doesn't have a PopupTemplate property itself.
        /// </summary>
        public PopupTemplate? PopupTemplate { get; set; }

        /// <summary>
        /// A numerical factor used to adjust the size of map bubbles dynamically.
        /// It multiplies the original bubble size to determine the final size.
        /// Default: `8`
        /// </summary>
        public double? BubbleRadiusFactor { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public object Clone()
        {
            var clone = (SimpleDataLayerOptions)MemberwiseClone();
            clone.PopupTemplate = PopupTemplate?.Clone() as PopupTemplate;
            return clone;
        }
    }
}

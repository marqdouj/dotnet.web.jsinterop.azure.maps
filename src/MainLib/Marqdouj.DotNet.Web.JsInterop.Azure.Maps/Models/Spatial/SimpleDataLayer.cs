using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Sources;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Spatial
{
    /// <summary>
    /// A layer that simplifies the rendering of geospatial data on the map.
    /// **Note:** Because this layer wraps other layers which will be added/removed with this
    /// some layer ordering operations are not supported.
    /// Adding this layer before another, adding another layer before this, and moving this layer are not supported.
    /// These restrictions only apply to this layer and not the layers wrapped by this.
    /// </summary>
    public class SimpleDataLayer : JsInteropBase, ICloneable
    {
        /// <summary>
        /// <inheritdoc cref="SimpleDataLayerOptions"/>
        /// </summary>
        public SimpleDataLayerOptions? Options { get; set; }

        /// <summary>
        /// <inheritdoc cref="DataSource"/>
        /// </summary>
        public DataSource Source { get; set => field = value ?? throw new ArgumentNullException(nameof(Source)); } = new DataSource();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public object Clone()
        {
            var clone = (SimpleDataLayer)MemberwiseClone();
            clone.Source = (DataSource)Source.Clone();
            clone.Options = Options?.Clone() as SimpleDataLayerOptions;
            return clone;
        }
    }
}

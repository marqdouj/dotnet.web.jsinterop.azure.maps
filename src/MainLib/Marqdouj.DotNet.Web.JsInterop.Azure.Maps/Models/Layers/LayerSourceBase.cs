using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers
{
    /// <summary>
    /// The map source type used for a layer.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<LayerSourceType>))]
    public enum LayerSourceType
    {
        /// <summary>
        /// 
        /// </summary>
        DataSource,
        //ElevationTile,
        //VectorTile,
    }

    /// <summary>
    /// Base class for all map layer sources
    /// </summary>
    public abstract class LayerSourceBase : JsInteropBase, ICloneable
    {
        internal LayerSourceBase() { }

        /// <summary>
        /// <see cref="LayerSourceType"/>
        /// </summary>
        public abstract LayerSourceType? Type { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public abstract object Clone();
    }
}

using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Sources
{
    /// <summary>
    /// The map source type used for a layer.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<MapSourceType>))]
    public enum MapSourceType
    {
        /// <summary>
        /// <inheritdoc cref="DataSource"/>
        /// </summary>
        Data,

        /// <summary>
        /// <inheritdoc cref="ElevationTileSource"/>
        /// </summary>
        ElevationTile,

        /// <summary>
        /// <inheritdoc cref="VectorTileSource"/>
        /// </summary>
        VectorTile,
    }

    /// <summary>
    /// Base class for all map layer sources
    /// </summary>
    public abstract class MapSource : JsInteropBase, ICloneable
    {
        internal MapSource() { }

        /// <summary>
        /// <inheritdoc cref="MapSourceType"/>
        /// </summary>
        public abstract MapSourceType? Type { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public abstract object Clone();
    }
}

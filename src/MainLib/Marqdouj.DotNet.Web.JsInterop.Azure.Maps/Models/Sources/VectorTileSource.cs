namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Sources
{
    /// <summary>
    /// A map source that provides vector tiles for rendering on the map.
    /// </summary>
    public class VectorTileSource : MapSource
    {
        /// <summary>
        /// <inheritdoc cref="MapSourceType"/>
        /// </summary>
        public override MapSourceType? Type { get; } = MapSourceType.VectorTile;

        /// <summary>
        /// <inheritdoc cref="VectorTileSourceOptions"/>
        /// </summary>
        public VectorTileSourceOptions? Options { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var clone = (VectorTileSource)MemberwiseClone();
            clone.Options = Options?.Clone() as VectorTileSourceOptions;
            return clone;
        }
    }
}

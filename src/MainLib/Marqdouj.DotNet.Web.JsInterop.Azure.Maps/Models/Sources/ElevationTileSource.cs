namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Sources
{
    /// <summary>
    /// Elevation tile source describes how to access elevation (raster DEM) tile data.
    /// </summary>
    public class ElevationTileSource : MapSource
    {
        /// <summary>
        /// <inheritdoc cref="MapSourceType"/>
        /// </summary>
        public override MapSourceType? Type { get; } = MapSourceType.ElevationTile;

        /// <summary>
        /// <inheritdoc cref="ElevationTileSourceOptions"/>
        /// </summary>
        public ElevationTileSourceOptions? Options { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var clone = (ElevationTileSource)MemberwiseClone();
            clone.Options = Options?.Clone() as ElevationTileSourceOptions;
            return clone;
        }
    }
}

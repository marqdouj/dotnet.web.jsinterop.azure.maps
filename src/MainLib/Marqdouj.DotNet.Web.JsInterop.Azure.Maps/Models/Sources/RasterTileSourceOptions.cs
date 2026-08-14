namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Sources
{
    /// <summary>
    /// Options for configuring a raster tile source in Azure Maps.
    /// </summary>
    public class RasterTileSourceOptions : VectorTileSourceOptions
    {
        /// <summary>
        /// An integer value that specifies the width and height dimensions of the map tiles.
        /// For a seamless experience, the tile size must by a multiplier of 2. (i.e. 256, 512, 1024…).
        /// Default is `512`
        /// </summary>
        public double? TileSize { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var clone = (RasterTileSourceOptions)MemberwiseClone();
            return clone;
        }
    }
}

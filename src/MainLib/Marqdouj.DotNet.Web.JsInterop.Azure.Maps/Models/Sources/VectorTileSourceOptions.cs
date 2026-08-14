using Marqdouj.DotNet.Web.JsInterop.GeoJson;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Sources
{
    /// <summary>
    /// Options for configuring a vector tile source in Azure Maps.
    /// </summary>
    public class VectorTileSourceOptions : ICloneable
    {
        /// <summary>
        /// A bounding box that specifies where tiles are available.
        /// When specified, no tiles outside of the bounding box will be requested.
        /// </summary>
        public BoundingBox? Bounds { get; set; }

        /// <summary>
        /// An integer specifying the minimum zoom level to render the layer at.
        /// Default: 0
        /// </summary>
        public int? MinZoom { get; set; }

        /// <summary>
        /// An integer specifying the maximum zoom level to render the layer at.
        /// Default: 22
        /// </summary>
        public int? MaxZoom { get; set; }

        /// <summary>
        /// Specifies if the tile system's y coordinate uses the OSGeo Tile Map Services 
        /// which reverses the Y coordinate axis.
        /// Default: false
        /// </summary>
        public bool? IsTMS { get; set; }

        /// <summary>
        /// An array of one or more tile source URLs. Supported URL parameters:
        /// <list type="bullet">
        ///     <item>
        ///         <description>{x} - X position of tile. Tile URL usually also needs {y} and {z}.</description>
        ///     </item>
        ///     <item>
        ///         <description>{y} - Y position of tile. Tile URL usually also needs {x} and {z}.</description>
        ///     </item>
        ///     <item>
        ///         <description>{z} - Zoom level of tile. Tile URL usually also needs {x} and {y}.</description>
        ///     </item>
        ///     <item>
        ///         <description>{quadkey} - Tile quadkey id based on the Bing Maps tile system naming convention.</description>
        ///     </item>
        ///     <item>
        ///         <description>{bbox-epsg-3857} - A bounding box string with the format "{west},{south},{east},{north}" 
        ///         with coordinates in the EPSG 3857 Spatial Reference System also commonly known as WGS84 Web Mercator. 
        ///         This is useful when working with WMS imagery services.</description>
        ///     </item>
        /// </list>
        /// </summary>
        public List<string>? Tiles { get; set; }

        /// <summary>
        /// A URL to a TileJSON resource.
        /// Supported protocols are http: and https:.
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public virtual object Clone()
        {
            var clone = (VectorTileSourceOptions)MemberwiseClone();
            clone.Bounds = Bounds?.Clone() as BoundingBox;
            clone.Tiles = Tiles?.ToList();

            return clone;
        }
    }
}

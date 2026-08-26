namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Spatial
{
    /// <summary>
    /// <inheritdoc cref="KmlReadOptions"/>
    /// </summary>
    public interface IKmlReadOptions
    {
        /// <summary>
        /// <inheritdoc cref="KmlReadOptions.ExtrudePolygons"/>
        /// </summary>
        bool? ExtrudePolygons { get; set; }

        /// <summary>
        /// <inheritdoc cref="KmlReadOptions.IgnoreVisibility"/>
        /// </summary>
        bool? IgnoreVisibility { get; set; }

        /// <summary>
        /// <inheritdoc cref="KmlReadOptions.MaxNetworkLinkDepth"/>
        /// </summary>
        int? MaxNetworkLinkDepth { get; set; }

        /// <summary>
        /// <inheritdoc cref="KmlReadOptions.MaxNetworkLinks"/>
        /// </summary>
        int? MaxNetworkLinks { get; set; }
    }

    /// <summary>
    /// Options that customize how KML files are read and parsed.
    /// </summary>
    public class KmlReadOptions : BaseSpatialXmlReadOptions, IKmlReadOptions
    {
        /// <summary>
        /// Specifies if shapes visible tags should be used to set the visible property of it's equivalent GeoJSON object.
        /// Default is 'true'.
        /// </summary>
        public bool? IgnoreVisibility { get; set; }

        /// <summary>
        /// The maximum number of network links that a single KML file can have.
        /// Default is '10'.
        /// </summary>
        public int? MaxNetworkLinks { get; set; }

        /// <summary>
        /// The maximum depth of network links in a KML file.
        /// Example: when set to 3; file1 links to file2 which links to file3 but won't open links in file3.
        /// Default is '3'.
        /// </summary>
        public int? MaxNetworkLinkDepth { get; set; }

        /// <summary>
        /// Specifies if polygon extrusion information should be captured in KML files.
        /// If set to true, and a polygon has extrusion data, a height property will be added to polygon features properties
        /// to indicate how much the polygon should be extruded vertically in meters.
        /// Default is 'true'.
        /// </summary>
        public bool? ExtrudePolygons { get; set; }
    }
}

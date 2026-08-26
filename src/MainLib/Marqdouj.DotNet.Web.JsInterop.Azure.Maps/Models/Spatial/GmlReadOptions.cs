using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Spatial
{
    /// <summary>
    /// <inheritdoc cref="GmlReadOptions"/>
    /// </summary>
    public interface IGmlReadOptions
    {
        /// <summary>
        /// <inheritdoc cref="GmlReadOptions.IsAxisOrderLonLat"/>
        /// </summary>
        bool? IsAxisOrderLonLat { get; set; }

        /// <summary>
        /// <inheritdoc cref="GmlReadOptions.PropertyTypes"/>
        /// </summary>
        Properties? PropertyTypes { get; set; }
    }

    /// <summary>
    /// Options that customize how GML files are read and parsed.
    /// </summary>
    public class GmlReadOptions : BaseSpatialXmlReadOptions, IGmlReadOptions
    {
        /// <summary>
        /// If the reading a GML file, this specifies if the coordinate information is ordered 'longitude, latitude'.
        /// If set to false, coordinates will be parsed as "latitude, longitude".
        /// If unspecified, will try and determine based on hints within the GML,
        /// with a preference for 'latitude, longitude' ordering.
        /// </summary>
        public bool? IsAxisOrderLonLat { get; set; }

        /// <summary>
        /// If the reading a GML file, this contains a key-value pair list of property names to types
        /// which is used for deserializing custom properties.
        /// If a property name is not in the list, the property value will be parsed as a string.
        /// Typescript: Record{string, string | "string" | "number" | "boolean" | "date"}
        /// </summary>
        public Properties? PropertyTypes { get; set; }
    }
}

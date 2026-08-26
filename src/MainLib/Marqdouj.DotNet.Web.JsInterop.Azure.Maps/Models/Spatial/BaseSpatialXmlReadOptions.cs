namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Spatial
{
    /// <summary>
    /// <inheritdoc cref="BaseSpatialXmlReadOptions"/>
    /// </summary>
    public interface IBaseSpatialXmlReadOptions
    {
        /// <summary>
        /// <inheritdoc cref="BaseSpatialXmlReadOptions.ParseStyles"/>
        /// </summary>
        bool? ParseStyles { get; set; }
    }

    /// <summary>
    /// Options that customize how XML files are read and parsed.
    /// </summary>
    public class BaseSpatialXmlReadOptions : BaseSpatialDataReadOptions, IBaseSpatialXmlReadOptions
    {
        /// <summary>
        /// Specifies if style information should be parsed from the XML file and included as properties of the features.
        /// Default is 'true'.
        /// </summary>
        public bool? ParseStyles { get; set; }
    }
}

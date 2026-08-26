namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Spatial
{
    /// <summary>
    /// <inheritdoc cref="BaseSpatialDataReadOptions"/>
    /// </summary>
    public interface IBaseSpatialDataReadOptions
    {
        /// <summary>
        /// <inheritdoc cref="BaseSpatialDataReadOptions.MaxFeatures"/>
        /// </summary>
        int? MaxFeatures { get; set; }

        /// <summary>
        /// <inheritdoc cref="BaseSpatialDataReadOptions.ProxyService"/>
        /// </summary>
        string? ProxyService { get; set; }
    }

    /// <summary>
    /// Options used for reading spatial data files.
    /// </summary>
    public class BaseSpatialDataReadOptions : IBaseSpatialDataReadOptions
    {
        /// <summary>
        /// Specifies the maximum number of features to read from the data set.
        /// If not specified, will read all features.
        /// </summary>
        public int? MaxFeatures { get; set; }

        /// <summary>
        /// A URL to a proxy service that can have a URL to an external file appended it.
        /// This will be needed to access files that are hosted on non-CORs enabled endpoints.
        /// </summary>
        public string? ProxyService { get; set; }
    }
}

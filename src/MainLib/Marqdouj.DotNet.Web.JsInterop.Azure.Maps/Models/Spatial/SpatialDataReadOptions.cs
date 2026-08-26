using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Spatial
{
    /// <summary>
    /// Options that customize how spatial files are read and parsed.
    /// </summary>
    public class SpatialDataReadOptions : 
        IBaseSpatialDataReadOptions,
        IBaseSpatialXmlReadOptions,
        ICsvHeader,
        IGmlReadOptions,
        IGpxReadOptions,
        IKmlReadOptions,
        ISpatialCsvReadOptions
    {
        #region BaseSpatialDataReadOptions

        /// <summary>
        /// <inheritdoc cref="BaseSpatialDataReadOptions.MaxFeatures"/>
        /// </summary>
        public int? MaxFeatures { get; set; }

        /// <summary>
        /// <inheritdoc cref="BaseSpatialDataReadOptions.ProxyService"/>
        /// </summary>
        public string? ProxyService { get; set; }

        #endregion

        #region BaseSpatialXmlReadOptions

        /// <summary>
        /// <inheritdoc cref="BaseSpatialXmlReadOptions.ParseStyles"/>
        /// </summary>
        public bool? ParseStyles { get; set; }

        #endregion

        #region CsvHeader

        /// <summary>
        /// <inheritdoc cref="CsvHeader.Names"/>
        /// </summary>
        public List<string>? Names { get; set; }

        /// <summary>
        /// <inheritdoc cref="CsvHeader.Types"/>
        /// </summary>
        public List<string>? Types { get; set; }

        #endregion
        
        #region GmlReadOptions

        /// <summary>
        /// <inheritdoc cref="GmlReadOptions.IsAxisOrderLonLat"/>
        /// </summary>
        public bool? IsAxisOrderLonLat { get; set; }

        /// <summary>
        /// <inheritdoc cref="GmlReadOptions.PropertyTypes"/>
        /// </summary>
        public Properties? PropertyTypes { get; set; }

        #endregion

        #region GpxReadOptions

        /// <summary>
        /// <inheritdoc cref="GpxReadOptions.CapturePathWaypoints"/>
        /// </summary>
        public bool? CapturePathWaypoints { get; set; }

        #endregion

        #region KmlReadOptions

        /// <summary>
        /// <inheritdoc cref="KmlReadOptions.IgnoreVisibility"/>
        /// </summary>
        public bool? IgnoreVisibility { get; set; }

        /// <summary>
        /// <inheritdoc cref="KmlReadOptions.MaxNetworkLinks"/>
        /// </summary>
        public int? MaxNetworkLinks { get; set; }

        /// <summary>
        /// <inheritdoc cref="KmlReadOptions.MaxNetworkLinkDepth"/>
        /// </summary>
        public int? MaxNetworkLinkDepth { get; set; }

        /// <summary>
        /// <inheritdoc cref="KmlReadOptions.ExtrudePolygons"/>
        /// </summary>
        public bool? ExtrudePolygons { get; set; }

        #endregion

        #region SpatialCsvReadOptions

        /// <summary>
        /// <inheritdoc cref="SpatialCsvReadOptions.Header"/>
        /// </summary>
        public CsvHeader? Header { get; set; }

        /// <summary>
        /// <inheritdoc cref="SpatialCsvReadOptions.DynamicTyping"/>
        /// </summary>
        public bool? DynamicTyping { get; set; }

        /// <summary>
        /// <inheritdoc cref="SpatialCsvReadOptions.Delimiter"/>
        /// </summary>
        public string? Delimiter { get; set; }

        #endregion
    }
}

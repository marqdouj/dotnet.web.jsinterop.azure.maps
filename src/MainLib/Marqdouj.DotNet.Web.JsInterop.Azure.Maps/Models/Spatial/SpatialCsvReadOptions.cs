namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Spatial
{
    /// <summary>
    /// <inheritdoc cref="SpatialCsvReadOptions"/>
    /// </summary>
    public interface ISpatialCsvReadOptions
    {
        /// <summary>
        /// <inheritdoc cref="SpatialCsvReadOptions.Delimiter"/>
        /// </summary>
        string? Delimiter { get; set; }

        /// <summary>
        /// <inheritdoc cref="SpatialCsvReadOptions.DynamicTyping"/>
        /// </summary>
        bool? DynamicTyping { get; set; }

        /// <summary>
        /// <inheritdoc cref="SpatialCsvReadOptions.Header"/>
        /// </summary>
        CsvHeader? Header { get; set; }
    }

    /// <summary>
    /// Options used for reading delimited files.
    /// </summary>
    public class SpatialCsvReadOptions : BaseSpatialDataReadOptions, ISpatialCsvReadOptions
    {
        /// <summary>
        /// Header information for each column in the delimited file.
        /// If not specified, the first row in the data will be used.
        /// </summary>
        public CsvHeader? Header { get; set; }

        /// <summary>
        /// If no header information is specified, or the header does not contain type information.
        /// Each cell value will be analyzed to determine if it is a number, boolean or date and parsed accordingly.
        /// Default is 'false'.
        /// </summary>
        public bool? DynamicTyping { get; set; }

        /// <summary>
        /// The delimiter character that separates the cells in a row of data.
        /// If set to `"auto"`, the data will be analyzed and a suitable delimiter will be chosen from `","` `"|"`, `"\t"`.
        /// Default is 'auto'.
        /// </summary>
        public string? Delimiter { get; set; }
    }
}

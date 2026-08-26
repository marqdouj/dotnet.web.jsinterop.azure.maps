namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Spatial
{
    /// <summary>
    /// <inheritdoc cref="CsvHeader"/>
    /// </summary>
    public interface ICsvHeader
    {
        /// <summary>
        /// <inheritdoc cref="CsvHeader.Names"/>
        /// </summary>
        List<string>? Names { get; set; }

        /// <summary>
        /// <inheritdoc cref="CsvHeader.Types"/>
        /// </summary>
        List<string>? Types { get; set; }
    }

    /// <summary>
    /// Column header definition for a delimited file.
    /// </summary>
    public class CsvHeader : ICsvHeader
    {
        /// <summary>
        /// The name of each column.
        /// </summary>
        public List<string>? Names { get; set; }

        /// <summary>
        /// The type of each column; string, number, boolean, date, geography (Well Known Text string).
        /// If unspecified or null, will default to string.
        /// </summary>
        public List<string>? Types { get; set; }
    }
}

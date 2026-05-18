using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models
{
    /// <summary>
    /// Represents a JavaScript error.
    /// </summary>
    public class JsError
    {
        /// <summary>
        /// The name of the error.
        /// </summary>
        [JsonInclude] public string? Name { get; internal set; }

        /// <summary>
        /// The message for the error.
        /// </summary>
        [JsonInclude] public string? Message { get; internal set; }

        /// <summary>
        /// The stack trace for the error.
        /// </summary>
        [JsonInclude] public string? Stack { get; internal set; }
    }
}

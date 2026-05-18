using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events
{
    /// <summary>
    /// Represents the payload data for a map event popup.
    /// </summary>
    public class MapEventPopupPayload
    {
        /// <summary>
        /// The type of the event that triggered the popup.
        /// </summary>
        [JsonInclude]
        public string? Type { get; internal set; }
    }
}

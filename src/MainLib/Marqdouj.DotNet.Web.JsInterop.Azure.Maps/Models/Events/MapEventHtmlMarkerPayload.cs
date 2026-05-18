using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events
{
    /// <summary>
    /// Represents the payload data for an HTML marker event on a map, including event type and optional keyboard event
    /// information.
    /// </summary>
    public class MapEventHtmlMarkerPayload
    {
        /// <summary>
        /// The type of event.
        /// </summary>
        [JsonInclude]
        public string? Type { get; internal set; }

        /// <summary>
        /// <inheritdoc cref="MapEventKeyboardPayload"/>
        /// </summary>
        public MapEventKeyboardPayload? Keyboard { get; set; }
    }
}

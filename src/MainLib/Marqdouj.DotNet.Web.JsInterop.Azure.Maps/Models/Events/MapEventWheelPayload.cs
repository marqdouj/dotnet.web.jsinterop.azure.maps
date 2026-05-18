using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events
{
    /// <summary>
    /// Payload for the wheel event on the map.
    /// </summary>
    public class MapEventWheelPayload
    {
        /// <summary>
        /// Wheel event type.
        /// </summary>
        [JsonInclude] public string? Type { get; internal set; }
    }
}

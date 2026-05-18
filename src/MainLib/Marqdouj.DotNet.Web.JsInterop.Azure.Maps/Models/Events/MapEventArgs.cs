using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events
{
    /// <summary>
    /// Base class for all map events.
    /// </summary>
    public class MapEventArgs
    {
        /// <summary>
        /// map container id.
        /// </summary>
        [JsonInclude] 
        public string? MapId { get; internal set; }

        /// <summary>
        /// <inheritdoc cref="MapEvent.Type"/>
        /// </summary>
        [JsonInclude]
        public MapEventType Type { get; internal set; }

        /// <summary>
        /// <inheritdoc cref="MapEvent.Target"/>
        /// </summary>
        [JsonInclude]
        public MapEventTarget? Target { get; internal set; }

        /// <summary>
        /// <inheritdoc cref="MapEvent.TargetId"/>
        /// </summary>
        [JsonInclude]
        public string? TargetId { get; internal set; }

        /// <summary>
        /// <inheritdoc cref="MapEventArgsPayload"/>
        /// </summary>
        [JsonInclude]
        public MapEventArgsPayload? Payload { get; internal set; }
    }
}

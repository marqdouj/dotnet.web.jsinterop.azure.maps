using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Payload for a keyboard event on the map. 
    /// This class contains information about the key pressed, its code, location, and modifier keys (Alt, Ctrl, Shift, Meta) that were active during the event.
    /// </summary>
    public class MapEventKeyboardPayload
    {
        [JsonInclude] public string? Key { get; internal set; }
        [JsonInclude] public string? Code { get; internal set; }
        [JsonInclude] public long? Location { get; internal set; }
        [JsonInclude] public bool? Repeat { get; internal set; }
        [JsonInclude] public bool? AltKey { get; internal set; }
        [JsonInclude] public bool? CtrlKey { get; internal set; }
        [JsonInclude] public bool? ShiftKey { get; internal set; }
        [JsonInclude] public bool? MetaKey { get; internal set; }
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

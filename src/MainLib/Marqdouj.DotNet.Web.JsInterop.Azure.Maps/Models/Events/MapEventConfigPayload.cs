using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// map configuration payload for Azure Maps events, containing metadata and style configurations.
    /// </summary>
    public class MapEventConfigPayload
    {
        [JsonInclude] public string? Created { get; internal set; }
        [JsonInclude] public string? DefaultConfiguration { get; internal set; }
        [JsonInclude] public string? Description { get; internal set; }
        [JsonInclude] public List<MapEventConfigurationStyle>? Configurations { get; internal set; }
        [JsonInclude] public int? Version { get; internal set; }
    }

    /// <summary>
    /// Represents the style for a map configuration event.
    /// </summary>
    public class MapEventConfigurationStyle
    {
        [JsonInclude] public string? Copyright { get; internal set; }
        [JsonInclude] public string? DisplayName { get; internal set; }
        [JsonInclude] public string? Name { get; internal set; }
        [JsonInclude] public string? ShortcutKey { get; internal set; }
        [JsonInclude] public object? Style { get; internal set; }
        [JsonInclude] public string? Theme { get; internal set; }
        [JsonInclude] public string? Thumbnail { get; internal set; }
        [JsonInclude] public string? Url { get; internal set; }
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

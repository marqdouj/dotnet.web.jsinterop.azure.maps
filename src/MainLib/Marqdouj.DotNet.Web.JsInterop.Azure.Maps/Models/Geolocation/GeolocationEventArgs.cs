using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Geolocation
{
    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<GeolocationEventType>))]
    public enum GeolocationEventType
    {
        /// <summary>
        /// Indicates whether the watch operation completed successfully.
        /// </summary>
        WatchSuccess,

        /// <summary>
        /// Indicates whether the watch operation encountered an error.
        /// </summary>
        WatchError,
    }

    /// <summary>
    /// Provides data for geolocation-related events, including the event type, associated map identifier, and
    /// geolocation result.
    /// </summary>
    public class GeolocationEventArgs
    {
        /// <summary>
        /// <see cref="GeolocationEventType"/>
        /// </summary>
        [JsonInclude]
        public GeolocationEventType? Type { get; internal set; }

        /// <summary>
        /// Gets the unique identifier of the map associated with this instance.
        /// </summary>
        [JsonInclude]
        public string? MapId { get; internal set; }

        /// <summary>
        /// <inheritdoc cref="GeolocationResult"/>
        /// </summary>
        [JsonInclude]
        public GeolocationResult? Result { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the operation completed successfully.
        /// </summary>
        [JsonIgnore]
        public bool IsSuccess => Result?.IsSuccess ?? false;
    }
}

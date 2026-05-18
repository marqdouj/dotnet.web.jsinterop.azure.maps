using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models
{

    /// <summary>
    /// Status for attempting to create a map.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<CreateMapStatus>))]
    public enum CreateMapStatus
    {
        /// <summary>
        /// The action failed. <see cref="CreateMapResult.Error"/> or <see cref="CreateMapResult.Message"/>
        /// </summary>
        Failure,
        /// <summary>
        /// map was created.
        /// </summary>
        Created,
        /// <summary>
        /// map already exits.
        /// </summary>
        Exists,
    }

    /// <summary>
    /// Results returned when attempting to create a map.
    /// </summary>
    public class CreateMapResult
    {
        /// <summary>
        /// The css id for the map container.
        /// </summary>
        [JsonInclude] public string MapId { get; internal set; } = string.Empty;

        /// <summary>
        /// <see cref="CreateMapStatus"/>
        /// </summary>
        [JsonInclude] public CreateMapStatus Status { get; internal set; }

        /// <summary>
        /// Message associated with the <see cref="Status"/>. May be null.
        /// </summary>
        [JsonInclude] public string? Message { get; internal set; } = string.Empty;

        /// <summary>
        /// Error associated with the result. May be null.
        /// </summary>
        [JsonInclude] public JsError? Error { get; internal set; }
    }
}

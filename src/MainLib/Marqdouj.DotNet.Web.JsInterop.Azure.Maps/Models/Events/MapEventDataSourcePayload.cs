using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events
{
    /// <summary>
    /// Represents the payload for a datasource map event.
    /// </summary>
    public class MapEventDataSourcePayload
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// An array of shape and Feature objects associated with the event.
        /// </summary>
        [JsonInclude] public List<MapEventShape>? Shapes { get; internal set; }
    }
}

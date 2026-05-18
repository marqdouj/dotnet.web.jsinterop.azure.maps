using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models
{
    /// <summary>
    /// The type of edit action to perform when updating the map.
    /// Replace will replace all values defined in the class; null values are set to their defaults. 
    /// Update will update existing values. Only those values that are not null will be updated.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<MapEditAction>))]
    public enum MapEditAction
    {
        /// <summary>
        /// Updates existing values. Only those values that are not null will be updated.
        /// </summary>
        Update,

        /// <summary>
        /// Replaces all values defined in the class; null values are set to their defaults.
        /// </summary>
        Replace,
    }
}

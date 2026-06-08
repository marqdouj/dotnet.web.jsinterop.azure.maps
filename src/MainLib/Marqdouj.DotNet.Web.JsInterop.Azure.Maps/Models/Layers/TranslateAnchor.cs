using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers
{
    /// <summary>
    /// Specifies the frame of reference for `translate`.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<TranslateAnchor>))]
    public enum TranslateAnchor
    {
        /// <summary>
        /// Translate relative to the map.
        /// </summary>
        [Display(Name = "Map")]
        map,

        /// <summary>
        /// Translate relative to the viewport
        /// </summary>
        [Display(Name = "Viewport")]
        viewport,
    }
}

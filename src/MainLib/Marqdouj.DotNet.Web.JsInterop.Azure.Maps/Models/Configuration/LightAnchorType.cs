using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration
{
    /// <summary>
    /// Specifies wether extruded geometries are lit relative to the map or viewport.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<LightAnchorType>))]
    public enum LightAnchorType
    {
        /// <summary>
        /// The position of the light source is aligned to the rotation of the map.
        /// </summary>
        [Display(Name = "map")]
        map,

        /// <summary>
        /// The position fo the light source is aligned to the rotation of the viewport.
        /// </summary>
        [Display(Name = "viewport")]
        viewport
    }
}

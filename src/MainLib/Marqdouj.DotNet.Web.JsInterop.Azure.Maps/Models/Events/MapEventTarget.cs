using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Specifies the target element for map-related events.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<MapEventTarget>))]
    public enum MapEventTarget
    {
        [Display(Name = "Map")]
        map,

        [Display(Name = "Datasource")]
        datasource,

        [Display(Name = "Html Marker")]
        htmlmarker,

        [Display(Name = "Layer")]
        layer,

        [Display(Name = "Popup")]
        popup,

        [Display(Name = "Shape")]
        shape,

        [Display(Name = "Style Control")]
        stylecontrol,
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

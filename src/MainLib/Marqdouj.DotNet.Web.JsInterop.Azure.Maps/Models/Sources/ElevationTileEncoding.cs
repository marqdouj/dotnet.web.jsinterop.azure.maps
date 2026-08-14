using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Sources
{
    /// <summary>
    /// DEM tiles encoding format.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<ElevationTileEncoding>))]
    public enum ElevationTileEncoding
    {
        /// <summary>
        /// Mapbox Terrain RGB tiles. <see href="https://www.mapbox.com/help/access-elevation-data/#mapbox-terrain-rgb"/> for more info.
        /// </summary>
        [Display(Name = "Mapbox")]
        mapbox,

        /// <summary>
        /// Terrarium format PNG tiles. <see href="https://aws.amazon.com/es/public-datasets/terrain/"/> for more info.
        /// </summary>
        [Display(Name = "Terrarium")]
        terrarium
    }
}

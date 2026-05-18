using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration
{
    /// <summary>
    /// Note: absolute and relative-delay have been depreciated by the Azure Maps SDK and are not listed.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<TrafficFlow>))]
    public enum TrafficFlow
    {
        /// <summary>
        /// Display no traffic.
        /// </summary>
        [Display(Name = "None")]
        none,

        /// <summary>
        /// The speed of the road relative to free-flow
        /// </summary>
        [Display(Name = "Relative")]
        relative,
    }

    /// <summary>
    /// The options for traffic on the map.
    /// </summary>
    [Display(Name = "Traffic")]
    public class TrafficOptions : OptionsBase
    {
        /// <summary>
        /// The type of traffic flow to display:
        /// "none" is to display no traffic flow data
        /// "relative" is the speed of the road relative to free-flow
        /// Default is "none".
        /// </summary>
        public TrafficFlow? Flow { get; set; }

        /// <summary>
        /// Whether to display incidents on the map.
        /// Default is false.
        /// </summary>
        public bool? Incidents { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return MemberwiseClone();
        }
    }
}

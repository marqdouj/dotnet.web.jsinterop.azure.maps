using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events
{
    /// <summary>
    /// Represents the payload for a map event that specifies the map style to apply.
    /// </summary>
    public class MapEventStylePayload
    {
        /// <summary>
        /// <inheritdoc cref="MapStyle"/>
        /// </summary>
        public MapStyle? Style { get; set; }
    }
}

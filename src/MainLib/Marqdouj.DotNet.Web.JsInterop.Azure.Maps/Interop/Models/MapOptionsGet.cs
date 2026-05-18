using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models
{
    /// <summary>
    /// The options returned from the map.
    /// </summary>
    /// <remarks>This class contains extra configuration for updating the map.</remarks>
    internal class MapOptionsGet
    {
        /// <summary>
        /// <see cref="MapCamera"/>
        /// </summary>
        public MapCamera? Camera { get; set; }

        /// <summary>
        /// <see cref="ServiceOptions"/>
        /// </summary>
        public ServiceOptions? Service { get; set; }

        /// <summary>
        /// <see cref="StyleOptions"/>
        /// </summary>
        public StyleOptions? Style { get; set; }

        /// <summary>
        /// <see cref="TrafficOptions"/>
        /// </summary>
        public TrafficOptions? Traffic { get; set; }

        /// <summary>
        /// <see cref="UserInteractionOptions"/>
        /// </summary>
        public UserInteractionOptions? UserInteraction { get; set; }

        /// <summary>
        /// Creates an instance of <see cref="MapOptions"/> based on this class.
        /// </summary>
        /// <returns></returns>
        public MapOptions ToMapOptions()
        {
            return new MapOptions
            {
                Camera = Camera?.ToCameraOptions(),
                CameraBounds = Camera?.ToCameraBoundsOptions(),
                Service = Service,
                Style = Style,
                Traffic = Traffic,
                UserInteraction = UserInteraction,
            };
        }
    }
}

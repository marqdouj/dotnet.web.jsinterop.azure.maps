using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models
{
    /// <summary>
    /// Indicates the map options to use in the map configuration operation.
    /// </summary>
    public class MapOptionsArgs : ICloneable
    {
        /// <summary>
        /// Constructor that sets all flags to true, enabling all options by default.
        /// </summary>
        public MapOptionsArgs()
        {
        }

        /// <summary>
        /// Constructor that sets only the specified flags, leaving others as false.
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="service"></param>
        /// <param name="style"></param>
        /// <param name="traffic"></param>
        /// <param name="userInteraction"></param>
        public MapOptionsArgs(
            bool camera = false,
            bool service = false,
            bool style = false,
            bool traffic = false,
            bool userInteraction = false) : this()
        {
            Camera = camera;
            Service = service;
            Style = style;
            Traffic = traffic;
            UserInteraction = userInteraction;
        }

        /// <summary>
        /// Get the Camera options. <inheritdoc cref="MapOptions.Camera"/>
        /// </summary>
        public bool Camera { get; set; } = true;

        /// <summary>
        /// Get the Service options. <inheritdoc cref="MapOptions.Service"/>
        /// </summary>
        public bool Service { get; set; } = true;

        /// <summary>
        /// Get the style options. <inheritdoc cref="MapOptions.Style"/>
        /// </summary>
        public bool Style { get; set; } = true;

        /// <summary>
        /// Get the Traffic options. <inheritdoc cref="MapOptions.Traffic"/>
        /// </summary>
        public bool Traffic { get; set; } = true;

        /// <summary>
        /// Get the UserInteraction options. <inheritdoc cref="MapOptions.UserInteraction"/>
        /// </summary>
        public bool UserInteraction { get; set; } = true;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public object Clone() => MemberwiseClone();
    }
}

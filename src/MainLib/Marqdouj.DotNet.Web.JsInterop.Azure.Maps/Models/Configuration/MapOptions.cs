using System.ComponentModel.DataAnnotations;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration
{
    /// <summary>
    /// Configuration options for the map.
    /// </summary>
    public class MapOptions : ICloneable
    {
        /// <summary>
        /// The camera configuration to be used for the map.
        /// Camera and CameraBounds are mutually exclusive; Camera takes precedence if both are set.
        /// </summary>
        public CameraOptions? Camera { get; set; }

        /// <summary>
        /// The camera bounds configuration to be used for the map.
        /// Camera and CameraBounds are mutually exclusive. Camera takes precedence if both are set.
        /// </summary>
        /// <remarks>If set, the camera will be constrained to the specified bounds. If null, the camera
        /// is not restricted and can move freely. This property is typically used to prevent the camera from panning or
        /// zooming outside a designated area.</remarks>
        [Display(Name = "Camera Bounds")]
        public CameraBoundsOptions? CameraBounds { get; set; }

        /// <summary>
        /// The service configuration to be used for the map.
        /// </summary>
        public ServiceOptions? Service { get; set; }

        /// <summary>
        /// The style configuration to be used for the map.
        /// </summary>
        public StyleOptions? Style { get; set; }

        /// <summary>
        /// The traffic configuration to be used for the map.
        /// </summary>
        public TrafficOptions? Traffic { get; set; }

        /// <summary>
        /// The user interaction configuration to be used for the map.
        /// </summary>
        /// <remarks>Specify user interaction options to customize prompts, confirmations, or other
        /// interactive features. If set to <see langword="null"/>, default interaction behavior will be used.</remarks>
        [Display(Name = "User Interaction")]
        public UserInteractionOptions? UserInteraction { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new MapOptions
            {
                Camera = (CameraOptions?)Camera?.Clone(),
                CameraBounds = (CameraBoundsOptions?)CameraBounds?.Clone(),
                Service = (ServiceOptions?)Service?.Clone(),
                Style = (StyleOptions?)Style?.Clone(),
                Traffic = (TrafficOptions?)Traffic?.Clone(),
                UserInteraction = (UserInteractionOptions?)UserInteraction?.Clone()
            };
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration
{
    /// <summary>
    /// The options for enabling/disabling user interaction with the map.
    /// </summary>
    [Display(Name = "User Interaction")]
    public class UserInteractionOptions : OptionsBase
    {
        /// <summary>
        /// Whether the Shift + left click and drag will draw a zoom box.
        /// Default 'true'.
        /// </summary>
        [Display(Name = "Box Zoom Interaction")]
        public bool? BoxZoomInteraction { get; set; }

        /// <summary>
        /// Whether double left click will zoom the map inwards.
        /// Default 'true'.
        /// </summary>
        [Display(Name = "Double Click Zoom Interaction")]
        public bool? DblClickZoomInteraction { get; set; }

        /// <summary>
        /// Whether left click and drag will pan the map.
        /// Default 'true'.
        /// </summary>
        [Display(Name = "Drag Pan Interaction")]
        public bool? DragPanInteraction { get; set; }

        /// <summary>
        /// Whether right click and drag will rotate and pitch the map.
        /// Default 'true'.
        /// </summary>
        [Display(Name = "Drag Rotate Interaction")]
        public bool? DragRotateInteraction { get; set; }

        /// <summary>
        /// Whether the map is interactive or static. If false, all user interaction is disabled.  
        /// If true, only selected user interactions will enabled.
        /// Default 'true'.
        /// </summary>
        public bool? Interactive { get; set; }

        /// <summary>
        /// Whether the keyboard interactions are enabled.
        /// Default 'true'.
        /// </summary>
        [Display(Name = "Keyboard Interaction")]
        public bool? KeyboardInteraction { get; set; }

        /// <summary>
        /// Whether the map should zoom on scroll input.
        /// Default 'true'.
        /// </summary>
        [Display(Name = "Scroll Zoom Interaction")]
        public bool? ScrollZoomInteraction { get; set; }

        /// <summary>
        /// Whether touch interactions are enabled for touch devices.
        /// Default 'true'.
        /// </summary>
        [Display(Name = "Touch Interaction")]
        public bool? TouchInteraction { get; set; }

        /// <summary>
        /// Whether touch rotation is enabled for touch devices. This option is not applied if touchInteraction is disabled.
        /// Default 'true'.
        /// </summary>
        [Display(Name = "Touch Rotate")]
        public bool? TouchRotate { get; set; }

        /// <summary>
        /// Sets the zoom rate of the mouse wheel
        /// Default '1/450'.
        /// </summary>
        [Display(Name = "Wheel Zoom Rate")]
        public double? WheelZoomRate { get; set; }

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

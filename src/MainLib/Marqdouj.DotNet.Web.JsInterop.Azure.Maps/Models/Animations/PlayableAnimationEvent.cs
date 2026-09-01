using Marqdouj.DotNet.Web.JsInterop.GeoJson;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Animations
{
    /// <summary>
    /// Playable animation event argument.
    /// </summary>
    public class PlayableAnimationEvent
    {
        /// <summary>
        /// The event type.
        /// </summary>
        public string Type { get; set; } = default!;

        /// <summary>
        /// The animation the event occurred on.
        /// </summary>
        public string AnimationId { get; set; } = default!;

        /// <summary>
        /// Timestamp of the event in UTC format.
        /// </summary>
        public string? Timestamp { get; set; }

        /// <summary>
        /// Speed in km/hr of the animation at the current frame. This is only returned by path animations.
        /// </summary>
        public double? Speed { get; set; }

        /// <summary>
        /// Progress of the animation where 0 is the start and 1 is the end.
        /// </summary>
        public double Progress { get; set; }

        /// <summary>
        /// The progress of the animation after being passed through an easing function.
        /// </summary>
        public double? EasingProgress { get; set; }

        /// <summary>
        /// The focal position of an animation frame. Returned by path animations.
        /// </summary>
        public Position? Position { get; set; }

        /// <summary>
        /// The focal heading of an animation frame. Returned by path animations.
        /// </summary>
        public double? Heading { get; set; }
    }
}

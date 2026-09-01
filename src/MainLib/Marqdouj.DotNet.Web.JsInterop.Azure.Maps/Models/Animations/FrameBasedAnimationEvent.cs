namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Animations
{
    /// <summary>
    /// Event arguments for a frame based animation.
    /// </summary>
    public class FrameBasedAnimationEvent
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
        /// The index of the frame if using the frame based animation timer.
        /// </summary>
        public double? FrameIdx { get; set; }

        /// <summary>
        /// The number of frames in the animation.
        /// </summary>
        public double? NumFrames { get; set; }
    }
}

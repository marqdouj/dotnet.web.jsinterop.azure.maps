using Microsoft.JSInterop;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Animations
{
    /// <summary>
    /// Event arguments for a frame based animation.
    /// </summary>
    public sealed class FrameBasedAnimationEvent : IAsyncDisposable
    {
        /// <summary>
        /// The event type.
        /// </summary>
        public string Type { get; set; } = default!;

        /// <summary>
        /// The animation the event occurered on (FrameBasedAnimationTimer).
        /// </summary>
        public IJSObjectReference? Animation { get; set; }

        /// <summary>
        /// The index of the frame if using the frame based animation timer.
        /// </summary>
        public int? FrameIdx { get; set; }

        /// <summary>
        /// The number of frames in the animation.
        /// </summary>
        public int? NumFrames { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public async ValueTask DisposeAsync()
        {
            if (Animation != null) 
                await Animation.DisposeAsync();
        }
    }
}

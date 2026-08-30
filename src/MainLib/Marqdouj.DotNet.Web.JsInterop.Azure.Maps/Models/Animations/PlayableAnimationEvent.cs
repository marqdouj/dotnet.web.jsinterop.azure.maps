using Marqdouj.DotNet.Web.JsInterop.GeoJson;
using Microsoft.JSInterop;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Animations
{
    /// <summary>
    /// Playable animation event argument.
    /// </summary>
    public sealed class PlayableAnimationEvent :IAsyncDisposable
    {
        /// <summary>
        /// The event type.
        /// </summary>
        public string Type { get; set; } = default!;

        /// <summary>
        /// The animation the event occurred on (PlayableAnimation).
        /// </summary>
        public IJSObjectReference? Animation { get; set; }

        /// <summary>
        /// Progress of the animation where 0 is the start and 1 is the end.
        /// </summary>
        public double? Progress { get; set; }

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

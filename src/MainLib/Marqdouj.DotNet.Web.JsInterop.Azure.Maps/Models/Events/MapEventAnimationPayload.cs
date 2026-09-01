using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Animations;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events
{
    /// <summary>
    /// Provides information associated with an animation event.
    /// </summary>
    public class MapEventAnimationPayload
    {
        /// <summary>
        /// <inheritdoc cref="MapEventTypeAnimation"/>
        /// </summary>
        [JsonInclude]
        public MapEventTypeAnimation Type { get; internal set; }

        /// <summary>
        /// <inheritdoc cref="FrameBasedAnimationEvent"/> (if applicable to the <see cref="MapEventTypeAnimation"/>.
        /// </summary>
        [JsonInclude]
        public FrameBasedAnimationEvent? FrameEvent { get; internal set; }

        /// <summary>
        /// <inheritdoc cref="PlayableAnimationEvent"/> (if applicable to the <see cref="MapEventTypeAnimation"/>.
        /// </summary>
        [JsonInclude]
        public PlayableAnimationEvent? PlayableEvent { get; internal set; }
    }
}

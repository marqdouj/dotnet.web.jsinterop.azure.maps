using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration
{
    /// <summary>
    /// The type of animation.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<AnimationType>))]
    public enum AnimationType
    {
        /// <summary>
        /// An immediate change.
        /// </summary>
        [Display(Name = "Jump")]
        jump,

        /// <summary>
        /// A gradual change of the camera's settings.
        /// </summary>
        [Display(Name = "Ease")]
        ease,

        /// <summary>
        /// A gradual change of the camera's settings following an arc resembling flight.
        /// </summary>
        [Display(Name = "Fly")]
        fly
    }

    /// <summary>
    /// The options for animating changes to the map control's camera.
    /// </summary>
    [Display(Name = "Animation")]
    public class AnimationOptions : OptionsBase
    {
        /// <summary>
        /// The duration of the animation in milliseconds.
        /// Default '1000'.
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// <see cref="AnimationType"/>
        /// </summary>
        public AnimationType? Type { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Type}:{Duration}";
        }
    }
}

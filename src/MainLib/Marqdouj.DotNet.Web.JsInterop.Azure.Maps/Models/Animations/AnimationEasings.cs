using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Animations
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Easing functions supported by this library.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<AnimationEasing>))]
    public enum AnimationEasing
    {
        linear,
        easeInSine,
        easeOutSine,
        easeInOutSine,
        easeInQuad,
        easeOutQuad,
        easeInOutQuad,
        easeInCubic,
        easeOutCubic,
        easeInOutCubic,
        easeInQuart,
        easeOutQuart,
        easeInOutQuart,
        easeInQuint,
        easeOutQuint,
        easeInOutQuint,
        easeInExpo,
        easeOutExpo,
        easeInOutExpo,
        easeInCirc,
        easeOutCirc,
        easeInOutCirc,
        easeInBack,
        easeOutBack,
        easeInOutBack,
        easeInElastic,
        easeOutElastic,
        easeInOutElastic,
        easeOutBounce,
        easeInBounce,
        easeInOutBounce,
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

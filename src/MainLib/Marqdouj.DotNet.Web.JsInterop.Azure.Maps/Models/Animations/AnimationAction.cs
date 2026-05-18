using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Animations
{
    /// <summary>
    /// Animation Action supported by this library.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<AnimationAction>))]
    public enum AnimationAction
    {
        /// <summary>
        /// Animates the update of coordinates on a shape or htmlmarker. 
        /// Shapes will stay the same type. 
        /// Only base animation options supported for geometries other than point.
        /// </summary>
        SetCoordinates,
    }
}

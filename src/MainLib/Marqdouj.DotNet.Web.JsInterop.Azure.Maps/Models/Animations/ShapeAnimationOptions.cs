using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Animations
{
    /// <summary>
    /// Provides configuration options for animating a map feature, including the target shape, associated data source,
    /// animation action, and animation settings.
    /// </summary>
    /// <remarks>Use this class to specify how a map feature should be animated, including which feature to
    /// animate, the data source it belongs to, the type of animation action to perform, and animation parameters such
    /// as easing and duration. The class is typically used when initiating or customizing shape animations in mapping
    /// applications.</remarks>
    public class ShapeAnimationOptions
    {
        /// <summary>
        /// Initializes a new instance of the ShapeAnimationOptions class with the specified feature, data source
        /// identifier, animation action, and easing function.
        /// </summary>
        /// <param name="feature">The map feature definition to be animated. Cannot be null.</param>
        /// <param name="dataSourceId">The identifier of the data source associated with the feature. Cannot be null or empty.</param>
        /// <param name="action">The animation action to perform on the feature. Defaults to AnimationAction.SetCoordinates.</param>
        /// <param name="easing">The easing function to use for the animation. Defaults to AnimationEasing.linear.</param>
        public ShapeAnimationOptions(
            MapFeature feature,
            string dataSourceId,
            AnimationAction action = AnimationAction.SetCoordinates,
            AnimationEasing easing = AnimationEasing.linear)
        {
            Shape = feature;
            DataSourceId = dataSourceId;
            Action = action;
            AnimationOptions = new PlayableAnimationOptions { AutoPlay = true, Easing = easing, Duration = 1500 };
        }

        /// <summary>
        /// <inheritdoc cref="AnimationAction"/>
        /// </summary>
        public AnimationAction Action { get; }

        /// <summary>
        /// <inheritdoc cref="MapEditAction"/>
        /// </summary>
        public MapEditAction EditAction { get; set; } 

        /// <summary>
        /// The shape to animate.
        /// </summary>
        public MapFeature Shape { get; }

        /// <summary>
        /// datasource Id that contains the shape.
        /// </summary>
        public string DataSourceId { get; set; }

        /// <summary>
        /// <inheritdoc cref="PlayableAnimationOptions"/>
        /// </summary>
        public PlayableAnimationOptions AnimationOptions { get; set; }
    }
}

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Animations
{
    /// <summary>
    /// The set of supported interpolation strategies.
    /// </summary>
    public enum PointInterpolation
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        Linear,
        Nearest,
        Min,
        Max,
        Avg
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }

    /// <summary>
    /// Defines how the value of a property in two points is extrapolated.
    /// </summary>
    public class PointPairValueInterpolation(string propertyPath, PointInterpolation interpolation = PointInterpolation.Linear)
    {
        /// <summary>
        /// How the interpolation is performed. Certain interpolations require the data to be a certain value.
        /// Default: <see cref="PointInterpolation.Linear"/>
        /// </summary>
        public PointInterpolation Interpolation { get; } = interpolation;

        /// <summary>
        /// The path to the property with each sub-property separated with a forward slash "/",
        /// for example "property/subproperty1/subproperty2".
        /// Array indices can be added as sub-properties as well, for example "property/0".
        /// </summary>
        public string PropertyPath { get; } = propertyPath;
    }

    /// <summary>
    /// Options for animating the map along a path.
    /// </summary>
    public class RoutePathAnimationOptions
    {
        /// <summary>
        /// Interpolation calculations to perform on property values between points during the animation.
        /// Requires <see cref="CaptureMetadata"/> to be enabled.
        /// </summary>
        public List<PointPairValueInterpolation>? ValueInterpolations { get; set; }

        /// <summary>
        /// Specifies if metadata should be captured as properties of the shape.
        /// Potential metadata properties that may be captured: heading, speed, timestamp.
        /// </summary>
        public bool? CaptureMetadata { get; set; }

        /// <summary>
        /// Map to animate along a path.
        /// </summary>
        public string? MapId { get; set; }

        /// <summary>
        /// A fixed zoom level to snap the map to on each animation frame.
        /// By default the map's current zoom level is used.
        /// </summary>
        public double? Zoom { get; set; }

        /// <summary>
        /// A pitch value to set on the map. By default this is not set.
        /// </summary>
        public double? Pitch { get; set; }

        /// <summary>
        /// Specifies if the map should rotate such that the bearing of the map faces
        /// the direction the map is moving. Default: true.
        /// </summary>
        public bool? Rotate { get; set; }

        /// <summary>
        /// When <see cref="Rotate"/> is set to true, the animation will follow the animation.
        /// An offset of 180 will cause the camera to lead the animation and look back. Default: 0.
        /// </summary>
        public double? RotationOffset { get; set; }

        /// <summary>
        /// Specifies if the animation should start automatically or wait for the play function
        /// to be called. Default: false.
        /// </summary>
        public bool? AutoPlay { get; set; }

        /// <summary>
        /// Specifies if the animation should loop infinitely. Default: false.
        /// </summary>
        public bool? Loop { get; set; }

        /// <summary>
        /// Specifies if the animation should play backwards. Default: false.
        /// </summary>
        public bool? Reverse { get; set; }

        /// <summary>
        /// A multiplier of the duration to speed up or down the animation. Default: 1.
        /// </summary>
        public double? SpeedMultiplier { get; set; }
    }
}

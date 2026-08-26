namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Spatial
{
    /// <summary>
    /// <inheritdoc cref="GpxReadOptions"/>
    /// </summary>
    public interface IGpxReadOptions
    {
        /// <summary>
        /// <inheritdoc cref="GpxReadOptions.CapturePathWaypoints"/>
        /// </summary>
        bool? CapturePathWaypoints { get; set; }
    }

    /// <summary>
    /// Options that customize how GPX files are read and parsed.
    /// </summary>
    public class GpxReadOptions : BaseSpatialXmlReadOptions, IGpxReadOptions
    {
        /// <summary>
        /// Specifies wether the individual waypoint data of a GPX Route or Track should be captured.
        /// If set to true, the shape will have a metadata.waypoints property that is an array of
        /// pushpins that contains the details of each waypoint along the track.
        /// Default is 'false'.
        /// </summary>
        public bool? CapturePathWaypoints { get; set; }
    }
}

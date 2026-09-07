using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models.Atlas
{
    /// <summary>
    /// The properties object returned by
    /// <see cref="IAzureMapsMath.GetPointWithHeadingAlongPath{T}(T, double, DistanceUnits?)"/>
    /// </summary>
    public class HeadingProperties
    {
        /// <summary>
        /// A heading/bearing angle in degrees (0 = North, 90 = East, ...),
        /// pointing in the direction of travel along the path.
        /// </summary>
        public double Heading { get; set; }
    }
}

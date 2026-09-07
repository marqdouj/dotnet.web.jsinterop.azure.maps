using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models.Math
{
    /// <summary>
    /// The properties object returned by
    /// <see cref="IAzureMapsMath.GetClosestPointOnGeometry{TPoint, TGeom, P}(TPoint, TGeom, DistanceUnits?, double?)"/>
    /// </summary>
    public class DistanceProperties
    {
        /// <summary>
        /// Specifies the distance between the two points in the specified units.
        /// </summary>
        public double distance { get; set; }
    }
}

using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers;
using Marqdouj.DotNet.Web.JsInterop.GeoJson;
using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Functionality for working with Mercator projections and conversions between geographic coordinates and Mercator coordinates.
    /// </summary>
    public interface IAzureMapsMercators
    {
        /// <summary>
        /// Converts a position into a mercator point.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [Display(Name = "From Position")]
        ValueTask<MercatorPoint> FromPosition(Position position);

        /// <summary>
        /// Converts an array of positions into an array of mercator points.
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        [Display(Name = "From Positions")]
        ValueTask<List<MercatorPoint>> FromPositions(IEnumerable<Position> positions);

        /// <summary>
        /// Determine the Mercator scale factor for a given latitude.
        /// At the equator the scale factor will be 1, which increases at higher latitudes.
        /// <see href="https://en.wikipedia.org/wiki/Mercator_projection#Scale_factor"/>
        /// </summary>
        /// <param name="latitude"></param>
        /// <returns></returns>
        [Display(Name = "Mercator Scale")]
        ValueTask<double> MercatorScale(double latitude);

        /// <summary>
        /// Returns the distance of 1 meter in `MercatorPoint` units at this latitude.
        /// </summary>
        /// <remarks>For coordinates in real world units using meters, this naturally provides the scale to transform into `MercatorPoint`s.</remarks>
        /// <param name="latitude"></param>
        /// <returns>Distance of 1 meter in `MercatorPoint` units.</returns>
        [Display(Name = "Meter In Mercator Units")]
        ValueTask<double> MeterInMercatorUnits(double latitude);

        /// <summary>
        /// Converts an array of positions into a Float32Array of mercator xyz values.
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        [Display(Name = "To Float32 Array")]
        ValueTask<List<float>> ToFloat32Array(List<Position> positions);

        /// <summary>
        /// Converts a mercator point into a map position.
        /// </summary>
        /// <param name="mercator"></param>
        /// <returns></returns>
        [Display(Name = "To Position")]
        ValueTask<Position> ToPosition(MercatorPoint mercator);

        /// <summary>
        /// Converts an array of mercator points into an array of map positions.
        /// </summary>
        /// <param name="mercators"></param>
        /// <returns></returns>
        [Display(Name = "To Positions")]
        ValueTask<List<Position>> ToPositions(IEnumerable<MercatorPoint> mercators);
    }

    internal class AzMercators(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsMercators
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        #region FromPosition

        public async ValueTask<MercatorPoint> FromPosition(Position position)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<MercatorPoint>(GetJsInteropMethod(), position);
        }

        public async ValueTask<List<MercatorPoint>> FromPositions(IEnumerable<Position> positions)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<MercatorPoint>>(GetJsInteropMethod(), positions);
        }

        #endregion

        #region ToPosition

        public async ValueTask<Position> ToPosition(MercatorPoint mercator)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), mercator);
        }

        public async ValueTask<List<Position>> ToPositions(IEnumerable<MercatorPoint> mercators)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), mercators);
        }
        #endregion

        public async ValueTask<List<float>> ToFloat32Array(List<Position> positions)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<float>>(GetJsInteropMethod(), positions);
        }

        public async ValueTask<double> MercatorScale(double latitude)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), latitude);
        }

        public async ValueTask<double> MeterInMercatorUnits(double latitude)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), latitude);
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => ModuleExtensions.GetJsModuleMethod(JsModule.Mercators, name);
    }
}
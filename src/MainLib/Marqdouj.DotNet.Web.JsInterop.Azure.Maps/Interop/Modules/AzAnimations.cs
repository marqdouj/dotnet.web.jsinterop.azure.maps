using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Animations;
using Marqdouj.DotNet.Web.JsInterop.GeoJson;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Interface for Azure Maps Animations module, providing methods to animate shapes and retrieve easing function names.
    /// </summary>
    public interface IAzureMapsAnimations
    {
        /// <summary>
        /// Animates a shape on the map using the provided animation options.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        ValueTask AnimateShape(string mapId, ShapeAnimationOptions options);

        /// <summary>
        /// Extracts points from a shape or feature that form a time based route, and sorts them by time.
        /// Timestamps must parsable by the `atlas.math.parseTimestamp` function.
        /// Features must be a Point, MultiPoint, or LineString and must contain properties that include timestamp information.
        /// </summary>
        /// <param name="mapId">The map id.</param>
        /// <param name="shapeId">The shape id which contains the time based route.</param>
        /// <param name="length">The number of elements to return. -1 returns all elements.</param>
        /// <param name="timestampProperty">the property name that contains timestamp information.  If not specified, `_timestamp` will be used.</param>
        ValueTask<List<Feature<Point, object?>[]>?> ExtractRoutePoints(string mapId, string shapeId, int length, string? timestampProperty);

        /// <summary>
        /// Retrieves the name of all the built in easing functions.
        /// </summary>
        /// <param name="mapId"></param>
        /// <returns></returns>
        ValueTask<List<string>> GetEasingNames(string mapId);
    }

    internal class AzAnimations(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsAnimations
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask AnimateShape(string mapId, ShapeAnimationOptions options)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, options);
        }

        public async ValueTask<List<Feature<Point, object?>[]>?> ExtractRoutePoints(string mapId, string shapeId, int length, string? timestampProperty)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Feature<Point, object?>[]>?>(GetJsInteropMethod(), mapId, shapeId, length, timestampProperty);
        }

        public async ValueTask<List<string>> GetEasingNames(string mapId)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<string>>(GetJsInteropMethod(), mapId);
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.Animations.GetJsModuleMethod(name);
    }
}
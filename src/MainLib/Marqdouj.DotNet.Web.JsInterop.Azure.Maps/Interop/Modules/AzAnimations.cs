using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Animations;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events;
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
        /// <param name="timestampProperty">The property name that contains timestamp information.  If not specified, `_timestamp` will be used.</param>
        ValueTask<List<Feature<Point, object?>[]>?> ExtractRoutePoints(string mapId, string shapeId, int length, string? timestampProperty);

        /// <summary>
        /// Retrieves the name of all the built in easing functions.
        /// </summary>
        /// <param name="mapId"></param>
        /// <returns></returns>
        ValueTask<List<string>> GetEasingNames(string mapId);

        /// <summary>
        /// Animates a map and/or a Point shape along a route path. The movement will vary based on timestamps within the point feature properties. All points must have a `timestamp` property that is a `Date.getTime()` value.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task MoveAlongRoute(string mapId, MoveAlongRouteParameters parameters);
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

        public async Task MoveAlongRoute(string mapId, MoveAlongRouteParameters parameters)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, parameters);
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.Animations.GetJsModuleMethod(name);
    }

    /// <summary>
    /// MoveAlongRoute method parameters.
    /// </summary>
    /// <param name="animationId"><see cref="MoveAlongRouteParameters.AnimationId"/></param>
    /// <param name="routeSourceId"><see cref="MoveAlongRouteParameters.RouteSourceId"/></param>
    /// <param name="routeShapeId"><see cref="MoveAlongRouteParameters.RouteShapeId"/></param>
    /// <param name="shapeSourceId"><see cref="MoveAlongRouteParameters.ShapeSourceId"/></param>
    /// <param name="shapeId"><see cref="MoveAlongRouteParameters.ShapeId"/></param>
    /// <param name="events"><see cref="MoveAlongRouteParameters.Events"/></param>
    /// <param name="options"><see cref="MoveAlongRouteParameters.Options"/></param>
    /// <param name="timestampProperty"><see cref="MoveAlongRouteParameters.TimestampProperty"/></param>
    public class MoveAlongRouteParameters(string animationId, string routeSourceId, string? routeShapeId, string shapeSourceId, string shapeId, List<MapEvent>? events, RoutePathAnimationOptions? options, string? timestampProperty = null)
    {
        /// <summary>
        /// Id used to work with the animation created.
        /// </summary>
        public string AnimationId { get; } = animationId;

        /// <summary>
        /// Id for the DataSource that contains the route data.
        /// </summary>
        public string RouteSourceId { get; } = routeSourceId;

        /// <summary>
        /// The shape id that contains the route data. Default is the first shape found in the collection.
        /// </summary>
        public string? RouteShapeId { get; } = routeShapeId;

        /// <summary>
        /// Id for the Source that contains the shape.
        /// </summary>
        public string ShapeSourceId { get; } = shapeSourceId;

        /// <summary>
        /// Shape Id to animate along the route data.
        /// </summary>
        public string ShapeId { get; } = shapeId;

        /// <summary>
        /// Events for the animation.
        /// </summary>
        public List<MapEvent>? Events { get; } = events;

        /// <summary>
        /// <inheritdoc cref="PlayableAnimationOptions"/>
        /// </summary>
        public RoutePathAnimationOptions? Options { get; } = options;

        /// <summary>
        /// The property name that contains timestamp information.  If not specified, `_timestamp` will be used.
        /// </summary>
        public string? TimestampProperty { get; } = timestampProperty;

        /// <summary>
        /// Assign the map to the animation. Default is 'true'.
        /// </summary>
        public bool Follow { get; set; } = true;
    }
}
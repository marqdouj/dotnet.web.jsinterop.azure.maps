using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers;
using Marqdouj.DotNet.Web.JsInterop.GeoJson;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Interface for Azure Maps features interop methods.
    /// </summary>
    public interface IAzureMapsFeatures
    {
        /// <summary>
        /// Adds one or more features to a specified map and datasource. If the replace parameter is set to true, existing features with the same IDs will be replaced.
        /// </summary>
        /// <param name="mapId">The ID of the map.</param>
        /// <param name="features">The features to add.</param>
        /// <param name="datasourceId">The ID of the datasource.</param>
        /// <param name="replace">Whether to replace existing features with the same IDs.</param>
        ValueTask Add(string mapId, IEnumerable<MapFeature> features, string datasourceId, bool replace = false);

        /// <summary>
        /// Adds a single feature to a specified map and datasource. If the replace parameter is set to true, an existing feature with the same ID will be replaced.
        /// </summary>
        /// <param name="mapId">The ID of the map.</param>
        /// <param name="feature">The feature to add.</param>
        /// <param name="datasourceId">The ID of the datasource.</param>
        /// <param name="replace">Whether to replace an existing feature with the same ID.</param>
        /// <returns></returns>
        ValueTask Add(string mapId, MapFeature feature, string datasourceId, bool replace = false);

        /// <summary>
        /// Adds a property to a specified feature in a datasource.
        /// </summary>
        /// <param name="mapId">The ID of the map.</param>
        /// <param name="feature">The feature to which the property will be added.</param>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        /// <param name="datasourceId">The ID of the datasource.</param>
        ValueTask AddProperty(string mapId, MapFeature feature, string name, object? value, string datasourceId);

        /// <summary>
        /// Gets the coordinates of a specified feature in a datasource. The return type depends on the geometry type of the feature.
        /// </summary>
        /// <param name="mapId">The ID of the map.</param>
        /// <param name="feature">The feature whose coordinates will be retrieved.</param>
        /// <param name="datasourceId">The ID of the datasource.</param>
        /// <returns>The coordinates of the feature.</returns>
        ValueTask<object> GetCoordinates(string mapId, MapFeature feature, string datasourceId);

        /// <summary>
        /// Gets the properties of a specified feature in a datasource.
        /// </summary>
        /// <param name="mapId">The ID of the map.</param>
        /// <param name="feature">The feature whose properties will be retrieved.</param>
        /// <param name="datasourceId">The ID of the datasource.</param>
        /// <returns>The properties of the feature.</returns>
        ValueTask<Properties> GetProperties(string mapId, MapFeature feature, string datasourceId);

        /// <summary>
        /// Removes one or more features from a specified map and datasource.
        /// </summary>
        /// <param name="mapId">The ID of the map.</param>
        /// <param name="features">The features to remove.</param>
        /// <param name="datasourceId">The ID of the datasource.</param>
        ValueTask Remove(string mapId, IEnumerable<MapFeature> features, string datasourceId);

        /// <summary>
        /// Removes a single feature from a specified map and datasource.
        /// </summary>
        /// <param name="mapId">The ID of the map.</param>
        /// <param name="feature">The feature to remove.</param>
        /// <param name="datasourceId">The ID of the datasource.</param>
        /// <returns></returns>
        ValueTask Remove(string mapId, MapFeature feature, string datasourceId);

        /// <summary>
        /// Sets the coordinates of a specified feature in a datasource.
        /// </summary>
        /// <param name="mapId">The ID of the map.</param>
        /// <param name="feature">The feature whose coordinates will be set.</param>
        /// <param name="datasourceId">The ID of the datasource.</param>
        ValueTask SetCoordinates(string mapId, MapFeature feature, string datasourceId);

        /// <summary>
        /// Sets the properties of a specified feature in a datasource. If the replace parameter is set to true, existing properties will be replaced; otherwise, new properties will be added or existing ones updated.
        /// </summary>
        /// <param name="mapId">The ID of the map.</param>
        /// <param name="feature">The feature whose properties will be set.</param>
        /// <param name="datasourceId">The ID of the datasource.</param>
        /// <param name="replace">Whether to replace existing properties.</param>
        /// <returns></returns>
        ValueTask SetProperties(string mapId, MapFeature feature, string datasourceId, bool replace = false);

        /// <summary>
        /// Updates one or more features in a specified map and datasource.
        /// </summary>
        /// <param name="mapId">The ID of the map.</param>
        /// <param name="features">The features to be updated.</param>
        /// <param name="datasourceId">The ID of the datasource.</param>
        /// <returns></returns>
        ValueTask Update(string mapId, IEnumerable<MapFeature> features, string datasourceId);

        /// <summary>
        /// Updates a single feature in a specified map and datasource.
        /// </summary>
        /// <param name="mapId">The ID of the map.</param>
        /// <param name="feature">The feature to be updated.</param>
        /// <param name="datasourceId">The ID of the datasource.</param>
        /// <returns></returns>
        ValueTask Update(string mapId, MapFeature feature, string datasourceId);
    }

    internal class AzFeatures(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsFeatures
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask Add(string mapId, MapFeature feature, string datasourceId, bool replace = false)
        {
            await Add(mapId, [feature], datasourceId, replace);
        }

        public async ValueTask Add(string mapId, IEnumerable<MapFeature> features, string datasourceId, bool replace = false)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, features, datasourceId, replace);
        }

        public async ValueTask Update(string mapId, MapFeature feature, string datasourceId)
        {
            await Update(mapId, [feature], datasourceId);
        }

        public async ValueTask Update(string mapId, IEnumerable<MapFeature> features, string datasourceId)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, features, datasourceId);
        }

        public async ValueTask AddProperty(string mapId, MapFeature feature, string name, object? value, string datasourceId)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, feature.Id, name, value, datasourceId);
        }

        public async ValueTask<Properties> GetProperties(string mapId, MapFeature feature, string datasourceId)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Properties>(GetJsInteropMethod(), mapId, feature.Id, datasourceId);
        }

        public async ValueTask Remove(string mapId, MapFeature feature, string datasourceId)
        {
            await Remove(mapId, [feature], datasourceId);
        }

        public async ValueTask Remove(string mapId, IEnumerable<MapFeature> features, string datasourceId)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, features, datasourceId);
        }

        public async ValueTask SetProperties(string mapId, MapFeature feature, string datasourceId, bool replace = false)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, feature.Id, feature.Properties, datasourceId, replace);
        }

        public async ValueTask<object> GetCoordinates(string mapId, MapFeature feature, string datasourceId)
        {
            var module = await moduleTask.Value;
            return feature.GeometryType switch
            {
                GeometryType.Point => await module.InvokeAsync<Position>(GetJsInteropMethod(), mapId, feature.Id, datasourceId),
                GeometryType.MultiPoint => await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), mapId, feature.Id, datasourceId),
                GeometryType.LineString => await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), mapId, feature.Id, datasourceId),
                GeometryType.MultiLineString => await module.InvokeAsync<List<List<Position>>>(GetJsInteropMethod(), mapId, feature.Id, datasourceId),
                GeometryType.Polygon => await module.InvokeAsync<List<List<Position>>>(GetJsInteropMethod(), mapId, feature.Id, datasourceId),
                GeometryType.MultiPolygon => await module.InvokeAsync<List<List<List<Position>>>>(GetJsInteropMethod(), mapId, feature.Id, datasourceId),
                _ => throw new ArgumentOutOfRangeException(nameof(feature)),
            };
        }

        public async ValueTask SetCoordinates(string mapId, MapFeature feature, string datasourceId)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, feature.Id, feature.Coordinates, datasourceId);
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.Features.GetJsModuleMethod(name);
    }
}
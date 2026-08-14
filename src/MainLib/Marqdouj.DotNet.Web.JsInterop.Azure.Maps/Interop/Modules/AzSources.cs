using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Sources;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Interface for managing sources in Azure Maps. 
    /// Provides methods to add, remove, clear, and retrieve shapes from sources associated with a specific map.
    /// </summary>
    public interface IAzureMapsSources
    {
        /// <summary>
        /// Adds a collection of MapSource items to the specified map.
        /// </summary>
        /// <param name="mapId">The ID of the map to which the sources will be added.</param>
        /// <param name="items">The collection of MapSource items to add.</param>
        ValueTask Add(string mapId, IEnumerable<MapSource> items);

        /// <summary>
        /// Adds a single MapSource item to the specified map.
        /// </summary>
        /// <param name="mapId">The ID of the map to which the source will be added.</param>
        /// <param name="item">The MapSource item to add.</param>
        ValueTask Add(string mapId, MapSource item);

        /// <summary>
        /// Clears a collection of MapSource items from the specified map.
        /// </summary>
        /// <param name="mapId">The ID of the map from which the sources will be cleared.</param>
        /// <param name="items">The collection of MapSource items to clear.</param>
        ValueTask Clear(string mapId, IEnumerable<MapSource> items);

        /// <summary>
        /// Clears a single MapSource item from the specified map.
        /// </summary>
        /// <param name="mapId">The ID of the map from which the source will be cleared.</param>
        /// <param name="item">The MapSource item to clear.</param>
        ValueTask Clear(string mapId, MapSource item);


        /// <summary>
        /// Clears a collection of MapSource items from the specified map by their IDs.
        /// </summary>
        /// <param name="mapId">The ID of the map from which the sources will be cleared.</param>
        /// <param name="sourceIds">The collection of source IDs to clear.</param>
        ValueTask ClearById(string mapId, IEnumerable<string> sourceIds);


        /// <summary>
        /// Retrieves the shapes from a specific source on the specified map.
        /// </summary>
        /// <param name="mapId">The ID of the map from which to retrieve shapes.</param>
        /// <param name="sourceId">The ID of the source from which to retrieve shapes.</param>
        ValueTask<List<MapEventShape>> GetShapes(string mapId, string sourceId);

        /// <summary>
        /// Downloads a GeoJSON document and imports its data into the data source.
        /// The GeoJSON document must be on the same domain or accessible using CORS.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="sourceId"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        ValueTask ImportDataFromUrl(string mapId, string sourceId, string url);

        /// <summary>
        /// Removes a collection of MapSource items from the specified map.
        /// </summary>
        /// <param name="mapId">The ID of the map from which the sources will be removed.</param>
        /// <param name="items">The collection of MapSource items to remove.</param>
        ValueTask Remove(string mapId, IEnumerable<MapSource> items);

        /// <summary>
        /// Removes a single MapSource item from the specified map.
        /// </summary>
        /// <param name="mapId">The ID of the map from which the source will be removed.</param>
        /// <param name="item">The MapSource item to remove.</param>
        ValueTask Remove(string mapId, MapSource item);

        /// <summary>
        /// Removes a collection of MapSource items from the specified map by their IDs.
        /// </summary>
        /// <param name="mapId">The ID of the map from which the sources will be removed.</param>
        /// <param name="sourceIds">The collection of source IDs to remove.</param>
        ValueTask RemoveById(string mapId, IEnumerable<string> sourceIds);
    }

    internal class AzSources(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsSources
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask Add(string mapId, MapSource item)
        {
            await Add(mapId, [item]);
        }

        public async ValueTask ImportDataFromUrl(string mapId, string sourceId, string url)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, sourceId, url);
        }

        public async ValueTask Remove(string mapId, MapSource item)
        {
            await Remove(mapId, [item]);
        }

        public async ValueTask Clear(string mapId, MapSource item)
        {
            await Clear(mapId, [item]);
        }

        public async ValueTask Add(string mapId, IEnumerable<MapSource> items)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, items?.Cast<object>().ToList());
        }

        public async ValueTask Remove(string mapId, IEnumerable<MapSource> items)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, items?.Cast<object>().ToList());
        }

        public async ValueTask RemoveById(string mapId, IEnumerable<string> sourceIds)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, sourceIds);
        }

        public async ValueTask Clear(string mapId, IEnumerable<MapSource> items)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, items?.Cast<object>().ToList());
        }

        public async ValueTask ClearById(string mapId, IEnumerable<string> sourceIds)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, sourceIds);
        }

        public async ValueTask<List<MapEventShape>> GetShapes(string mapId, string sourceId)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<MapEventShape>>(GetJsInteropMethod(), mapId, sourceId);
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.Sources.GetJsModuleMethod(name);
    }
}
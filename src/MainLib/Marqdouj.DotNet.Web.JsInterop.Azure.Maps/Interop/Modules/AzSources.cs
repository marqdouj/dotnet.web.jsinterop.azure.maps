using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers;
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
        /// Adds a collection of LayerSourceBase items to the specified map.
        /// </summary>
        /// <param name="mapId">The ID of the map to which the sources will be added.</param>
        /// <param name="items">The collection of LayerSourceBase items to add.</param>
        ValueTask Add(string mapId, IEnumerable<LayerSourceBase> items);

        /// <summary>
        /// Adds a single LayerSourceBase item to the specified map.
        /// </summary>
        /// <param name="mapId">The ID of the map to which the source will be added.</param>
        /// <param name="item">The LayerSourceBase item to add.</param>
        ValueTask Add(string mapId, LayerSourceBase item);

        /// <summary>
        /// Clears a collection of LayerSourceBase items from the specified map.
        /// </summary>
        /// <param name="mapId">The ID of the map from which the sources will be cleared.</param>
        /// <param name="items">The collection of LayerSourceBase items to clear.</param>
        ValueTask Clear(string mapId, IEnumerable<LayerSourceBase> items);

        /// <summary>
        /// Clears a single LayerSourceBase item from the specified map.
        /// </summary>
        /// <param name="mapId">The ID of the map from which the source will be cleared.</param>
        /// <param name="item">The LayerSourceBase item to clear.</param>
        ValueTask Clear(string mapId, LayerSourceBase item);


        /// <summary>
        /// Clears a collection of LayerSourceBase items from the specified map by their IDs.
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
        /// Removes a collection of LayerSourceBase items from the specified map.
        /// </summary>
        /// <param name="mapId">The ID of the map from which the sources will be removed.</param>
        /// <param name="items">The collection of LayerSourceBase items to remove.</param>
        ValueTask Remove(string mapId, IEnumerable<LayerSourceBase> items);

        /// <summary>
        /// Removes a single LayerSourceBase item from the specified map.
        /// </summary>
        /// <param name="mapId">The ID of the map from which the source will be removed.</param>
        /// <param name="item">The LayerSourceBase item to remove.</param>
        ValueTask Remove(string mapId, LayerSourceBase item);

        /// <summary>
        /// Removes a collection of LayerSourceBase items from the specified map by their IDs.
        /// </summary>
        /// <param name="mapId">The ID of the map from which the sources will be removed.</param>
        /// <param name="sourceIds">The collection of source IDs to remove.</param>
        ValueTask RemoveById(string mapId, IEnumerable<string> sourceIds);
    }

    internal class AzSources(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsSources
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask Add(string mapId, LayerSourceBase item)
        {
            await Add(mapId, [item]);
        }

        public async ValueTask Remove(string mapId, LayerSourceBase item)
        {
            await Remove(mapId, [item]);
        }

        public async ValueTask Clear(string mapId, LayerSourceBase item)
        {
            await Clear(mapId, [item]);
        }

        public async ValueTask Add(string mapId, IEnumerable<LayerSourceBase> items)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, items?.Cast<object>().ToList());
        }

        public async ValueTask Remove(string mapId, IEnumerable<LayerSourceBase> items)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, items?.Cast<object>().ToList());
        }

        public async ValueTask RemoveById(string mapId, IEnumerable<string> sourceIds)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, sourceIds);
        }

        public async ValueTask Clear(string mapId, IEnumerable<LayerSourceBase> items)
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
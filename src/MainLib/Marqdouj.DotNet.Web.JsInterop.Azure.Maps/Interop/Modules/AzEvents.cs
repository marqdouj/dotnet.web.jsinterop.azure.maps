using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Interface for Azure Maps events interop.
    /// </summary>
    public interface IAzureMapsEvents
    {
        /// <summary>
        /// Adds a collection of event definitions to the specified map.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        ValueTask Add(string mapId, IEnumerable<MapEvent> items);

        /// <summary>
        /// Adds a single event definition to the specified map.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        ValueTask Add(string mapId, MapEvent item);

        /// <summary>
        /// Removes a collection of event definitions from the specified map.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        ValueTask Remove(string mapId, IEnumerable<MapEvent> items);

        /// <summary>
        /// Removes a single event definition from the specified map.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        ValueTask Remove(string mapId, MapEvent item);
    }

    internal class AzEvents(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsEvents
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask Add(string mapId, MapEvent item)
        {
            await Add(mapId, [item]);
        }

        public async ValueTask Remove(string mapId, MapEvent item)
        {
            await Remove(mapId, [item]);
        }

        public async ValueTask Add(string mapId, IEnumerable<MapEvent> items)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, items?.Cast<object>().ToList());
        }

        public async ValueTask Remove(string mapId, IEnumerable<MapEvent> items)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, items?.Cast<object>().ToList());
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.Events.GetJsModuleMethod(name);
    }
}
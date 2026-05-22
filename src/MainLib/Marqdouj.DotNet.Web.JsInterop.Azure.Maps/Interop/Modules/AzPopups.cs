using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Interface for Azure Maps Popups interop methods.
    /// </summary>
    public interface IAzureMapsPopups
    {
        /// <summary>
        /// Adds a collection of popups to the map.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        ValueTask Add(string mapId, IEnumerable<Popup> items);

        /// <summary>
        /// Adds a single popup to the map.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        ValueTask Add(string mapId, Popup item);

        /// <summary>
        /// Removes a collection of popups from the map.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        ValueTask Remove(string mapId, IEnumerable<Popup> items);

        /// <summary>
        /// Removes a single popup from the map.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        ValueTask Remove(string mapId, Popup item);

        /// <summary>
        /// Opens/Closes the popup based on the <inheritdoc cref="Popup.Show"/> property.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        ValueTask Show(string mapId, IEnumerable<Popup> items);
    }

    internal class AzPopups(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsPopups
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask Add(string mapId, Popup item)
        {
            await Add(mapId, [item]);
        }

        public async ValueTask Remove(string mapId, Popup item)
        {
            await Remove(mapId, [item]);
        }

        public async ValueTask Add(string mapId, IEnumerable<Popup> items)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, items?.Cast<object>().ToList());
        }

        public async ValueTask Remove(string mapId, IEnumerable<Popup> items)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, items?.Cast<object>().ToList());
        }

        public async ValueTask Show(string mapId, IEnumerable<Popup> items)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, items?.Cast<object>().ToList());
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.Popups.GetJsModuleMethod(name);
    }
}
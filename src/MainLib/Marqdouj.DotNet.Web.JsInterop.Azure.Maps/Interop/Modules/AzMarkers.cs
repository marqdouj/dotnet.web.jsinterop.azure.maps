using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Interface for Azure Maps Markers interop methods.
    /// </summary>
    public interface IAzureMapsMarkers
    {
        /// <summary>
        /// Adds one or more HTML markers to the specified map.
        /// </summary>
        /// <param name="mapId">The ID of the map.</param>
        /// <param name="items">The HTML markers to add.</param>
        /// <param name="events">Optional events to attach to the markers.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        ValueTask Add(string mapId, IEnumerable<HtmlMarker> items, IEnumerable<MapEvent>? events = null);

        /// <summary>
        /// Adds events to one or more HTML markers on the specified map.
        /// </summary>
        /// <param name="mapId">The ID of the map.</param>
        /// <param name="items">The HTML markers to which events will be added.</param>
        /// <param name="events">The events to add to the markers.</param>
        ValueTask AddEvents(string mapId, IEnumerable<HtmlMarker> items, IEnumerable<MapEvent> events);

        /// <summary>
        /// Adds a single HTML marker to the specified map.
        /// </summary>
        /// <param name="mapId">The ID of the map.</param>
        /// <param name="item">The HTML marker to add.</param>
        /// <param name="events">Optional events to attach to the marker.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        ValueTask Add(string mapId, HtmlMarker item, IEnumerable<MapEvent>? events = null);

        /// <summary>
        /// Removes one or more HTML markers from the specified map.
        /// </summary>
        /// <param name="mapId">The ID of the map.</param>
        /// <param name="items">The HTML markers to remove.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        ValueTask Remove(string mapId, IEnumerable<HtmlMarker> items);

        /// <summary>
        /// Removes a single HTML marker from the specified map.
        /// </summary>
        /// <param name="mapId">The ID of the map.</param>
        /// <param name="item">The HTML marker to remove.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        ValueTask Remove(string mapId, HtmlMarker item);

        /// <summary>
        /// Removes events from one or more HTML markers on the specified map.
        /// </summary>
        /// <param name="mapId">The ID of the map.</param>
        /// <param name="items">The HTML markers from which events will be removed.</param>
        /// <param name="events">The events to remove from the markers.</param>
        ValueTask RemoveEvents(string mapId, IEnumerable<HtmlMarker> items, IEnumerable<MapEvent> events);
    }

    internal class AzMarkers(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsMarkers
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask Add(string mapId, HtmlMarker item, IEnumerable<MapEvent>? events = null)
        {
            await Add(mapId, [item], events);
        }

        public async ValueTask Add(string mapId, IEnumerable<HtmlMarker> items, IEnumerable<MapEvent>? events = null)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, items?.Cast<object>().ToList(), events?.Cast<object>().ToList());
        }

        public async ValueTask AddEvents(string mapId, IEnumerable<HtmlMarker> items, IEnumerable<MapEvent> events)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, items.Cast<object>().ToList(), events.Cast<object>().ToList());
        }

        public async ValueTask Remove(string mapId, HtmlMarker item)
        {
            await Remove(mapId, [item]);
        }

        public async ValueTask Remove(string mapId, IEnumerable<HtmlMarker> items)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, items?.Cast<object>().ToList());
        }

        public async ValueTask RemoveEvents(string mapId, IEnumerable<HtmlMarker> items, IEnumerable<MapEvent> events)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, items.Cast<object>().ToList(), events.Cast<object>().ToList());
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.Markers.GetJsModuleMethod(name);
    }
}
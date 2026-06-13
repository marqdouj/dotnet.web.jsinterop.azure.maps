using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Functionality for working with map layers.
    /// </summary>
    public interface IAzureMapsLayers
    {
        /// <summary>
        /// Adds the specified layer groups to the map, optionally associating map events with the layers.
        /// </summary>
        /// <param name="mapId">The unique identifier of the map to which the layers will be added. Cannot be null or empty.</param>
        /// <param name="groups">The collection of layer groups to add to the map. Cannot be null and must contain at least one item.</param>
        ValueTask AddGroups(string mapId, IEnumerable<LayerGroup> groups);

        /// <summary>
        /// Adds the specified layer group to the map, optionally associating map events with the group.
        /// </summary>
        /// <param name="mapId">The unique identifier of the map to which the layer group will be added. Cannot be null or empty.</param>
        /// <param name="group">The layer group to add to the map. Cannot be null.</param>
        ValueTask AddGroup(string mapId, LayerGroup group);

        /// <summary>
        /// Adds the specified layer to the map, optionally associating map events with
        /// the layer.
        /// </summary>
        /// <param name="mapId">The unique identifier of the map to which the layer will be added. Cannot be null or empty.</param>
        /// <param name="item">The layer to add to the map. Cannot be null.</param>
        /// <param name="events">An optional collection of map event definitions to associate with the layer. If null, no events are
        /// associated.</param>
        ValueTask Add(string mapId, ILayer item, IEnumerable<MapEvent>? events = null);

        /// <summary>
        /// Retrieves the options for a specified map layer definition.
        /// </summary>
        /// <param name="mapId">The unique identifier of the map for which to retrieve layer options. Cannot be null or empty.</param>
        /// <param name="layerDef">The layer definition for which to obtain options. Cannot be null.</param>
        ValueTask<LayerOptionsBase?> GetOptions(string mapId, ILayer layerDef);

        /// <summary>
        /// Removes the specified layers from the map.   
        /// </summary>
        /// <param name="mapId">The unique identifier of the map from which the layers will be removed. Cannot be null or empty.</param>
        /// <param name="items">The collection of layers to remove from the map. Cannot be null and must contain at least one item.</param>
        /// <param name="removeDataSource">A boolean value indicating whether the associated data sources should also be removed. Default is true.</param>
        ValueTask Remove(string mapId, IEnumerable<ILayer> items, bool removeDataSource = true);

        /// <summary>
        /// Removes the specified layer from the map.
        /// </summary>
        /// <param name="mapId">The unique identifier of the map from which the layer will be removed. Cannot be null or empty.</param>
        /// <param name="item">The layer to remove from the map. Cannot be null.</param>
        /// <param name="removeDataSource">A boolean value indicating whether the associated data sources should also be removed. Default is true.</param>
        ValueTask Remove(string mapId, ILayer item, bool removeDataSource = true);

        /// <summary>
        /// Removes the layers with the specified IDs from the map.
        /// </summary>
        /// <param name="mapId">The unique identifier of the map from which the layers will be removed. Cannot be null or empty.</param>
        /// <param name="layers">The collection of layer IDs to remove from the map. Cannot be null and must contain at least one item.</param>
        ValueTask RemoveById(string mapId, IEnumerable<string> layers);

        /// <summary>
        /// Sets the options for a specified map layer definition.
        /// </summary>
        /// <param name="mapId">The unique identifier of the map for which to set layer options. Cannot be null or empty.</param>
        /// <param name="layerDef">The layer definition for which to set options. Cannot be null.</param>
        ValueTask SetOptions(string mapId, ILayer layerDef);

        /// <summary>
        /// Shows or hides a specified layer on the map.
        /// </summary>
        /// <param name="mapId">The unique identifier of the map for which to show or hide the layer. Cannot be null or empty.</param>
        /// <param name="source">The layer to show or hide. Cannot be null.</param>
        /// <param name="visible">A boolean value indicating whether the layer should be visible (true) or hidden (false).</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        ValueTask ShowLayer(string mapId, ILayer source, bool visible);

        /// <summary>
        /// Adds a hover popup to a specified layer on the map, which will be displayed when the user hovers over a shape.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="layerId"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        ValueTask AddHoverPopup(string mapId, string layerId, Popup def);
    }

    internal class AzLayers(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsLayers
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask AddGroups(string mapId, IEnumerable<LayerGroup> groups)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, groups);
        }

        public async ValueTask AddGroup(string mapId, LayerGroup group)
        {
            await AddGroups(mapId, [group]);
        }

        public async ValueTask AddHoverPopup(string mapId, string layerId, Popup def)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, layerId, def);
        }

        public async ValueTask Add(string mapId, ILayer item, IEnumerable<MapEvent>? events = null)
        {
            await AddGroups(mapId, [new LayerGroup(item, events)]);
        }

        public async ValueTask<LayerOptionsBase?> GetOptions(string mapId, ILayer layerDef)
        {
            var module = await moduleTask.Value;
            var layerId = layerDef.Id;

            return layerDef.Type switch
            {
                LayerType.Bubble => await module.InvokeAsync<BubbleLayerOptions>(GetJsInteropMethod(), mapId, layerId),
                LayerType.HeatMap => await module.InvokeAsync<HeatMapLayerOptions>(GetJsInteropMethod(), mapId, layerId),
                LayerType.Image => await module.InvokeAsync<ImageLayerOptions>(GetJsInteropMethod(), mapId, layerId),
                LayerType.Line => await module.InvokeAsync<LineLayerOptions>(GetJsInteropMethod(), mapId, layerId),
                LayerType.Polygon => await module.InvokeAsync<PolygonLayerOptions>(GetJsInteropMethod(), mapId, layerId),
                LayerType.PolygonExtrusion => await module.InvokeAsync<PolygonExtrusionLayerOptions>(GetJsInteropMethod(), mapId, layerId),
                LayerType.Symbol => await module.InvokeAsync<SymbolLayerOptions>(GetJsInteropMethod(), mapId, layerId),
                LayerType.Tile => await module.InvokeAsync<TileLayerOptions>(GetJsInteropMethod(), mapId, layerId),
                _ => null,
            };
        }

        public async ValueTask Remove(string mapId, IEnumerable<ILayer> items, bool removeDataSource = true)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, items?.Cast<object>().ToList(), removeDataSource);
        }

        public async ValueTask Remove(string mapId, ILayer item, bool removeDataSource = true)
        {
            await Remove(mapId, [item], removeDataSource);
        }

        public async ValueTask RemoveById(string mapId, IEnumerable<string> layers)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, layers);
        }

        public async ValueTask SetOptions(string mapId, ILayer layerDef)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, layerDef);
        }

        public async ValueTask ShowLayer(string mapId, ILayer source, bool visible)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, source.Id, visible);
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.Layers.GetJsModuleMethod(name);
    }
}
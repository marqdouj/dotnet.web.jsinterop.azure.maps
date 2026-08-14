using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Sources;
using Marqdouj.DotNet.Web.JsInterop.GeoJson;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Functionality for working with maps configuration.
    /// </summary>
    public interface IAzureMapsConfiguration
    {
        /// <summary>
        /// Disables elevation on the map.
        /// </summary>
        /// <returns></returns>
        ValueTask DisableElevation(string mapId);

        /// <summary>
        /// Enables elevation on the map with the specified elevation source and optional exaggeration factor.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="elevationSource"></param>
        /// <param name="exaggeration"></param>
        /// <returns></returns>
        ValueTask EnableElevation(string mapId, ElevationTileSource elevationSource, double? exaggeration = null);

        /// <summary>
        /// Enables elevation on the map with the specified elevation source and optional exaggeration factor.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="elevationSource"></param>
        /// <param name="exaggeration"></param>
        /// <returns></returns>
        ValueTask EnableElevation(string mapId, string elevationSource, double? exaggeration = null);

        /// <summary>
        /// Gets the existing map options based on <see cref="MapOptionsArgs"/>
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="args"><see cref="MapOptionsArgs"/>. If null then all options are retrieved.</param>
        /// <returns></returns>
        ValueTask<MapOptions?> GetMapOptions(string mapId, MapOptionsArgs? args = null);

        /// <summary>
        /// Updates the map options.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="mapOptions"><see cref="MapOptions"/></param>
        /// <returns></returns>
        ValueTask SetMapOptions(string mapId, MapOptionsEdit mapOptions);

        /// <summary>
        /// Sets the map view to the specified center and zoom level, optionally with animation.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="center"></param>
        /// <param name="zoomLevel"></param>
        /// <param name="animation"></param>
        /// <returns></returns>
        ValueTask ZoomTo(string mapId, Position center, double? zoomLevel, AnimationOptions? animation = null);
    }

    internal class AzConfiguration(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsConfiguration
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask<MapOptions?> GetMapOptions(string mapId, MapOptionsArgs? args = null)
        {
            var module = await moduleTask.Value;
            var result = await module.InvokeAsync<MapOptionsGet>(GetJsInteropMethod(), mapId, args ?? new());
            return result.ToMapOptions();
        }

        public async ValueTask SetMapOptions(string mapId, MapOptionsEdit mapOptions)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, mapOptions);
        }

        public async ValueTask ZoomTo(string mapId, Position center, double? zoomLevel, AnimationOptions? animation = null)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, center, zoomLevel, animation);
        }

        public async ValueTask DisableElevation(string mapId)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId);
        }

        public async ValueTask EnableElevation(string mapId, ElevationTileSource elevationSource, double? exaggeration = null)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, elevationSource, exaggeration);
        }

        public async ValueTask EnableElevation(string mapId, string elevationSource, double? exaggeration = null)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, elevationSource, exaggeration);
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.Configuration.GetJsModuleMethod(name);
    }
}
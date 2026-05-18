using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;
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
        /// Gets the existing map options based on <see cref="MapOptionsArgs"/>
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="args"><see cref="MapOptionsArgs"/></param>
        /// <returns></returns>
        ValueTask<MapOptions?> GetMapOptions(string mapId, MapOptionsArgs args);

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

        public async ValueTask<MapOptions?> GetMapOptions(string mapId, MapOptionsArgs args)
        {
            var module = await moduleTask.Value;
            var result = await module.InvokeAsync<MapOptionsGet>(GetJsInteropMethod(), mapId, args);
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

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.Configuration.GetJsModuleMethod(name);

    }
}
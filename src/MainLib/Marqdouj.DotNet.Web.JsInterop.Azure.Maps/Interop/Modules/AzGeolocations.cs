using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Geolocation;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Interface for Azure Maps Geolocations JavaScript interop methods.
    /// </summary>
    public interface IAzureMapsGeolocations
    {
        /// <summary>
        /// Clears the watch on the geolocation.
        /// </summary>
        /// <returns></returns>
        ValueTask ClearWatch();

        /// <summary>
        /// Gets the current geolocation of the user.
        /// </summary>
        /// <param name="options">The options for retrieving the geolocation.</param>
        /// <returns>The current geolocation of the user.</returns>
        ValueTask<GeolocationResult> GetLocation(PositionOptions? options);

        /// <summary>
        /// Gets a value indicating whether the geolocation is being watched.
        /// </summary>
        /// <returns><c>true</c> if the geolocation is being watched; otherwise, <c>false</c>.</returns>
        ValueTask<bool> IsWatched();

        /// <summary>
        /// Watches the geolocation of the user.
        /// </summary>
        /// <param name="options">The options for watching the geolocation.</param>
        /// <returns>The ID of the watch operation.</returns>
        ValueTask<int?> WatchPosition(PositionOptions? options = null);
    }

    internal class AzGeolocations(Lazy<Task<IJSObjectReference>> moduleTask, DotNetObjectReference<ComponentBase> dotNetRef) : IAzureMapsGeolocations
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;
        private readonly DotNetObjectReference<ComponentBase> dotNetRef = dotNetRef;

        public async ValueTask<GeolocationResult> GetLocation(PositionOptions? options)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<GeolocationResult>(GetJsInteropMethod(), options);
        }

        public async ValueTask<int?> WatchPosition(PositionOptions? options = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<int?>(GetJsInteropMethod(), dotNetRef, options);
        }

        public async ValueTask ClearWatch()
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), dotNetRef);
        }

        public async ValueTask<bool> IsWatched()
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<bool>(GetJsInteropMethod(), dotNetRef);
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.Geolocations.GetJsModuleMethod(name);
    }
}
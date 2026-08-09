using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Interface for Azure Maps global interactions.
    /// </summary>
    /// <remarks>Global settings are applied to all Azure Maps instances 
    /// that are created after the setting is applied. Settings can be changed at any time
    /// for each individual instance by changing the map's style.</remarks>
    public interface IAzureMapsAtlas
    {
        /// <summary>
        /// Gets the current API version number based on build number.
        /// </summary>
        /// <returns></returns>
        ValueTask<string> GetVersion();

        /// <summary>
        /// Sets the default language used by the map and service modules..
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        ValueTask SetLanguage(string language);

        /// <summary>
        /// Specifies which set of geopolitically disputed borders and labels are displayed on the map.
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        ValueTask SetView(string view);
    }

    internal class AzAtlas(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsAtlas
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask<string> GetVersion()
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<string>(GetJsInteropMethod());
        }

        public async ValueTask SetLanguage(string language)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), language);
        }

        public async ValueTask SetView(string view)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), view);
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.Atlas.GetJsModuleMethod(name);
    }
}

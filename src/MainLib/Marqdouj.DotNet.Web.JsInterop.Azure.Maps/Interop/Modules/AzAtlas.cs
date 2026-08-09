using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Interface for Azure Maps global interactions.
    /// </summary>
    public interface IAzureMapsAtlas
    {
        /// <summary>
        /// Sets the language for the Azure Maps.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        ValueTask SetLanguage(string language);

        /// <summary>
        /// Sets the view for the Azure Maps.
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        ValueTask SetView(string view);
    }

    internal class AzAtlas(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsAtlas
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

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

using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Animations;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Interface for Azure Maps Animations module, providing methods to animate shapes and retrieve easing function names.
    /// </summary>
    public interface IAzureMapsAnimations
    {
        /// <summary>
        /// Animates a shape on the map using the provided animation options.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        ValueTask AnimateShape(string mapId, ShapeAnimationOptions options);

        /// <summary>
        /// Retrieves the name of all the built in easing functions.
        /// </summary>
        /// <param name="mapId"></param>
        /// <returns></returns>
        ValueTask<List<string>> GetEasingNames(string mapId);
    }

    internal class AzAnimations(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsAnimations
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask<List<string>> GetEasingNames(string mapId)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<string>>(GetJsInteropMethod(), mapId);
        }

        public async ValueTask AnimateShape(string mapId, ShapeAnimationOptions options)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, options);
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.Animations.GetJsModuleMethod(name);
    }
}
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Controls;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Functionality for working with MapControls.
    /// </summary>
    public interface IAzureMapsControls
    {
        /// <summary>
        /// Add controls.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="controls"></param>
        /// <returns></returns>
        ValueTask Add(string mapId, IEnumerable<ControlBase> controls);

        /// <summary>
        /// Add a control.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        ValueTask Add(string mapId, ControlBase control);

        /// <summary>
        /// Remove controls.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="controls"></param>
        /// <returns></returns>
        ValueTask Remove(string mapId, IEnumerable<ControlBase> controls);

        /// <summary>
        /// Remove a control.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        ValueTask Remove(string mapId, ControlBase control);
    }

    internal class AzControls(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsControls
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask Add(string mapId, ControlBase control)
        {
            await Add(mapId, [control]);
        }

        public async ValueTask Add(string mapId, IEnumerable<ControlBase> controls)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, controls.Cast<object>());
        }

        public async ValueTask Remove(string mapId, ControlBase control)
        {
            await Remove(mapId, [control]);
        }

        public async ValueTask Remove(string mapId, IEnumerable<ControlBase> controls)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, controls.Cast<object>());
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.Controls.GetJsModuleMethod(name);
    }
}
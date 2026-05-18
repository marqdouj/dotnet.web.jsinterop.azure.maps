using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Interface for Azure Maps Common module.
    /// </summary>
    public interface IAzureMapsCommon
    {
        /// <summary>
        /// Copies the text to the navigator clipboard.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        ValueTask<CopyTextResult> CopyTextToClipboard(string text);
    }

    internal class AzCommon(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsCommon
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask<CopyTextResult> CopyTextToClipboard(string text)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<CopyTextResult>(GetJsInteropMethod(), text);
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.Common.GetJsModuleMethod(name);
    }

    /// <summary>
    /// Result from <see cref="IAzureMapsCommon.CopyTextToClipboard(string)"/>
    /// </summary>
    public class CopyTextResult
    {
        /// <summary>
        /// Indicates the copy operation was a success.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Message returned by the operation.
        /// </summary>
        public string? Message { get; set; }
    }
}
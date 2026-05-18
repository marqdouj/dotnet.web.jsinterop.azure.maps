using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Sandbox.Azure.Maps
{
    // This class provides an example of how JavaScript functionality can be wrapped
    // in a .NET class for easy consumption. The associated JavaScript module is
    // loaded on demand when first needed.
    //
    // This class can be registered as scoped DI service and then injected into Blazor
    // components for use.

    public class SandboxMapsInterop(IJSRuntime jsRuntime) : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Sandbox.Azure.Maps/azureMaps.js").AsTask());
        
        public bool ControlsWereLoaded { get; private set; }

        public async ValueTask AddControls(IJSObjectReference azmap)
        {
            if (!ControlsWereLoaded)
            {
                var module = await moduleTask.Value;
                await module.InvokeVoidAsync(GetCustomMapMethod(), azmap);
                ControlsWereLoaded = true;
            }
        }

        public async ValueTask RemoveControls(IJSObjectReference azmap)
        {
            if (ControlsWereLoaded)
            {
                var module = await moduleTask.Value;
                await module.InvokeVoidAsync(GetCustomMapMethod(), azmap);
                ControlsWereLoaded = false;
            }
        }

        internal static string GetCustomMapMethod([CallerMemberName] string name = "")
        {
            return name.ToJsonName();
        }

        public async ValueTask DisposeAsync()
        {
            try
            {
                if (moduleTask.IsValueCreated)
                {
                    var module = await moduleTask.Value;
                    await module.DisposeAsync();
                }
            }
            catch (JSDisconnectedException)
            {
            }
        }
    }

    internal static class Extensions
    {
        /// <summary>
        /// first char must be lowercase
        /// </summary>
        public static string ToJsonName(this string name)
        {
            var firstChar = name[0].ToString().ToLower();
            var remainder = name[1..];
            return $"{firstChar}{remainder}";
        }
    }
}

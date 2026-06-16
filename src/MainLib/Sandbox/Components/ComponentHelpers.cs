using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using Sandbox.UI.Models;

namespace Sandbox.Components
{
    internal static class ComponentHelpers
    {
        public static async Task HandleInitializeError(this ILogger logger, Exception ex, IToastService? toastService = null) 
        {
            logger.LogError(ex, "An error occurred while initializing this page.");

            if (toastService != null)
                await toastService.ShowError("An error occurred while initializing this page.");
        }
    }
}

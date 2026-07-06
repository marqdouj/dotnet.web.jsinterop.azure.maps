using Microsoft.FluentUI.AspNetCore.Components;
using Sandbox.UI.Models;

namespace Sandbox.Components
{
    internal static class ComponentHelpers
    {
        public static async Task HandleErrorWithToast(this ILogger logger, Exception ex, INotificationService? toastService = null) 
        {
            logger.LogError(ex, "An unexpected error has occurred.");

            if (toastService != null)
                await toastService.ShowError($"An unexpected error has occurred: {ex.Message}");
        }

        public static async Task HandleWarningWithToast(this ILogger logger, string message, INotificationService? toastService = null)
        {
            logger.LogWarning(message);
            if (toastService != null)
                await toastService.ShowWarning(message);
        }
    }
}

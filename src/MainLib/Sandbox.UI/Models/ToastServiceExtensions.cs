using Microsoft.FluentUI.AspNetCore.Components;
using Icons = Microsoft.FluentUI.AspNetCore.Components.Icons;

namespace Sandbox.UI.Models
{
    public static class ToastServiceExtensions
    {
        private static readonly Icon iconError = new Icons.Regular.Size20.ErrorCircle();
        private static readonly Icon iconInfo = new Icons.Regular.Size20.Info();
        private static readonly Icon iconWarning = new Icons.Regular.Size20.Warning();

        extension(IToastService? toastService)
        {
            public async Task ShowError(string title, string? body = null) => await toastService.ShowMessage(title, iconError, body);

            public async Task ShowInfo(string title, string? body = null) => await toastService.ShowMessage(title, iconInfo, body);
            
            public async Task ShowWarning(string title, string? body = null) => await toastService.ShowMessage(title, iconWarning, body);

            public async Task ShowMessage(string title, Icon? icon, string? body = null)
            {
                if (toastService == null)
                    return;

                _ = await toastService.ShowToastAsync(options =>
                {
                    options.Title = title;
                    options.Icon = icon;
                    options.Body = body;
                });
            }
        }
    }
}

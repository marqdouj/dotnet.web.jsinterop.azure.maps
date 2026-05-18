using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Sandbox.Components.Pages.AzureMaps.Common
{
    internal static class MapProviderHelper
    {
        /// <summary>
        /// Checks if the given MapEventArgs contains an error in its payload. 
        /// If an error is present, it logs the error and shows a toast notification if the parameters are provided.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="logger"></param>
        /// <param name="toastService"></param>
        /// <returns>true if there was a payload error.</returns>
        public static async Task<bool> HasPayloadError(this MapEventArgs args, ILogger? logger, IToastService? toastService)
        {
            if (args.Payload?.Error != null)
            {
                var header = $"map event error occurred (MapId={args.MapId})";

                logger?.LogError("{header}\n{error}", header, args.Payload!.Error!.BuildMessage(includeStack: true));
                var msg = $"{header}. {args.Payload.Error.BuildMessage()}";
                await toastService.ShowError(msg);
                
                return true;
            }

            return false;
        }

        public static async Task<IAzureMapsInterop?> ProcessMapProviderInitialized(this MapProviderArgs args, ILogger logger, IToastService toastService)
        {
            try
            {
                if (args.Success)
                {
                    return args.MapsInterop ?? throw new InvalidOperationException("MapsInterop is null despite successful initialization.");
                }
                else
                {
                    logger.LogError(args.Exception, "map provider initialization failed: {Error}", args.Error);
                    await toastService.ShowError(args.ExceptionMessage);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "");
                await toastService.ShowError(ex.Message);
            }

            return null!;
        }

        public static async Task ProcessMapEventError(this MapEventArgs args, ILogger? logger, IToastService? toastService)
        {
            if (! await args.HasPayloadError(logger, toastService))
            {
                var header = $"map event error occurred (MapId={args.MapId})";

                logger?.LogError("{header}, but no error details were provided.", header);
                await toastService.ShowError("An unknown map event error occurred.");
            }
        }
    }
}

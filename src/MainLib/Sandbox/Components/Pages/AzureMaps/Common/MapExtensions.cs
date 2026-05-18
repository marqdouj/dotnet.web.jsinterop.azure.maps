using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Controls;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events;
using Marqdouj.DotNet.Web.JsInterop.GeoJson;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Sandbox.Components.Pages.AzureMaps.Common
{
    internal static class MapExtensions
    {
        public static async Task CreateDefaultMap(this IAzureMapsInterop maps, string mapId, ILogger logger, IToastService toastService, MapOptions? options = null, IEnumerable<ControlBase>? controls = null, IEnumerable<MapEvent>? events = null)
        {
            await maps.CreateMap(mapId, logger, toastService, options ?? GetDefaultMapOptions(), controls ?? GetDefaultControls(), events ?? GetDefaultMapEvents());
        }

        public static async Task CreateMap(this IAzureMapsInterop maps, string mapId, ILogger logger, IToastService toastService, MapOptions? options = null, IEnumerable<ControlBase>? controls = null, IEnumerable<MapEvent>? events = null)
        {
            try
            {
                // Optionally set log level for debugging, if not already set via configuration in Program.cs
                //await maps.SetLogLevel(LogLevel.Trace);

                var result = await maps.CreateMap(mapId, options, controls, events);

                if (result.Status == CreateMapStatus.Failure)
                {
                    var message = $"Failed to create map with Id='{mapId}'. {result.Message} {result.Error?.Message}";
                    logger.LogError(message);
                    await toastService.ShowError(message);
                }
            }
            catch (Exception ex)
            {
                var message = $"Failed to create map with Id='{mapId}'. {ex.Message}";
                logger.LogError(ex, message);
                await toastService.ShowError(message);
            }
        }

        public static async Task ResetMap(this IAzureMapsInterop maps, string mapId, ILogger logger, IToastService toastService, MapOptions? options = null)
        {
            try
            {
                await maps.Configuration.SetMapOptions(mapId, new MapOptionsEdit(options ?? GetDefaultMapOptions(), MapEditAction.Replace));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, null);
                await toastService.ShowError(ex.Message);
            }
        }

        public static List<MapEvent> GetDefaultMapEvents()
        {
            // Ready and Error events are automtatically added when creating a map, so we don't need to add them here.
            //return [new(MapEventType.Ready), new(MapEventType.Error)];
            return [];
        }

        public static MapOptions GetDefaultMapOptions(Position? center = null, double zoomLevel = 10.5)
        {
            // Initialize map options with a specific camera, style,and traffic options.
            return new MapOptions
            {
                Camera = new CameraOptions
                {
                    Center = center ?? new Position(-122.33, 47.6), // (Seattle, WA)
                    Zoom = zoomLevel,
                },
                Style = new StyleOptions { Style = MapStyle.road },
                Traffic = new TrafficOptions { Flow = TrafficFlow.none }
            };
        }

        public static List<ControlBase> GetDefaultControls()
        {
            var controls = new List<ControlBase>()
            {
                 GetDefaultControl(MapControlType.Fullscreen),
                 GetDefaultControl(MapControlType.Zoom),
                 GetDefaultControl(MapControlType.Pitch),
                 GetDefaultControl(MapControlType.Compass),
                 GetDefaultControl(MapControlType.Style),
                 GetDefaultControl(MapControlType.Traffic),
                 GetDefaultControl(MapControlType.TrafficLegend),
                 GetDefaultControl(MapControlType.Scale)
            };

            //Set the ZOrder based on position in the list
            var zOrder = 0;
            foreach (var control in controls)
            {
                control.SortOrder = zOrder;
                zOrder++;
            }

            return controls;
        }

        public static ControlBase GetDefaultControl(this MapControlType controlType)
        {
            return controlType switch
            {
                MapControlType.Compass => new CompassControl(),
                MapControlType.Fullscreen => new FullscreenControl(),
                MapControlType.Pitch => new PitchControl(),
                MapControlType.Scale => new ScaleControl(),
                MapControlType.Style => new StyleControl(),
                MapControlType.Traffic => new TrafficControl(),
                MapControlType.TrafficLegend => new TrafficLegendControl(),
                MapControlType.Zoom => new ZoomControl(),
                _ => throw new ArgumentOutOfRangeException(nameof(controlType)),
            };

        }
    }
}

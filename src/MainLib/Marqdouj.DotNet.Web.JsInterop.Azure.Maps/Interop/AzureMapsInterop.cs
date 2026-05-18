using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Controls;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop
{
    internal static class AzureMapsFactory
    {
        /// <summary>
        /// Creates an instance of AzureMapsInterop.
        /// </summary>
        /// <param name="jsRuntime"><see cref="IJSRuntime"/></param>
        /// <param name="component">The <see cref="ComponentBase"/> to use as a <see cref="DotNetObjectReference{TValue}"/> for JSInterop map events.</param>
        /// <param name="mapConfiguration"><see cref="MapConfiguration"/></param>
        /// <returns></returns>
        public static IAzureMapsInterop Create<TComponent>(IJSRuntime jsRuntime, TComponent component, MapConfiguration mapConfiguration) where TComponent : ComponentBase
        {
            return new AzureMapsInterop(jsRuntime, mapConfiguration, component);
        }
    }

    /// <summary>
    /// Azure Maps js interop supported by this library.
    /// </summary>
    public interface IAzureMapsInterop
    {
        /// <summary>
        /// <inheritdoc cref="IAzureMapsAnimations"/>
        /// </summary>
        IAzureMapsAnimations Animations { get; }

        /// <summary>
        /// <inheritdoc cref="IAzureMapsCommon"/>
        /// </summary>
        IAzureMapsCommon Common { get; }

        /// <summary>
        /// <inheritdoc cref="IAzureMapsControls"/>
        /// </summary>
        IAzureMapsControls Controls { get; }

        /// <summary>
        /// <inheritdoc cref="IAzureMapsConfiguration"/>
        /// </summary>
        IAzureMapsConfiguration Configuration { get; }

        /// <summary>
        /// <inheritdoc cref="IAzureMapsEvents"/>
        /// </summary>
        IAzureMapsEvents Events { get; }

        /// <summary>
        /// <inheritdoc cref="IAzureMapsFeatures"/>
        /// </summary>
        IAzureMapsFeatures Features { get; }

        /// <summary>
        /// <inheritdoc cref="IAzureMapsGeolocations"/>
        /// </summary>
        IAzureMapsGeolocations Geolocations { get; }

        /// <summary>
        /// <inheritdoc cref="IAzureMapsSprites"/>
        /// </summary>
        IAzureMapsSprites Sprites { get; }

        /// <summary>
        /// <inheritdoc cref="IAzureMapsLayers"/>
        /// </summary>
        IAzureMapsLayers Layers { get; }

        /// <summary>
        /// <inheritdoc cref="IAzureMapsMarkers"/>
        /// </summary>
        IAzureMapsMarkers Markers { get; }

        /// <summary>
        /// <inheritdoc cref="IAzureMapsMercators"/>
        /// </summary>
        IAzureMapsMercators Mercators { get; }

        /// <summary>
        /// <inheritdoc cref="IAzureMapsPopups"/>
        /// </summary>
        IAzureMapsPopups Popups { get; }

        /// <summary>
        /// <inheritdoc cref="IAzureMapsSources"/>
        /// </summary>
        IAzureMapsSources Sources { get; }

        /// <summary>
        /// Sets the log level for the browser console during JSInterop.
        /// </summary>
        /// <param name="logLevel"><see cref="LogLevel"/></param>
        /// <returns></returns>
        ValueTask SetLogLevel(LogLevel logLevel);

        /// <summary>
        /// Creats a map.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="options"></param>
        /// <param name="controls"></param>
        /// <param name="events"></param>
        /// <returns></returns>
        ValueTask<CreateMapResult> CreateMap(string mapId, MapOptions? options = null, IEnumerable<ControlBase>? controls = null, IEnumerable<MapEvent>? events = null);

        /// <summary>
        /// Gets an instance of a map.
        /// </summary>
        /// <param name="mapId"></param>
        /// <returns></returns>
        ValueTask<IJSObjectReference?> GetMap(string mapId);

        /// <summary>
        /// <see cref="IAsyncDisposable"/>
        /// </summary>
        /// <returns></returns>
        ValueTask DisposeAsync();
    }

    internal class AzureMapsInterop : IAzureMapsInterop, IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;
        private readonly MapConfiguration mapConfiguration;
        private readonly DotNetObjectReference<ComponentBase> dotNetRef;

        public AzureMapsInterop(IJSRuntime jsRuntime, MapConfiguration mapConfiguration, ComponentBase component)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Marqdouj.DotNet.Web.JsInterop.Azure.Maps/azureMaps.js").AsTask());
            this.mapConfiguration = mapConfiguration;
            dotNetRef = DotNetObjectReference.Create(component);

            Animations = new AzAnimations(moduleTask);
            Common = new AzCommon(moduleTask);
            Controls = new AzControls(moduleTask);
            Configuration = new AzConfiguration(moduleTask);
            Events = new AzEvents(moduleTask);
            Features = new AzFeatures(moduleTask);
            Geolocations = new AzGeolocations(moduleTask, dotNetRef);
            Sprites = new AzSprites(moduleTask);
            Layers = new AzLayers(moduleTask);
            Markers = new AzMarkers(moduleTask);
            Mercators = new AzMercators(moduleTask);
            Popups = new AzPopups(moduleTask);
            Sources = new AzSources(moduleTask);
        }

        public IAzureMapsAnimations Animations { get; }

        public IAzureMapsCommon Common { get; }

        public IAzureMapsControls Controls { get; }

        public IAzureMapsConfiguration Configuration { get; }

        public IAzureMapsEvents Events { get; }

        public IAzureMapsFeatures Features { get; }

        public IAzureMapsGeolocations Geolocations { get; }

        public IAzureMapsSprites Sprites { get; }

        public IAzureMapsLayers Layers { get; }

        public IAzureMapsMarkers Markers { get; }

        public IAzureMapsMercators Mercators { get; }

        public IAzureMapsPopups Popups { get; }

        public IAzureMapsSources Sources { get; }

        public async ValueTask<CreateMapResult> CreateMap(string mapId, MapOptions? options = null, IEnumerable<ControlBase>? controls = null, IEnumerable<MapEvent>? events = null)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(mapId, nameof(mapId));

            var module = await moduleTask.Value;
            var config = mapConfiguration;
            var configCreate = new MapConfiguration() { AuthOptions = config.AuthOptions, MapOptions = options ?? config.MapOptions, JsLogLevel = config.JsLogLevel };
            var createMapArgs = new CreateMapArgs
            {
                MapId = mapId.Trim(),
                Config = configCreate,
                Controls = controls?.Cast<object>().ToList(), // Cast controls to object list for JS interop
                Events = events?.Cast<object>().ToList(), // Cast events to object list for JS interop
                DotNetRef = dotNetRef
            };

            return await module.InvokeAsync<CreateMapResult>(GetJsInteropMethod(), createMapArgs);
        }

        public async ValueTask<IJSObjectReference?> GetMap(string mapId)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(mapId, nameof(mapId));

            var module = await moduleTask.Value;
            var mapRef = await module.InvokeAsync<IJSObjectReference>(GetJsInteropMethod(), mapId.Trim());

            return mapRef;
        }

        public async ValueTask SetLogLevel(LogLevel logLevel)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), logLevel);
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.InvokeVoidAsync(GetJsInteropMethod("Clear"));
                await module.DisposeAsync();
            }

            ((IDisposable)dotNetRef)?.Dispose();
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "") => JsModule.Factory.GetJsModuleMethod(name);
    }
}

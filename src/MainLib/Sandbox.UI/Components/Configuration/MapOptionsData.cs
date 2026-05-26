using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;
using Sandbox.UI.Models;

namespace Sandbox.UI.Components.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"><see cref="MapOptionsArgs"/></param>
    /// <param name="mapOptions"><see cref="MapOptions"/></param>
    public class MapOptionsData(MapOptions? mapOptions = null, MapOptionsArgs? args = null)
    {
        /// <summary>
        /// <inheritdoc cref="MapOptionsArgs"/>
        /// </summary>
        public MapOptionsArgs Args { get; } = args?.Clone() as MapOptionsArgs ?? new MapOptionsArgs();

        /// <summary>
        /// Which tab should be initially selected when the dialog is opened.
        /// </summary>
        public MapSettingsDisplay Display { get; set { field = value; ConifgureArgsForDisplay(); } }

        /// <summary>
        /// <inheritdoc cref="MapEditAction"/>
        /// </summary>
        public MapEditAction EditAction { get; set; }

        /// <summary>
        /// <inheritdoc cref="MapCameraData"/>
        /// </summary>
        public MapCameraData Camera { get; } = new MapCameraData(mapOptions);

        /// <summary>
        /// <inheritdoc cref="ServiceData"/>
        /// </summary>
        public ServiceData Service { get; } = new ServiceData(mapOptions);

        /// <summary>
        /// <inheritdoc cref="StyleData"/>
        /// </summary>
        public StyleData Style { get; } = new StyleData(mapOptions);

        /// <summary>
        /// <inheritdoc cref="TrafficData"/>
        /// </summary>
        public TrafficData Traffic { get; } = new TrafficData(mapOptions);

        /// <summary>
        /// <inheritdoc cref="UserInteractionData"/>
        /// </summary>
        public UserInteractionData UserInteraction { get; } = new UserInteractionData(mapOptions);

        private void ConifgureArgsForDisplay()
        {
            Args.Camera = Display == MapSettingsDisplay.All || Display == MapSettingsDisplay.Camera;
            Args.Service = Display == MapSettingsDisplay.All || Display == MapSettingsDisplay.Service;
            Args.Style = Display == MapSettingsDisplay.All || Display == MapSettingsDisplay.Style;
            Args.Traffic = Display == MapSettingsDisplay.All || Display == MapSettingsDisplay.Traffic;
            Args.UserInteraction = Display == MapSettingsDisplay.All || Display == MapSettingsDisplay.UserInteraction;
        }

        internal void Reset()
        {
            Camera.Reset();
            Service.Reset();
            Style.Reset();
            Traffic.Reset();
            UserInteraction.Reset();
        }

        /// <summary>
        /// Creates a new MapOptionsEdit instance that represents the current edit settings.
        /// </summary>
        public MapOptionsEdit ToMapOptionsEdit()
        {
            var options = new MapOptionsEdit(null, EditAction);

            if (Args.Camera)
                Camera.UpdateMapOptionsEdit(options);

            if (Args.Service)
                Service.UpdateMapOptionsEdit(options);

            if (Args.Style)
                Style.UpdateMapOptionsEdit(options);

            if (Args.Traffic)
                Traffic.UpdateMapOptionsEdit(options);

            if (Args.UserInteraction)
                UserInteraction.UpdateMapOptionsEdit(options);

            return options;
        }
    }
}
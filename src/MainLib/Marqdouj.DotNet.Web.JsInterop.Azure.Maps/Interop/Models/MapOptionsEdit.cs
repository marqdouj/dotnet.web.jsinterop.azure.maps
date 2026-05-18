using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models
{
    /// <summary>
    /// The map options to replace or update. 
    /// </summary>
    public class MapOptionsEdit(MapOptions? mapOptions = null, MapEditAction editAction = MapEditAction.Update)
    {
        /// <summary>
        /// <see cref="MapEditAction"/>
        /// </summary>
        public MapEditAction EditAction { get; set; } = editAction;

        /// <summary>
        /// When updating the map camera after the map is created, it also allows to update the map using animation options. <see cref="AnimationOptions"/>
        /// </summary>
        public AnimationOptions? Animation { get; set; }

        /// <summary>
        /// <see cref="CameraOptions"/>
        /// </summary>
        public CameraOptions? Camera { get; set; } = mapOptions?.Camera;

        /// <summary>
        /// <see cref="CameraBoundsOptionsSet"/>
        /// </summary>
        public CameraBoundsOptionsSet? CameraBounds { get; set; } = mapOptions?.CameraBounds != null ? new CameraBoundsOptionsSet(mapOptions) : null;

        /// <summary>
        /// <see cref="ServiceOptions"/>
        /// </summary>
        public ServiceOptions? Service { get; set; } = mapOptions?.Service;

        /// <summary>
        /// <see cref="StyleOptions"/>
        /// </summary>
        public StyleOptions? Style { get; set; } = mapOptions?.Style;

        /// <summary>
        /// <see cref="TrafficOptions"/>
        /// </summary>
        public TrafficOptions? Traffic { get; set; } = mapOptions?.Traffic;

        /// <summary>
        /// <see cref="UserInteractionOptions"/>
        /// </summary>
        public UserInteractionOptions? UserInteraction { get; set; } = mapOptions?.UserInteraction;
    }
}

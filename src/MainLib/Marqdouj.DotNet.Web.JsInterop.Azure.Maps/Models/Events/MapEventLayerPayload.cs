namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events
{
    /// <summary>
    /// Payload for a map event layer, containing information about the event and its associated data.
    /// </summary>
    public class MapEventLayerPayload
    {
        /// <summary>
        /// The ID of the layer.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// <inheritdoc cref="MapEventMousePayload"/>
        /// </summary>
        public MapEventMousePayload? Mouse { get; set; }

        /// <summary>
        /// <inheritdoc cref="MapEventTouchPayload"/>
        /// </summary>
        public MapEventTouchPayload? Touch { get; set; }

        /// <summary>
        /// <inheritdoc cref="MapEventWheelPayload"/>
        /// </summary>
        public MapEventWheelPayload? Wheel { get; set; }
    }
}

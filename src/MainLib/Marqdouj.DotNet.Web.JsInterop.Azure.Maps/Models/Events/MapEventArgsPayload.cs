namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events
{
    /// <summary>
    /// The payload returned from the Azure Maps JavaScript SDK when an event is triggered. 
    /// </summary>
    public class MapEventArgsPayload
    {
        /// <summary>
        /// <inheritdoc cref="MapEventConfigPayload"/>
        /// </summary>
        public MapEventConfigPayload? Config { get; set; }

        /// <summary>
        /// <inheritdoc cref="MapEventDataPayload"/>
        /// </summary>
        public MapEventDataPayload? Data { get; set; }

        /// <summary>
        /// <inheritdoc cref="MapEventDataSourcePayload"/>
        /// </summary>
        public MapEventDataSourcePayload? DataSource { get; set; }

        /// <summary>
        /// <inheritdoc cref="MapEventErrorPayload"/>
        /// </summary>
        public MapEventErrorPayload? Error { get; set; }

        /// <summary>
        /// <inheritdoc cref="MapEventHtmlMarkerPayload"/>
        /// </summary>
        public MapEventHtmlMarkerPayload? HtmlMarker { get; set; }

        /// <summary>
        /// <inheritdoc cref="MapEventLayerPayload"/>
        /// </summary>
        public MapEventLayerPayload? Layer { get; set; }

        /// <summary>
        /// <inheritdoc cref="MapEventMousePayload"/>
        /// </summary>
        public MapEventMousePayload? Mouse { get; set; }
        
        /// <summary>
        /// <inheritdoc cref="MapEventPopupPayload"/>
        /// </summary>
        public MapEventPopupPayload? Popup { get; set; }

        /// <summary>
        /// <inheritdoc cref="MapEventSourcePayload"/>
        /// </summary>
        public MapEventSourcePayload? Source { get; set; }

        /// <summary>
        /// <inheritdoc cref="MapEventStylePayload"/>
        /// </summary>
        public MapEventStylePayload? Style { get; set; }

        /// <summary>
        /// <inheritdoc cref="MapEventStyleControlPayload"/>
        /// </summary>
        public MapEventStyleControlPayload? StyleControl { get; set; }

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

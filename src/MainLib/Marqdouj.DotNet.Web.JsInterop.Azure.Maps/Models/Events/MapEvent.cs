namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events
{
    /// <summary>
    /// Base class for all map events. 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <param name="type"><see cref="MapEventType"/></param>
    /// <param name="target"><see cref="MapEventTarget"/></param>
    public class MapEvent(MapEventType type, MapEventTarget target = MapEventTarget.map) : ICloneable
    {

        /// <summary>
        /// <inheritdoc cref="MapEventType"/>
        /// </summary>
        public MapEventType Type { get; internal set; } = type;

        /// <summary>
        /// <inheritdoc cref="MapEventTarget"/>
        /// </summary>
        public MapEventTarget? Target { get; internal set; } = target;

        /// <summary>
        /// Required for any Target other than 'map'.
        /// For the stylecontrol use the 'InteropId'
        /// </summary>
        public string? TargetId { get; set; }

        /// <summary>
        /// Required for targets that belong to a source, i.e. shape requires DataSourceId.
        /// </summary>
        public string? TargetSourceId { get; set; }

        /// <summary>
        /// If true and the js event supports it, preventDefault will be applied to the event
        /// i.e. Mouse, Touch, and Wheel events.
        /// </summary>
        public bool PreventDefault { get; set; }

        /// <summary>
        /// If true adds the event once (for events that support 'once'); otherwise continuous./>.
        /// </summary>
        public bool Once { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

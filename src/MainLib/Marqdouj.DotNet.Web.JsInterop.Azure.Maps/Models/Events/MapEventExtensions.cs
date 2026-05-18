namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events
{
    /// <summary>
    /// 
    /// </summary>
    public static class MapEventExtensions
    {
        /// <summary>
        /// Converts a collection of map event types to a list of map event definitions with the specified target.
        /// </summary>
        /// <param name="events">The collection of map event types to convert. If null, an empty list is returned.</param>
        /// <param name="target">The target to assign to each map event definition. Defaults to MapEventTarget.map.</param>
        /// <returns>A list of MapEvent objects representing the specified event types and target. Returns an empty list if
        /// events is null or empty.</returns>
        public static List<MapEvent> ToMapEvents(this IEnumerable<MapEventType>? events, MapEventTarget target = MapEventTarget.map)
        {
            if (events == null) return [];

            return [.. events.Select(e => new MapEvent(e, target))];
        }

        /// <summary>
        /// Returns a MapEvent list of all MapEventTypes that apply to the target.
        /// </summary>
        /// <param name="target"><see cref="MapEventTarget"/></param>
        /// <param name="preventDefault"><see cref="MapEvent.PreventDefault"/></param>
        /// <returns></returns>
        public static IEnumerable<MapEvent> GetMapEvents(this MapEventTarget target, bool preventDefault = true)
        {
            return target switch
            {
                MapEventTarget.map => Enum.GetValues<MapEventTypeMap>().Select(e => new MapEvent((MapEventType)e, MapEventTarget.map) { PreventDefault = preventDefault }).OrderBy(e => e.ToString()),
                MapEventTarget.datasource => Enum.GetValues<MapEventTypeDataSource>().Select(e => new MapEvent((MapEventType)e, MapEventTarget.datasource) { PreventDefault = preventDefault }).OrderBy(e => e.ToString()),
                MapEventTarget.htmlmarker => Enum.GetValues<MapEventTypeHtmlMarker>().Select(e => new MapEvent((MapEventType)e, MapEventTarget.htmlmarker) { PreventDefault = preventDefault }).OrderBy(e => e.ToString()),
                MapEventTarget.layer => Enum.GetValues<MapEventTypeLayer>().Select(e => new MapEvent((MapEventType)e, MapEventTarget.layer) { PreventDefault = preventDefault }).OrderBy(e => e.ToString()),
                MapEventTarget.popup => Enum.GetValues<MapEventTypePopup>().Select(e => new MapEvent((MapEventType)e, MapEventTarget.popup) { PreventDefault = preventDefault }).OrderBy(e => e.ToString()),
                MapEventTarget.shape => Enum.GetValues<MapEventTypeShape>().Select(e => new MapEvent((MapEventType)e, MapEventTarget.shape) { PreventDefault = preventDefault }).OrderBy(e => e.ToString()),
                MapEventTarget.stylecontrol => Enum.GetValues<MapEventTypeStyleControl>().Select(e => new MapEvent((MapEventType)e, MapEventTarget.stylecontrol) { PreventDefault = preventDefault }).OrderBy(e => e.ToString()),
                _ => throw new ArgumentException($"Invalid MapEventTarget: '{target}'"),
            };
        }

        /// <summary>
        /// Returns a MapEventType list of all MapEventTypes that apply to the target.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IEnumerable<MapEventType> GetMapEventTypes(this MapEventTarget target)
        {
            return target switch
            {
                MapEventTarget.map => Enum.GetValues<MapEventTypeMap>().Cast<MapEventType>().OrderBy(e => e.ToString()),
                MapEventTarget.datasource => Enum.GetValues<MapEventTypeDataSource>().Cast<MapEventType>().OrderBy(e => e.ToString()),
                MapEventTarget.htmlmarker => Enum.GetValues<MapEventTypeHtmlMarker>().Cast<MapEventType>().OrderBy(e => e.ToString()),
                MapEventTarget.layer => Enum.GetValues<MapEventTypeLayer>().Cast<MapEventType>().OrderBy(e => e.ToString()),
                MapEventTarget.popup => Enum.GetValues<MapEventTypePopup>().Cast<MapEventType>().OrderBy(e => e.ToString()),
                MapEventTarget.shape => Enum.GetValues<MapEventTypeShape>().Cast<MapEventType>().OrderBy(e => e.ToString()),
                MapEventTarget.stylecontrol => Enum.GetValues<MapEventTypeStyleControl>().Cast<MapEventType>().OrderBy(e => e.ToString()),
                _ => throw new ArgumentException($"Invalid MapEventTarget: '{target}'"),
            };
        }
    }
}

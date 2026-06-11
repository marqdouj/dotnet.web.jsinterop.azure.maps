using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Controls;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Sandbox.UI.Models
{
    public class MapControlEventsViewModel(ControlBase control)
    {
        public ControlBase ControlBase { get; } = control;
        public List<MapEventViewModel> Events { get; } = control is StyleControl 
            ? [.. Enum.GetValues<MapEventTypeStyleControl>().Cast<MapEventType>()
                .Select(e => new MapEvent(e, MapEventTarget.stylecontrol) { TargetId = control.Id })
                .Select(e => new MapEventViewModel(e))] 
            : [];
    }

    public class MapControlEventsViewModel<TControl>(TControl control) 
        : MapControlEventsViewModel(control) where TControl : ControlBase
    {
        public TControl Control { get; } = control;
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

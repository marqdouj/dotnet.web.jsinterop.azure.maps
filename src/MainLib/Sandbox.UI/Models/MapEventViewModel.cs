using Marqdouj.DotNet.General.CsDoc;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events;

namespace Sandbox.UI.Models
{
    public class MapEventViewModel
    {
        public MapEventViewModel(MapEvent eventDef)
        {
            MapEvent = eventDef;
            MapEvent.PreventDefault = true;
        }

        public MapEvent MapEvent { get; }
        public string? Name => MapEvent.Type.GetDisplayName();
        public MapEventType? Type => MapEvent.Type;
        public bool IsChecked { get; set; }
        public bool IsNotChecked => !IsChecked;
        public bool IsLoaded { get; set; }
        public bool IsNotLoaded => !IsLoaded;
    }
}

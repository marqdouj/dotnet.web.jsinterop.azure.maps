using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models
{
    internal class CreateMapArgs
    {
        public object? DotNetRef { get; set; }
        public string MapId { get; set; } = string.Empty;
        public MapConfiguration? Config { get; set; }
        public List<object>? Controls { get; set; }
        public List<object>? Events { get; set; }
    }
}

using Marqdouj.DotNet.General.CsDoc;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Controls;
using Sandbox.UI.Services;

namespace Sandbox.UI.Models
{
    internal class MapControlEditViewModel<TSource, TOptions> where TSource : class where TOptions : OptionsBase
    {
        public MapControlEditViewModel(IAzureMapsCSDocReader docReader)
        {
            Source = docReader.CreateDocument<TSource>();
            Options = docReader.CreateDocument<TOptions>();
            Position = docReader.CreateDocument<MapControlPosition>();

            SourceName = Source.GetItem(typeof(TSource).Name)?.DisplayName ?? "";
            MapControlPosition = Position.GetItem(nameof(MapControlPosition));
            MapControlPosition?.NameAlias = "map Position";
        }

        public ICSDocument Source { get; }
        public ICSDocument Options { get; }
        public ICSDocument Position { get; }

        public string SourceName { get; }

        public CSDocumentItem? MapControlPosition { get; }
    }
}

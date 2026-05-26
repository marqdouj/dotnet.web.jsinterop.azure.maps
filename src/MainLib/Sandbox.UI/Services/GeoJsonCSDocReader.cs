using Marqdouj.DotNet.General.CsDoc;
using Microsoft.Extensions.Logging;

namespace Sandbox.UI.Services
{
    /// <summary>
    /// <see cref="GeoJsonCSDocReader"/>
    /// </summary>
    public interface IGeoJsonCSDocReader : ICSDocumentReader
    {

    }

    /// <summary>
    /// <see cref="CSDocumentReader"/> for the 'Marqdouj.DotNet.Web.JsInterop.GeoJson' .NET assembly.
    /// </summary>
    public class GeoJsonCSDocReader : CSDocumentReader, IGeoJsonCSDocReader
    {
        /// <summary>
        /// 
        /// </summary>
        public GeoJsonCSDocReader(ILogger<GeoJsonCSDocReader> logger) : base("Marqdouj.DotNet.Web.JsInterop.GeoJson")
        {
            LoadXml(logger: logger);
        }
    }
}

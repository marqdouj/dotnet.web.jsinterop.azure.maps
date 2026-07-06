using Marqdouj.DotNet.General.CsDoc;
using Microsoft.Extensions.Logging;

namespace Sandbox.UI.Services
{
    /// <summary>
    /// <see cref="XmlDocumentReader"/> for the 'Marqdouj.DotNet.Web.JsInterop.GeoJson' .NET assembly.
    /// </summary>
    public class GeoJsonXmlDocReader : XmlDocumentReader
    {
        /// <summary>
        /// 
        /// </summary>
        public GeoJsonXmlDocReader(ILogger<GeoJsonXmlDocReader> logger) : base("Marqdouj.DotNet.Web.JsInterop.GeoJson")
        {
            LoadXml(logger: logger);
        }
    }
}

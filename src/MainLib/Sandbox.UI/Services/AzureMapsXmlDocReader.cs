using Marqdouj.DotNet.General.CsDoc;
using Microsoft.Extensions.Logging;

namespace Sandbox.UI.Services
{
    /// <summary>
    /// <see cref="XmlDocumentReader"/> for the 'Marqdouj.DotNet.Web.JsInterop.Azure.Maps' .NET assembly.
    /// </summary>
    public class AzureMapsXmlDocReader : XmlDocumentReader
    {
        /// <summary>
        /// 
        /// </summary>
        public AzureMapsXmlDocReader(ILogger<AzureMapsXmlDocReader> logger) : base("Marqdouj.DotNet.Web.JsInterop.Azure.Maps")
        {
            LoadXml(logger: logger);
        }
    }
}

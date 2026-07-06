using Marqdouj.DotNet.General.CsDoc;
using Microsoft.Extensions.Logging;

namespace Sandbox.UI.Services
{
    /// <summary>
    /// <see cref="XmlDocumentReader"/> for the 'Sandbox.UI' .NET assembly.
    /// </summary>
    public class AzureMapsUIXmlDocReader : XmlDocumentReader
    {
        /// <summary>
        /// 
        /// </summary>
        public AzureMapsUIXmlDocReader(ILogger<AzureMapsUIXmlDocReader> logger) : base("Sandbox.UI")
        {
            LoadXml(logger: logger);
        }
    }
}

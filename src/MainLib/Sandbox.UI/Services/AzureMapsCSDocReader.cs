using Marqdouj.DotNet.General.CsDoc;
using Microsoft.Extensions.Logging;

namespace Sandbox.UI.Services
{
    /// <summary>
    /// <see cref="AzureMapsCSDocReader"/>
    /// </summary>
    public interface IAzureMapsCSDocReader : ICSDocumentReader
    {

    }

    /// <summary>
    /// <see cref="CSDocumentReader"/> for the 'Marqdouj.DotNet.Web.JsInterop.Azure.Maps' .NET assembly.
    /// </summary>
    public class AzureMapsCSDocReader : CSDocumentReader, IAzureMapsCSDocReader
    {
        /// <summary>
        /// 
        /// </summary>
        public AzureMapsCSDocReader(ILogger<AzureMapsCSDocReader> logger) : base("Marqdouj.DotNet.Web.JsInterop.Azure.Maps")
        {
            LoadXml(logger: logger);
        }
    }
}

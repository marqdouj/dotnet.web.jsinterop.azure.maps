using Marqdouj.DotNet.General.CsDoc;

namespace Sandbox.Services
{
    /// <summary>
    /// <see cref="AzureMapsCSDocReader"/>
    /// </summary>
    public interface IAzureMapsCSDocReader : ICSDocumentReader
    {

    }

    /// <summary>
    /// <see cref="CSDocumentReader"/> for the 'Marqdouj.DotNet.Web.JsInterop.AzureMaps' .NET assembly.
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

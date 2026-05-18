using Marqdouj.DotNet.General.CsDoc;

namespace Sandbox.Services
{
    /// <summary>
    /// <see cref="AzureMapsUICSDocReader"/>
    /// </summary>
    public interface IAzureMapsUICSDocReader : ICSDocumentReader
    {

    }

    /// <summary>
    /// <see cref="CSDocumentReader"/> for the 'Marqdouj.DotNet.Web.JsInterop.AzureMaps.UI' .NET assembly.
    /// </summary>
    public class AzureMapsUICSDocReader : CSDocumentReader, IAzureMapsUICSDocReader
    {
        /// <summary>
        /// 
        /// </summary>
        public AzureMapsUICSDocReader(ILogger<AzureMapsUICSDocReader> logger) : base("Marqdouj.DotNet.Web.JsInterop.AzureMaps.UI")
        {
            LoadXml(logger: logger);
        }
    }
}

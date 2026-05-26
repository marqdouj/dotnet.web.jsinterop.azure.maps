using Marqdouj.DotNet.General.CsDoc;
using Microsoft.Extensions.Logging;

namespace Sandbox.UI.Services
{
    /// <summary>
    /// <see cref="AzureMapsUICSDocReader"/>
    /// </summary>
    public interface IAzureMapsUICSDocReader : ICSDocumentReader
    {

    }

    /// <summary>
    /// <see cref="CSDocumentReader"/> for the 'Sandbox.UI' .NET assembly.
    /// </summary>
    public class AzureMapsUICSDocReader : CSDocumentReader, IAzureMapsUICSDocReader
    {
        /// <summary>
        /// 
        /// </summary>
        public AzureMapsUICSDocReader(ILogger<AzureMapsUICSDocReader> logger) : base("Sandbox.UI")
        {
            LoadXml(logger: logger);
        }
    }
}

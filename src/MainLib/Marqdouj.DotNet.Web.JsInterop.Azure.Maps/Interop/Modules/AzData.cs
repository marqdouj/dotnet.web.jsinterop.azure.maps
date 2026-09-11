using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules.Data;
using Microsoft.JSInterop;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Interface for atlas.data interactions. <see href="https://learn.microsoft.com/en-us/javascript/api/azure-maps-control/atlas.data?view=azure-maps-typescript-latest"/>
    /// </summary>
    public interface IAzureMapsData
    {
        /// <summary>
        /// <inheritdoc cref="IAzureMapsBoundingBox"/>
        /// </summary>
        IAzureMapsBoundingBox BoundingBox { get; }
    }

    internal class AzData(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsData
    {
        public IAzureMapsBoundingBox BoundingBox { get; } = new AzBoundingBox(moduleTask);
    }
}

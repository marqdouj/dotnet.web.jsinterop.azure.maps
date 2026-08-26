using Microsoft.JSInterop;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Interface for Azure Maps spatial interactions.
    /// </summary>
    public interface IAzureMapsSpatial
    {
        /// <summary>
        /// <inheritdoc cref="IAzureMapsSpatialLayers"/>
        /// </summary>
        IAzureMapsSpatialLayers Layers { get; }

        /// <summary>
        /// <inheritdoc cref="IAzureMapsSpatialSources"/>
        /// </summary>
        IAzureMapsSpatialSources Sources { get; }
    }

    internal class AzSpatial(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsSpatial
    {
        public IAzureMapsSpatialLayers Layers { get; } = new AzSpatialLayers(moduleTask);
        public IAzureMapsSpatialSources Sources { get; } = new AzSpatialSources(moduleTask);
    }
}

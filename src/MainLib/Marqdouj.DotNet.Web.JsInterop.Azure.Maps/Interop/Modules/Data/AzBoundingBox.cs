using Marqdouj.DotNet.Web.JsInterop.GeoJson;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules.Data
{
    /// <summary>
    /// Interface for Azure Maps bounding box interactions.
    /// </summary>
    public interface IAzureMapsBoundingBox
    {
        /// <summary>
        /// Calculates the bounding box of a FeatureCollection, Feature, Geometry, Shape or array of these objects.
        /// </summary>
        /// <param name="data">The object to calculate the bounding box for. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns></returns>
        ValueTask<BoundingBox> FromData(object data);
    }

    internal class AzBoundingBox(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsBoundingBox
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask<BoundingBox> FromData(object data)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<BoundingBox>(GetJsInteropMethod(), data);
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.BoundingBox.GetJsModuleMethod(name);
    }
}

using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Atlas;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Atlas.Modules.Data;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Interface for atlas.data interactions. <see href="https://learn.microsoft.com/en-us/javascript/api/azure-maps-control/atlas.data?view=azure-maps-typescript-latest"/>
    /// </summary>
    public interface IAzureMapsData
    {
        /// <summary>
        /// <inheritdoc cref="IAtlasBoundingBox"/>
        /// </summary>
        IAtlasBoundingBox BoundingBox { get; }

        /// <summary>
        /// <inheritdoc cref="IAtlasMercatorPoint"/>
        /// </summary>
        IAtlasMercatorPoint MercatorPoint { get; }

        /// <summary>
        /// <inheritdoc cref="IAtlasPosition"/>
        /// </summary>
        IAtlasPosition Position { get; }
    }

    internal class AzData(IAtlasInterop atlasInterop) : IAzureMapsData
    {
        public IAtlasBoundingBox BoundingBox => atlasInterop.Data.BoundingBox;
        public IAtlasMercatorPoint MercatorPoint => atlasInterop.Data.MercatorPoint;
        public IAtlasPosition Position => atlasInterop.Data.Position;
    }
}

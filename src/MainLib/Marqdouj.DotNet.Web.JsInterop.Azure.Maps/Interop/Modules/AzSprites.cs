using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers.Images;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Interface for Azure Maps Image Sprites module, providing methods to manage image sprites on the map.
    /// </summary>
    public interface IAzureMapsSprites
    {
        /// <summary>
        /// adds an image to the map's sprite collection. The image can be provided either as raw image data or as a base64-encoded string. 
        /// Optional metadata can also be supplied to define properties of the image.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="id"></param>
        /// <param name="icon"></param>
        /// <param name="meta"></param>
        /// <returns></returns>
        ValueTask<bool> Add(string mapId, string id, ImageData icon, StyleImageMetadata? meta);

        /// <summary>
        /// Adds an image to the map's sprite collection. The image is provided as a base64-encoded string. 
        /// Optional metadata can also be supplied to define properties of the image.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="id"></param>
        /// <param name="icon"></param>
        /// <param name="meta"></param>
        /// <returns></returns>
        ValueTask<bool> Add(string mapId, string id, string icon, StyleImageMetadata? meta);

        /// <summary>
        /// Clears all images from the map's sprite collection, effectively removing all custom images that have been added.
        /// </summary>
        /// <param name="mapId"></param>
        /// <returns></returns>
        ValueTask Clear(string mapId);

        /// <summary>
        /// Creates an image in the map's sprite collection based on a predefined template. 
        /// The template defines the characteristics of the image, such as its shape, color, and other properties.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="templateDef"></param>
        /// <returns></returns>
        ValueTask<bool> CreateFromTemplate(string mapId, ImageTemplate templateDef);

        /// <summary>
        /// Gets a list of all image IDs currently present in the map's sprite collection.
        /// </summary>
        /// <param name="mapId"></param>
        /// <returns></returns>
        ValueTask<List<string>> GetImageIds(string mapId);

        /// <summary>
        /// Gets a value indicating whether an image with the specified ID exists in the map's sprite collection.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="templateDef"></param>
        /// <returns></returns>
        ValueTask<bool> HasImage(string mapId, ImageTemplate templateDef);

        /// <summary>
        /// Gets a value indicating whether an image with the specified ID exists in the map's sprite collection.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<bool> HasImage(string mapId, string id);

        /// <summary>
        /// Removes an image with the specified ID from the map's sprite collection, effectively deleting it from the map.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask Remove(string mapId, string id);
    }

    internal class AzSprites(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsSprites
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask<bool> CreateFromTemplate(string mapId, ImageTemplate templateDef)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<bool>(GetJsInteropMethod(), mapId, templateDef);
        }

        public async ValueTask<bool> HasImage(string mapId, ImageTemplate templateDef)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<bool>(GetJsInteropMethod(), mapId, templateDef.Id);
        }

        public async ValueTask<bool> HasImage(string mapId, string id)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<bool>(GetJsInteropMethod(), mapId, id);
        }

        public async ValueTask<bool> Add(string mapId, string id, string icon, StyleImageMetadata? meta)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<bool>(GetJsInteropMethod(), mapId, id, icon, meta);
        }

        public async ValueTask<bool> Add(string mapId, string id, ImageData icon, StyleImageMetadata? meta)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<bool>(GetJsInteropMethod(), mapId, id, icon, meta);
        }

        public async ValueTask Clear(string mapId)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId);
        }

        public async ValueTask<List<string>> GetImageIds(string mapId)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<string>>(GetJsInteropMethod(), mapId);
        }

        public async ValueTask Remove(string mapId, string id)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(GetJsInteropMethod(), mapId, id);
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.Sprites.GetJsModuleMethod(name);
    }
}
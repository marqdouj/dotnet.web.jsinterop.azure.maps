using Marqdouj.DotNet.Web.JsInterop.GeoJson;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules.Data
{
    /// <summary>
    /// Interface for atlas.data.BoundingBox interactions. <see href="https://learn.microsoft.com/en-us/javascript/api/azure-maps-control/atlas.data.boundingbox?view=azure-maps-typescript-latest"/>
    /// </summary>
    public interface IAzureMapsBoundingBox
    {
        /// <summary>
        /// Determines if a position is within a bounding box.
        /// </summary>
        /// <param name="bounds">BoundingBox. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="position">Position. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns></returns>
        ValueTask<bool> ContainsPosition(object bounds, object position);

        /// <summary>
        /// Returns a boolean indicating if the bounding box crosses the antimeridian or not.
        /// </summary>
        /// <param name="bounds">BoundingBox. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns></returns>
        ValueTask<bool> CrossesAntimeridian(object bounds);

        /// <summary>
        /// Clones a BoundingBox.
        /// </summary>
        /// <param name="data">The bounding box to clone. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns></returns>
        ValueTask<BoundingBox> FromBoundingBox(object data);

        /// <summary>
        /// Calculates the bounding box of a FeatureCollection, Feature, Geometry, Shape or array of these objects.
        /// </summary>
        /// <param name="data">The object to calculate the bounding box for. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns></returns>
        ValueTask<BoundingBox> FromData(object data);

        /// <summary>
        /// Constructs a BoundingBox from the specified dimensions.
        /// </summary>
        /// <param name="data">The center position of the bounding box. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="width">The width of the bounding box.</param>
        /// <param name="height">The height of the bounding box.</param>
        /// <returns></returns>
        ValueTask<BoundingBox> FromDimensions(object data, double width, double height);

        /// <summary>
        /// Constructs a BoundingBox from the specified edges.
        /// </summary>
        /// <param name="west">The west edge of the bounding box.</param>
        /// <param name="south">The south edge of the bounding box.</param>
        /// <param name="east">The east edge of the bounding box.</param>
        /// <param name="north">The north edge of the bounding box.</param>
        /// <returns></returns>
        ValueTask<BoundingBox> FromEdges(double west, double south, double east, double north);

        /// <summary>
        /// Creates a BoundingBox from any array of objects that contain coordinate information.
        /// Each object is either an array in the format; [lat, lng] or [lat, lng, elv], or an object with the any combination of the following properties:
        /// Longitude: lng, longitude, lon, x
        /// Latitude: lat, latitude, y
        /// Elevation: elv, elevation, alt, altitude, z
        /// </summary>
        /// <param name="data">The objects that contain coordinate information. May be an <see cref="IJSObjectReference"/></param>
        /// <returns></returns>
        ValueTask<BoundingBox> FromLatLngs(object data);

        /// <summary>
        /// Creates a BoundingBox that contains all provided Position objects.
        /// </summary>
        /// <param name="data">Positions[]. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns>A bounding box that contains all given positions.</returns>
        ValueTask<BoundingBox> FromPositions(object data);

        /// <summary>
        /// Calculates the center of a bounding box.
        /// </summary>
        /// <param name="data">BoundingBox. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns></returns>
        ValueTask<Position> GetCenter(object data);

        /// <summary>
        /// Returns the east position value of the bounding box.
        /// </summary>
        /// <param name="data">BoundingBox. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns>The east position value of the bounding box.</returns>
        ValueTask<double> GetEast(object data);

        /// <summary>
        /// Gets the height of a bounding box in degrees.
        /// </summary>
        /// <param name="data">BoundingBox. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns>The height of the bounding box in degrees.</returns>
        ValueTask<double> GetHeight(object data);

        /// <summary>
        /// Returns the north position value of the bounding box.
        /// </summary>
        /// <param name="data">BoundingBox. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns>The north position value of the bounding box.</returns>
        ValueTask<double> GetNorth(object data);

        /// <summary>
        /// Returns the north east position of the bounding box.
        /// </summary>
        /// <param name="data">BoundingBox. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns>The north east position of the bounding box.</returns>
        ValueTask<Position> GetNorthEast(object data);

        /// <summary>
        /// Returns the north west position of the bounding box.
        /// </summary>
        /// <param name="data">BoundingBox. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns>The north west position of the bounding box.</returns>
        ValueTask<Position> GetNorthWest(object data);

        /// <summary>
        /// Returns the south position value of the bounding box.
        /// </summary>
        /// <param name="data">BoundingBox. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns>The south position value of the bounding box.</returns>
        ValueTask<double> GetSouth(object data);

        /// <summary>
        /// Returns the south east position of the bounding box.
        /// </summary>
        /// <param name="data">BoundingBox. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns>The south east position of the bounding box.</returns>
        ValueTask<Position> GetSouthEast(object data);

        /// <summary>
        /// Returns the south west position of the bounding box.
        /// </summary>
        /// <param name="data">BoundingBox. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns>The south west position of the bounding box.</returns>
        ValueTask<Position> GetSouthWest(object data);

        /// <summary>
        /// Returns the west position value of the bounding box.
        /// </summary>
        /// <param name="data">BoundingBox. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns>The west position value of the bounding box.</returns>
        ValueTask<double> GetWest(object data);

        /// <summary>
        /// Gets the width of a bounding box in degrees.
        /// </summary>
        /// <param name="data">BoundingBox. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns>The width of the bounding box in degrees.</returns>
        ValueTask<double> GetWidth(object data);

        /// <summary>
        /// Determines if two bounding boxes intersect.
        /// </summary>
        /// <param name="bounds1">BoundingBox. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="bounds2">BoundingBox. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns>true if the provided bounding boxes intersect.</returns>
        ValueTask<bool> Intersect(object bounds1, object bounds2);

        /// <summary>
        /// Merges two bounding boxes together.
        /// </summary>
        /// <param name="bounds1">BoundingBox. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="bounds2">BoundingBox. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns>A bounding box in the format [minLon, minLat, maxLon, maxLat].</returns>
        ValueTask<BoundingBox> Merge(object bounds1, object bounds2);

        /// <summary>
        /// Splits a BoundingBox that crosses the Antimeridian into two BoundingBox's. 
        /// One entirely west of the Antimerdian and another entirely east of the Antimerdian.
        /// </summary>
        /// <param name="bounds">BoundingBox. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns></returns>
        ValueTask<List<BoundingBox>> SplitOnAntimeridian(object bounds);
    }

    internal class AzBoundingBox(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsBoundingBox
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask<bool> ContainsPosition(object bounds, object position)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<bool>(GetJsInteropMethod(), bounds, position);
        }

        public async ValueTask<bool> CrossesAntimeridian(object bounds)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<bool>(GetJsInteropMethod(), bounds);
        }

        public async ValueTask<BoundingBox> FromBoundingBox(object data)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<BoundingBox>(GetJsInteropMethod(), data);
        }

        public async ValueTask<BoundingBox> FromData(object data)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<BoundingBox>(GetJsInteropMethod(), data);
        }

        public async ValueTask<BoundingBox> FromDimensions(object data, double width, double height)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<BoundingBox>(GetJsInteropMethod(), data, width, height);
        }

        public async ValueTask<BoundingBox> FromEdges(double west, double south, double east, double north)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<BoundingBox>(GetJsInteropMethod(), west, south, east, north );
        }

        public async ValueTask<BoundingBox> FromLatLngs(object data)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<BoundingBox>(GetJsInteropMethod(), data);
        }

        public async ValueTask<BoundingBox> FromPositions(object data)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<BoundingBox>(GetJsInteropMethod(), data);
        }

        public async ValueTask<Position> GetCenter(object data)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), data);
        }

        public async ValueTask<double> GetHeight(object data)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), data);
        }

        public async ValueTask<Position> GetNorthEast(object data)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), data);
        }

        public async ValueTask<Position> GetNorthWest(object data)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), data);
        }

        public async ValueTask<Position> GetSouthEast(object data)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), data);
        }

        public async ValueTask<Position> GetSouthWest(object data)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), data);
        }

        public async ValueTask<double> GetNorth(object data)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), data);
        }

        public async ValueTask<double> GetSouth(object data)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), data);
        }

        public async ValueTask<double> GetEast(object data)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), data);
        }

        public async ValueTask<double> GetWest(object data)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), data);
        }

        public async ValueTask<double> GetWidth(object data)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), data);
        }

        public async ValueTask<bool> Intersect(object bounds1, object bounds2)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<bool>(GetJsInteropMethod(), bounds1, bounds2);
        }

        public async ValueTask<BoundingBox> Merge(object bounds1, object bounds2)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<BoundingBox>(GetJsInteropMethod(), bounds1, bounds2);
        }

        public async ValueTask<List<BoundingBox>> SplitOnAntimeridian(object bounds)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<BoundingBox>>(GetJsInteropMethod(), bounds);
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.BoundingBox.GetJsModuleMethod(name);
    }
}

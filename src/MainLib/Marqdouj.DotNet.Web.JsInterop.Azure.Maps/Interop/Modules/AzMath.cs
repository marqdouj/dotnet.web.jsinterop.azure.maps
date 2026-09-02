using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models.Atlas;
using Marqdouj.DotNet.Web.JsInterop.GeoJson;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Interface for Azure Maps math module
    /// </summary>
    public interface IAzMath
    {
        /// <summary>
        /// Takes a list of BoundingBoxes and converts them to polygons.
        /// </summary>
        /// <param name="boundingBoxes">The BoundingBoxes to convert to Polygons</param>
        /// <returns></returns>
        ValueTask<List<BoundingBox>> BoundingBoxesToPolygons(List<BoundingBox> boundingBoxes);

        /// <summary>
        /// Takes a BoundingBox and converts it to a polygon.
        /// </summary>
        /// <param name="boundingBox">The BoundingBox to convert to a Polygon</param>
        /// <returns></returns>
        ValueTask<BoundingBox> BoundingBoxToPolygon(BoundingBox boundingBox);

        /// <summary>
        /// Converts a distance from one distance units to another. Supported units: miles, nauticalMiles, yards, meters, kilometers, feet
        /// </summary>
        /// <param name="distance">The distance to convert</param>
        /// <param name="fromUnits">The units to convert from</param>
        /// <param name="toUnits">The units to convert to</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns></returns>
        ValueTask<double> ConvertDistance(double distance, DistanceUnits fromUnits, DistanceUnits toUnits, int? decimals = null);

        /// <summary>
        /// Converts a distance from one distance units to another. Supported units: miles, nauticalMiles, yards, meters, kilometers, feet
        /// </summary>
        /// <param name="distance">The distance to convert</param>
        /// <param name="fromUnits">The units to convert from</param>
        /// <param name="toUnits">The units to convert to</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns></returns>
        ValueTask<double> ConvertDistance(double distance, string fromUnits, string toUnits, int? decimals = null);

        /// <summary>
        /// Converts a list of distances from one distance units to another. Supported units: miles, nauticalMiles, yards, meters, kilometers, feet
        /// </summary>
        /// <param name="distances">The distances to convert</param>
        /// <param name="fromUnits">The units to convert from</param>
        /// <param name="toUnits">The units to convert to</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns></returns>
        ValueTask<List<double>> ConvertDistances(List<double> distances, string fromUnits, string toUnits, int? decimals = null);

        /// <summary>
        /// Converts a list of distances from one distance units to another. Supported units: miles, nauticalMiles, yards, meters, kilometers, feet
        /// </summary>
        /// <param name="distances">The distances to convert</param>
        /// <param name="fromUnits">The units to convert from</param>
        /// <param name="toUnits">The units to convert to</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns></returns>
        ValueTask<List<double>> ConvertDistances(List<double> distances, DistanceUnits fromUnits, DistanceUnits toUnits, int? decimals = null);

        /// <summary>
        /// Calculates an array of positions that form a cardinal spline between the specified array of positions.
        /// </summary>
        /// <param name="positions">The positions to calculate the spline through</param>
        /// <param name="tension">A number that indicates the tightness of the curve. Can be any number, although a value between 0 and 1 is usually used. Default: 0.5</param>
        /// <param name="nodeSize">Number of nodes to insert between each position. Default: 15</param>
        /// <param name="close">Whether to close the spline. Default: false</param>
        /// <returns></returns>
        ValueTask<List<Position>> GetCardinalSpline(List<Position> positions, double? tension = null, double? nodeSize = null, bool? close = null);

        /// <summary>
        /// Calculates a destination position based on a starting position, a heading, a distance, and a distance unit type.
        /// </summary>
        /// <param name="origin">Position that the destination is relative to.</param>
        /// <param name="heading">A heading angle between 0 - 360 degrees. 0 - North, 90 - East, 180 - South, 270 - West.</param>
        /// <param name="distance">Distance that destination is away.</param>
        /// <param name="units">Unit of distance measurement. Default is meters.</param>
        /// <returns>A position that is the specified distance away from the origin.</returns>
        ValueTask<Position> GetDestination(Point origin, double heading, double distance, string? units = null);

        /// <summary>
        /// Calculates a destination position based on a starting position, a heading, a distance, and a distance unit type.
        /// </summary>
        /// <param name="origin">Position that the destination is relative to.</param>
        /// <param name="heading">A heading angle between 0 - 360 degrees. 0 - North, 90 - East, 180 - South, 270 - West.</param>
        /// <param name="distance">Distance that destination is away.</param>
        /// <param name="units">Unit of distance measurement. Default is meters.</param>
        /// <returns>A position that is the specified distance away from the origin.</returns>
        ValueTask<Position> GetDestination(Position origin, double heading, double distance, string? units = null);

        /// <summary>
        /// Calculates a destination position based on a starting position, a heading, a distance, and a distance unit type.
        /// </summary>
        /// <param name="origin">Position that the destination is relative to.</param>
        /// <param name="heading">A heading angle between 0 - 360 degrees. 0 - North, 90 - East, 180 - South, 270 - West.</param>
        /// <param name="distance">Distance that destination is away.</param>
        /// <param name="units">Unit of distance measurement. Default is meters.</param>
        /// <returns>A position that is the specified distance away from the origin.</returns>
        ValueTask<Position> GetDestination(Point origin, double heading, double distance, DistanceUnits? units = null);

        /// <summary>
        /// Calculates a destination position based on a starting position, a heading, a distance, and a distance unit type.
        /// </summary>
        /// <param name="origin">Position that the destination is relative to.</param>
        /// <param name="heading">A heading angle between 0 - 360 degrees. 0 - North, 90 - East, 180 - South, 270 - West.</param>
        /// <param name="distance">Distance that destination is away.</param>
        /// <param name="units">Unit of distance measurement. Default is meters.</param>
        /// <returns>A position that is the specified distance away from the origin.</returns>
        ValueTask<Position> GetDestination(Position origin, double heading, double distance, DistanceUnits? units = null);

        /// <summary>
        /// Calculate the distance between two position objects on the surface of the earth using the Haversine formula.
        /// </summary>
        /// <param name="origin">The starting position.</param>
        /// <param name="destination">The destination position.</param>
        /// <param name="units">The unit of distance measurement. Default is meters.</param>
        /// <returns>The distance between the two positions.</returns>
        ValueTask<double> GetDistanceTo(Point origin, Point destination, string? units = null);

        /// <summary>
        /// Calculates the distance between two position objects on the surface of the earth using the Haversine formula.
        /// </summary>
        /// <param name="origin">The starting position.</param>
        /// <param name="destination">The destination position.</param>
        /// <param name="units">The unit of distance measurement. Default is meters.</param>
        /// <returns>The distance between the two positions.</returns>
        ValueTask<double> GetDistanceTo(Position origin, Position destination, string? units = null);

        /// <summary>
        /// Calculates the distance between two position objects on the surface of the earth using the Haversine formula.
        /// </summary>
        /// <param name="origin">The starting position.</param>
        /// <param name="destination">The destination position.</param>
        /// <param name="units">The unit of distance measurement. Default is meters.</param>
        /// <returns>The distance between the two positions.</returns>
        ValueTask<double> GetDistanceTo(Point origin, Point destination, DistanceUnits? units = null);

        /// <summary>
        /// Calculates the distance between two position objects on the surface of the earth using the Haversine formula.
        /// </summary>
        /// <param name="origin">The starting position.</param>
        /// <param name="destination">The destination position.</param>
        /// <param name="units">The unit of distance measurement. Default is meters.</param>
        /// <returns>The distance between the two positions.</returns>
        ValueTask<double> GetDistanceTo(Position origin, Position destination, DistanceUnits? units = null);

        /// <summary>
        /// Retrieves the radius of the earth in a specific distance unit for WGS84.
        /// </summary>
        /// <param name="units">The unit of distance measurement. Default is meters.</param>
        /// <returns>The radius of the earth.</returns>
        ValueTask<double> GetEarthRadius(string? units = null);

        /// <summary>
        /// Retrieves the radius of the earth in a specific distance unit for WGS84.
        /// </summary>
        /// <param name="units">The unit of distance measurement. Default is meters.</param>
        /// <returns>The radius of the earth.</returns>     
        ValueTask<double> GetEarthRadius(DistanceUnits? units = null);

        /// <summary>
        /// Takes an array of positions objects and fills in the space between them with accurately positioned positions to form an approximated Geodesic path.
        /// </summary>
        /// <param name="path">The array of positions to interpolate.</param>
        /// <param name="nodeSize">Number of nodes to insert between each position. Default: 15.</param>
        /// <returns>The interpolated geodesic path. A geodesic path crossing antimeridian will contain longitude outside of -180 to 180 range. 
        /// See getGeodesicPaths() when this is undesired.</returns>
        ValueTask<List<Position>> GetGeodesicPath(List<Position> path, double? nodeSize = null);

        /// <summary>
        /// Takes a LineString and fills in the space between its positions with accurately positioned positions to form an approximated Geodesic path.
        /// </summary>
        /// <param name="path">The LineString to interpolate.</param>
        /// <param name="nodeSize">Number of nodes to insert between each position. Default: 15.</param>
        /// <returns>The interpolated geodesic path. A geodesic path crossing antimeridian will contain longitude outside of -180 to 180 range. 
        /// See getGeodesicPaths() when this is undesired.</returns>
        ValueTask<List<Position>> GetGeodesicPath(LineString path, double? nodeSize = null);

        /// <summary>
        /// Takes a JS object reference of a LineString or Position[] and fills in the space between its positions with accurately positioned positions to form an approximated Geodesic path.
        /// </summary>
        /// <param name="path">The JS object reference to interpolate. Must be a valid LineString or Position[] reference.</param>
        /// <param name="nodeSize">Number of nodes to insert between each position. Default: 15.</param>
        /// <returns>The interpolated geodesic path. A geodesic path crossing antimeridian will contain longitude outside of -180 to 180 range. 
        /// See getGeodesicPaths() when this is undesired.</returns>
        ValueTask<List<Position>> GetGeodesicPath(IJSObjectReference path, double? nodeSize = null);

        /// <summary>
        /// Takes an array of positions objects and fills in the space between them with accurately positioned positions to form an approximated Geodesic path broken by antimeridian into multiple sub-paths.
        /// </summary>
        /// <param name="path">The positions to interpolate.</param>
        /// <param name="nodeSize">Number of nodes to insert between each position. Default: 15.</param>
        /// <returns>An list of paths that form geodesic paths, Comparing to getGeodesicPath, sub-paths will always contain longitude in -180 to 180 range</returns>
        ValueTask<List<List<Position>>> GetGeodesicPaths(List<Position> path, double? nodeSize = null);

        /// <summary>
        /// Takes a JS object reference of Position[] and fills in the space between its positions with accurately positioned positions to form an approximated Geodesic path broken by antimeridian into multiple sub-paths.
        /// </summary>
        /// <param name="path">The JS object reference to interpolate. Must be a valid Position[] reference.</param>
        /// <param name="nodeSize">Number of nodes to insert between each position. Default: 15.</param>
        /// <returns>An list of paths that form geodesic paths, Comparing to getGeodesicPath, sub-paths will always contain longitude in -180 to 180 range</returns>
        ValueTask<List<List<Position>>> GetGeodesicPaths(IJSObjectReference path, double? nodeSize = null);

        /// <summary>
        /// Calculates the heading from an origin position to a destination position. 
        /// </summary>
        /// <param name="origin">The origin position.</param>
        /// <param name="destination">The destination position.</param>
        /// <returns>A heading in degrees between 0 and 360. 0 degrees points due North.</returns>
        ValueTask<double> GetHeading(Point origin, Point destination);

        /// <summary>
        /// Calculates the heading from an origin position to a destination position. 
        /// </summary>
        /// <param name="origin">The origin position.</param>
        /// <param name="destination">The destination position.</param>
        /// <returns>A heading in degrees between 0 and 360. 0 degrees points due North.</returns>
        ValueTask<double> GetHeading(Position origin, Position destination);

        /// <summary>
        /// Calculates the length of a path defined by a LineString. 
        /// </summary>
        /// <param name="path">The path for which to calculate the length.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <returns>The distance between all positions in between all position objects in an array 
        /// on the surface of a earth in the specified units.</returns>
        ValueTask<double> GetLengthOfPath(LineString path, string? units = null);

        /// <summary>
        /// Calculates the length of a path defined by a list of Position objects. 
        /// </summary>
        /// <param name="path">The path for which to calculate the length.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <returns>The distance between all positions in between all position objects in an array 
        /// on the surface of a earth in the specified units.</returns>
        ValueTask<double> GetLengthOfPath(List<Position> path, string? units = null);

        /// <summary>
        /// Calculates the length of a path defined by a JS object reference for a LineString or list of Positions.
        /// </summary>
        /// <param name="path">The path for which to calculate the length.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <returns>The distance between all positions in between all position objects in an array 
        /// on the surface of a earth in the specified units.</returns>
        ValueTask<double> GetLengthOfPath(IJSObjectReference path, string? units = null);

        /// <summary>
        /// Calculates a position along a path defined by a JS object reference for a LineString or list of Positions at a specified distance from the start of the path.
        /// </summary>
        /// <param name="path">The path for which to calculate the position.</param>
        /// <param name="distance">The distance from the start of the path.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <returns>The position along the path at the specified distance.</returns>

        ValueTask<Position> GetPositionAlongPath(IJSObjectReference path, double distance, string? units = null);

        /// <summary>
        /// Calculates a position along a path defined by a LineString at a specified distance from the start of the path.
        /// </summary>
        /// <param name="path">The path for which to calculate the position.</param>
        /// <param name="distance">The distance from the start of the path.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <returns>The position along the path at the specified distance.</returns>
        ValueTask<Position> GetPositionAlongPath(LineString path, double distance, string? units = null);

        /// <summary>
        /// Calculates a position along a path defined by a list of Positions at a specified distance from the start of the path.
        /// </summary>
        /// <param name="path">The path for which to calculate the position.</param>
        /// <param name="distance">The distance from the start of the path.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <returns>The position along the path at the specified distance.</returns>
        ValueTask<Position> GetPositionAlongPath(List<Position> path, double distance, string? units = null);

        /// <summary>
        /// Calculates a position along a path defined by a JS object reference for a LineString or list of Positions at a specified distance from the start of the path.
        /// </summary>
        /// <param name="path">The path for which to calculate the position.</param>
        /// <param name="distance">The distance from the start of the path.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <returns>The position along the path at the specified distance.</returns>
        ValueTask<Position> GetPositionAlongPath(IJSObjectReference path, double distance, DistanceUnits? units = null);

        /// <summary>
        /// Calculates a position along a path defined by a LineString at a specified distance from the start of the path.
        /// </summary>
        /// <param name="path">The path for which to calculate the position.</param>
        /// <param name="distance">The distance from the start of the path.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <returns>The position along the path at the specified distance.</returns>
        ValueTask<Position> GetPositionAlongPath(LineString path, double distance, DistanceUnits? units = null);

        /// <summary>
        /// Calculates a position along a path defined by a list of Positions at a specified distance from the start of the path.
        /// </summary>
        /// <param name="path">The path for which to calculate the position.</param>
        /// <param name="distance">The distance from the start of the path.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <returns>The position along the path at the specified distance.</returns>
        ValueTask<Position> GetPositionAlongPath(List<Position> path, double distance, DistanceUnits? units = null);

        /// <summary>
        /// Calculates a list of positions that form a regular polygon around a specified origin position.
        /// </summary>
        /// <param name="origin">The origin position around which to form the polygon.</param>
        /// <param name="radius">The radius of the polygon.</param>
        /// <param name="numberOfPositions">The number of positions in the polygon.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <param name="offset">The offset for the polygon. When 0 the first position will align with North. Default: 0</param>
        /// <returns>A list of positions that form the regular polygon.</returns>
        ValueTask<List<Position>> GetRegularPolygonPath(Position origin, double radius, int numberOfPositions, string? units = null, double? offset = null);

        /// <summary>
        /// Calculates a list of positions that form a regular polygon around a specified origin position.
        /// </summary>
        /// <param name="origin">The origin position around which to form the polygon.</param>
        /// <param name="radius">The radius of the polygon.</param>
        /// <param name="numberOfPositions">The number of positions in the polygon.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <param name="offset">The offset for the polygon. When 0 the first position will align with North. Default: 0</param>
        /// <returns>A list of positions that form the regular polygon.</returns>
        ValueTask<List<Position>> GetRegularPolygonPath(Point origin, double radius, int numberOfPositions, string? units = null, double? offset = null);

        /// <summary>
        /// Calculates a list of positions that form a regular polygon around a specified origin position.
        /// </summary>
        /// <param name="origin">The origin position around which to form the polygon.</param>
        /// <param name="radius">The radius of the polygon.</param>
        /// <param name="numberOfPositions">The number of positions in the polygon.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <param name="offset">The offset for the polygon. When 0 the first position will align with North. Default: 0</param>
        /// <returns>A list of positions that form the regular polygon.</returns>
        ValueTask<List<Position>> GetRegularPolygonPath(Position origin, double radius, int numberOfPositions, DistanceUnits? units = null, double? offset = null);

        /// <summary>
        /// Calculates a list of positions that form a regular polygon around a specified origin position.
        /// </summary>
        /// <param name="origin">The origin position around which to form the polygon.</param>
        /// <param name="radius">The radius of the polygon.</param>
        /// <param name="numberOfPositions">The number of positions in the polygon.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <param name="offset">The offset for the polygon. When 0 the first position will align with North. Default: 0</param>
        /// <returns>A list of positions that form the regular polygon.</returns>
        ValueTask<List<Position>> GetRegularPolygonPath(Point origin, double radius, int numberOfPositions, DistanceUnits? units = null, double? offset = null);

        /// <summary>
        /// Calculates a list of lists of positions that form a regular polygon around a specified origin position.
        /// </summary>
        /// <param name="origin">The origin position around which to form the polygon.</param>
        /// <param name="radius">The radius of the polygon.</param>
        /// <param name="numberOfPositions">The number of positions in the polygon.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <param name="offset">The offset for the polygon. When 0 the first position will align with North. Default: 0</param>
        /// <returns>A list of lists of positions that form the regular polygon. 
        /// Comparing to getRegularPolygonPath, sub-paths will always contain longitude in -180 to 180 range</returns>
        ValueTask<List<List<Position>>> GetRegularPolygonPaths(Position origin, double radius, int numberOfPositions, string? units = null, double? offset = null);

        /// <summary>
        /// Calculates a list of lists of positions that form a regular polygon around a specified origin position.
        /// </summary>
        /// <param name="origin">The origin position around which to form the polygon.</param>
        /// <param name="radius">The radius of the polygon.</param>
        /// <param name="numberOfPositions">The number of positions in the polygon.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <param name="offset">The offset for the polygon. When 0 the first position will align with North. Default: 0</param>
        /// <returns>A list of lists of positions that form the regular polygon. 
        /// Comparing to getRegularPolygonPath, sub-paths will always contain longitude in -180 to 180 range</returns>
        ValueTask<List<List<Position>>> GetRegularPolygonPaths(Point origin, double radius, int numberOfPositions, string? units = null, double? offset = null);

        /// <summary>
        /// Calculates a list of lists of positions that form a regular polygon around a specified origin position.
        /// </summary>
        /// <param name="origin">The origin position around which to form the polygon.</param>
        /// <param name="radius">The radius of the polygon.</param>
        /// <param name="numberOfPositions">The number of positions in the polygon.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <param name="offset">The offset for the polygon. When 0 the first position will align with North. Default: 0</param>
        /// <returns>A list of lists of positions that form the regular polygon. 
        /// Comparing to getRegularPolygonPath, sub-paths will always contain longitude in -180 to 180 range</returns>
        ValueTask<List<List<Position>>> GetRegularPolygonPaths(Position origin, double radius, int numberOfPositions, DistanceUnits? units = null, double? offset = null);

        /// <summary>
        /// Calculates a list of lists of positions that form a regular polygon around a specified origin position.
        /// </summary>
        /// <param name="origin">The origin position around which to form the polygon.</param>
        /// <param name="radius">The radius of the polygon.</param>
        /// <param name="numberOfPositions">The number of positions in the polygon.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <param name="offset">The offset for the polygon. When 0 the first position will align with North. Default: 0</param>
        /// <returns>A list of lists of positions that form the regular polygon. 
        /// Comparing to getRegularPolygonPath, sub-paths will always contain longitude in -180 to 180 range</returns>
        ValueTask<List<List<Position>>> GetRegularPolygonPaths(Point origin, double radius, int numberOfPositions, DistanceUnits? units = null, double? offset = null);
    }

    internal class AzMath(Lazy<Task<IJSObjectReference>> moduleTask) : IAzMath
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask<BoundingBox> BoundingBoxToPolygon(BoundingBox boundingBox)
        {
            var results = await BoundingBoxesToPolygons([boundingBox]);
            return results[0];
        }

        public async ValueTask<List<BoundingBox>> BoundingBoxesToPolygons(List<BoundingBox> boundingBoxes)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<BoundingBox>>(GetJsInteropMethod(), boundingBoxes);
        }

        #region Convert Distances

        public async ValueTask<double> ConvertDistance(double distance, DistanceUnits fromUnits, DistanceUnits toUnits, int? decimals = null)
        {
            var results = await ConvertDistances([distance], fromUnits, toUnits, decimals);
            return results[0];
        }

        public async ValueTask<double> ConvertDistance(double distance, string fromUnits, string toUnits, int? decimals = null)
        {
            var result = await ConvertDistances([distance], fromUnits, toUnits, decimals);
            return result[0];
        }

        public async ValueTask<List<double>> ConvertDistances(List<double> distances, DistanceUnits fromUnits, DistanceUnits toUnits, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<double>>(GetJsInteropMethod(), distances, fromUnits, toUnits, decimals);
        }

        public async ValueTask<List<double>> ConvertDistances(List<double> distances, string fromUnits, string toUnits, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<double>>(GetJsInteropMethod(), distances, fromUnits, toUnits, decimals);
        }

        #endregion

        public async ValueTask<List<Position>> GetCardinalSpline(List<Position> positions, double? tension = null, double? nodeSize = null, bool? close = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), positions, tension, nodeSize, close);
        }

        #region GetDestination

        public async ValueTask<Position> GetDestination(Point origin, double heading, double distance, string? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), origin, heading, distance, units);
        }

        public async ValueTask<Position> GetDestination(Position origin, double heading, double distance, string? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), origin, heading, distance, units);
        }

        public async ValueTask<Position> GetDestination(Point origin, double heading, double distance, DistanceUnits? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), origin, heading, distance, units);
        }

        public async ValueTask<Position> GetDestination(Position origin, double heading, double distance, DistanceUnits? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), origin, heading, distance, units);
        }

        #endregion

        #region GetDistances

        public async ValueTask<double> GetDistanceTo(Point origin, Point destination, string? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination, units);
        }

        public async ValueTask<double> GetDistanceTo(Position origin, Position destination, string? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination, units);
        }
        public async ValueTask<double> GetDistanceTo(Point origin, Point destination, DistanceUnits? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination, units);
        }

        public async ValueTask<double> GetDistanceTo(Position origin, Position destination, DistanceUnits? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination, units);
        }

        #endregion

        #region GetEarthRadius

        public async ValueTask<double> GetEarthRadius(string? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), units);
        }

        public async ValueTask<double> GetEarthRadius(DistanceUnits? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), units);
        }

        #endregion

        #region GetGeodesicPath

        public async ValueTask<List<Position>> GetGeodesicPath(List<Position> path, double? nodeSize = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), path, nodeSize);
        }

        public async ValueTask<List<Position>> GetGeodesicPath(LineString path, double? nodeSize = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), path, nodeSize);
        }

        public async ValueTask<List<Position>> GetGeodesicPath(IJSObjectReference path, double? nodeSize = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), path, nodeSize);
        }

        #endregion

        #region GetGeodesicPaths

        public async ValueTask<List<List<Position>>> GetGeodesicPaths(List<Position> path, double? nodeSize = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<List<Position>>>(GetJsInteropMethod(), path, nodeSize);
        }

        public async ValueTask<List<List<Position>>> GetGeodesicPaths(IJSObjectReference path, double? nodeSize = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<List<Position>>>(GetJsInteropMethod(), path, nodeSize);
        }

        #endregion

        #region GetHeading

        public async ValueTask<double> GetHeading(Point origin, Point destination)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination);
        }

        public async ValueTask<double> GetHeading(Position origin, Position destination)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination);
        }

        #endregion

        #region GetLengthOfPath

        public async ValueTask<double> GetLengthOfPath(LineString path, string? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), path, units);
        }

        public async ValueTask<double> GetLengthOfPath(List<Position> path, string? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), path, units);
        }

        public async ValueTask<double> GetLengthOfPath(IJSObjectReference path, string? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), path, units);
        }

        #endregion

        #region GetPositionAlongPath

        public async ValueTask<Position> GetPositionAlongPath(IJSObjectReference path, double distance, string? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), path, distance, units);
        }

        public async ValueTask<Position> GetPositionAlongPath(LineString path, double distance, string? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), path, distance, units);
        }

        public async ValueTask<Position> GetPositionAlongPath(List<Position> path, double distance, string? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), path, distance, units);
        }

        public async ValueTask<Position> GetPositionAlongPath(IJSObjectReference path, double distance, DistanceUnits? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), path, distance, units);
        }

        public async ValueTask<Position> GetPositionAlongPath(LineString path, double distance, DistanceUnits? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), path, distance, units);
        }

        public async ValueTask<Position> GetPositionAlongPath(List<Position> path, double distance, DistanceUnits? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), path, distance, units);
        }

        #endregion

        #region getRegularPolygonPath
        
        public async ValueTask<List<Position>> GetRegularPolygonPath(Position origin, double radius, int numberOfPositions, string? units = null, double? offset = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), origin, radius, numberOfPositions, units, offset);
        }

        public async ValueTask<List<Position>> GetRegularPolygonPath(Point origin, double radius, int numberOfPositions, string? units = null, double? offset = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), origin, radius, numberOfPositions, units, offset);
        }

        public async ValueTask<List<Position>> GetRegularPolygonPath(Position origin, double radius, int numberOfPositions, DistanceUnits? units = null, double? offset = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), origin, radius, numberOfPositions, units, offset);
        }

        public async ValueTask<List<Position>> GetRegularPolygonPath(Point origin, double radius, int numberOfPositions, DistanceUnits? units = null, double? offset = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), origin, radius, numberOfPositions, units, offset);
        }

        #endregion

        #region getRegularPolygonPaths
        
        public async ValueTask<List<List<Position>>> GetRegularPolygonPaths(Position origin, double radius, int numberOfPositions, string? units = null, double? offset = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<List<Position>>>(GetJsInteropMethod(), origin, radius, numberOfPositions, units, offset);
        }

        public async ValueTask<List<List<Position>>> GetRegularPolygonPaths(Point origin, double radius, int numberOfPositions, string? units = null, double? offset = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<List<Position>>>(GetJsInteropMethod(), origin, radius, numberOfPositions, units, offset);
        }

        public async ValueTask<List<List<Position>>> GetRegularPolygonPaths(Position origin, double radius, int numberOfPositions, DistanceUnits? units = null, double? offset = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<List<Position>>>(GetJsInteropMethod(), origin, radius, numberOfPositions, units, offset);
        }

        public async ValueTask<List<List<Position>>> GetRegularPolygonPaths(Point origin, double radius, int numberOfPositions, DistanceUnits? units = null, double? offset = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<List<Position>>>(GetJsInteropMethod(), origin, radius, numberOfPositions, units, offset);
        }

        #endregion

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.Math.GetJsModuleMethod(name);
    }
}

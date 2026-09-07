using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models.Math;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;
using Marqdouj.DotNet.Web.JsInterop.GeoJson;
using Microsoft.JSInterop;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Interface for Azure Maps Math module.
    /// For methods that accept an <see cref="IJSObjectReference"/> you can use <see cref="IAzureMapsSources.GetJSShapeById(string, string, string)"/> method.
    /// </summary>
    public interface IAzureMapsMath
    {
        /// <summary>
        /// Takes a list of <see cref="BoundingBox"/> and converts them to polygons.
        /// </summary>
        /// <param name="boundingBoxes">The List of BoundingBoxes to convert to Polygons. May be an <see cref="IJSObjectReference"/></param>
        /// <returns></returns>
        ValueTask<List<Polygon>> BoundingBoxesToPolygons<T>(T boundingBoxes) where T: IJSObjectReference, IEnumerable<BoundingBox>;

        /// <summary>
        /// Converts an acceleration from one acceleration units to another. 
        /// Supported units: <see cref="AccelerationUnits"/>
        /// </summary>
        /// <param name="acceleration">The acceleration value to convert.</param>
        /// <param name="fromUnits">The units to convert from.</param>
        /// <param name="toUnits">The units to convert to.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>An acceleration value convertered from one unit to another.</returns>
        ValueTask<double> ConvertAcceleration(double acceleration, AccelerationUnits fromUnits, AccelerationUnits toUnits, int? decimals = null);

        /// <summary>
        /// Converts a list of distances from one distance units to another.
        /// Supported units: <see cref="DistanceUnits"/>
        /// </summary>
        /// <param name="distances">The distances to convert</param>
        /// <param name="fromUnits">The units to convert from</param>
        /// <param name="toUnits">The units to convert to</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns></returns>
        ValueTask<List<double>> ConvertDistances(List<double> distances, DistanceUnits fromUnits, DistanceUnits toUnits, int? decimals = null);

        /// <summary>
        /// Converts an area from one area units to another. 
        /// Supported units: <see cref="AreaUnits"/>
        /// </summary>
        /// <param name="area">The area value to convert.</param>
        /// <param name="fromUnits">The units to convert from.</param>
        /// <param name="toUnits">The units to convert to.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>An area value converted from one unit to another.</returns>
        ValueTask<double> ConvertArea(double area, AreaUnits fromUnits, AreaUnits toUnits, int? decimals = null);

        /// <summary>
        /// Converts a speed from one speed units to another. 
        /// Supported units: <see cref="SpeedUnits"/>
        /// </summary>
        /// <param name="speed">The speed value to convert.</param>
        /// <param name="fromUnits">The speed units to convert from.</param>
        /// <param name="toUnits">The speed units to convert to.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>A speed value convertered from one unit to another.</returns>
        ValueTask<double> ConvertSpeed(double speed, SpeedUnits fromUnits, SpeedUnits toUnits, int? decimals = null);

        /// <summary>
        /// Converts a timespan from one time units to another. 
        /// Supported units: <see cref="TimeUnits"/>
        /// </summary>
        /// <param name="timespan">The timespan value to convert.</param>
        /// <param name="fromUnits">The time units to convert from.</param>
        /// <param name="toUnits">The time units to convert to.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>A timespan value converted from one unit to another.</returns>
        ValueTask<double> ConvertTimeSpan(double timespan, TimeUnits fromUnits, TimeUnits toUnits, int? decimals = null);

        /// <summary>
        /// Calculates the acceleration based on an initial speed, distance, and timespan.
        /// </summary>
        /// <param name="initialSpeed">The initial speed.</param>
        /// <param name="distance">The distance.</param>
        /// <param name="timespan">The timespan.</param>
        /// <param name="speedUnits">The units for the speed. If not specified m/s are used.</param>
        /// <param name="distanceUnits">The units for the distance. If not specified meters are used.</param>
        /// <param name="timeUnits">The units for the timespan. If not specified seconds are used.</param>
        /// <param name="accelerationUnits">The units for the acceleration. If not specified m/s^2 are used.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>The calculated acceleration.</returns>
        ValueTask<double> GetAcceleration(double initialSpeed, double distance, double timespan, SpeedUnits? speedUnits = null, DistanceUnits? distanceUnits = null, TimeUnits? timeUnits = null, AccelerationUnits? accelerationUnits = null, int? decimals = null);

        /// <summary>
        /// Calculates an acceleration between two point features that have a timestamp property and optionally a speed property.
        /// If speeds are provided, ignore distance between points as the path may not have been straight and calculate: a = (v2 - v1)/(t2 - t1).
        /// If speeds are not provided or only provided on first point, calculate straight line distance between points and calculate: a = 2*(d - v*t)/t^2.
        /// </summary>
        /// <param name="origin">The initial point in which the acceleration is calculated from. 
        /// Must be Feature{Point, P?} or an <see cref="IJSObjectReference"/> to a Feature{Point, P?}.</param>
        /// <param name="destination">The destination point for which the acceleration is calculated. 
        /// Must be Feature{Point, P?} or an <see cref="IJSObjectReference"/> to a Feature{Point, P?}.</param>
        /// <param name="timestampProperty">The property name for the timestamp.</param>
        /// <param name="speedProperty">The property name for the speed.</param>
        /// <param name="speedUnits">The units for the speed. If not specified m/s are used.</param>
        /// <param name="accelerationUnits">The units for the acceleration. If not specified m/s^2 are used.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>An acceleration between two point features that have a timestamp property and optionally a speed property. 
        /// Returns NaN if unable to parse timestamp.</returns>
        ValueTask<double> GetAccelerationFromFeatures<T, P>(T origin, T destination, string timestampProperty, string? speedProperty = null, SpeedUnits? speedUnits = null, AccelerationUnits? accelerationUnits = null, int? decimals = null)
            where T : IJSObjectReference, IFeature<Point, P>
            where P : class;

        /// <summary>
        /// Converts an array of points from the target reference system to the source reference system.
        /// </summary>
        /// <param name="source">A set of reference points from the source reference system to transform from.</param>
        /// <param name="target">A set of reference points from the target reference system to transform to.</param>
        /// <param name="targetPoints">An array of points from the target reference system to transform.</param>
        /// <param name="decimals">Number of decimal places to round the results off to.</param>
        /// <returns>An array of points that have been transformed to the source reference system.</returns>
        ValueTask<double[][]> GetAffineTransformToSource(double[][] source, double[][] target, double[][] targetPoints, int? decimals = null);

        /// <summary>
        /// Converts an array of points from the source reference system to the target reference system.
        /// </summary>
        /// <param name="source">A set of reference points from the source reference system to transform from.</param>
        /// <param name="target">A set of reference points from the target reference system to transform to.</param>
        /// <param name="sourcePoints">An array of points from the source reference system to transform.</param>
        /// <param name="decimals">Number of decimal places to round the results off to.</param>
        /// <returns>An array of points that have been transformed to the target reference system.</returns>
        ValueTask<double[][]> GetAffineTransformToTarget(double[][] source, double[][] target, double[][] sourcePoints, int? decimals = null);

        /// <summary>
        /// Calculates the acceleration based on an initial speed, final speed, and timespan.
        /// </summary>
        /// <param name="initialSpeed">The initial speed.</param>
        /// <param name="finalSpeed">The final speed.</param>
        /// <param name="timespan">The timespan.</param>
        /// <param name="speedUnits">The units for the speed. If not specified meters are used.</param>
        /// <param name="timeUnits">The units for the timespan. If not specified seconds are used.</param>
        /// <param name="accelerationUnits">The units for the acceleration. If not specified m/s^2 are used.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>The calculated acceleration.</returns>
        ValueTask<double> GetAccelerationFromSpeeds(double initialSpeed, double finalSpeed, double timespan, SpeedUnits? speedUnits = null, TimeUnits? timeUnits = null, AccelerationUnits? accelerationUnits = null, int? decimals = null);

        /// <summary>
        /// Calculates the approximate area of a geometry in the specified units.
        /// </summary>
        /// <param name="data">The Feature{Geometry, P}, or an <see cref="IJSObjectReference"/> to a Feature{Geometry, P}, for which to calculate the area.</param>
        /// <param name="areaUnits">The units for the area. If not specified square meters are used.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>The calculated area.</returns>
        ValueTask<double> GetArea<T, P>(T data, AreaUnits? areaUnits = null, int? decimals = null) where T: IJSObjectReference, IFeature<Geometry, P?> where P : class;

        /// <summary>
        /// Calculates an array of positions that form a cardinal spline between the specified array of positions.
        /// </summary>
        /// <param name="positions">The positions to calculate the spline through. May be an <see cref="IJSObjectReference"/></param>
        /// <param name="tension">A number that indicates the tightness of the curve. Can be any number, although a value between 0 and 1 is usually used. Default: 0.5</param>
        /// <param name="nodeSize">Number of nodes to insert between each position. Default: 15</param>
        /// <param name="close">Whether to close the spline. Default: false</param>
        /// <returns></returns>
        ValueTask<List<Position>> GetCardinalSpline<T>(T positions, double? tension = null, double? nodeSize = null, bool? close = null) where T: IJSObjectReference, IEnumerable<Position>;

        /// <summary>
        /// Calculates the closest point on the edge of a geometry to a specified point or position.
        /// </summary>
        /// <typeparam name="TPoint"></typeparam>
        /// <typeparam name="TGeom"></typeparam>
        /// <typeparam name="P"></typeparam>
        /// <param name="pt"><see cref="Position"/>, <see cref="Point"/>, Feature{Point, P?}. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="geom"><see cref="IGeometry"/> or Feature{Geometry, P?}. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="units">Unit of distance measurement. Default is meters.</param>
        /// <param name="decimals">The number of decimal places to round the result to.</param>
        /// <returns></returns>
        ValueTask<Feature<Point, DistanceProperties>> GetClosestPointOnGeometry<TPoint, TGeom, P>(TPoint pt, TGeom geom, DistanceUnits? units, double? decimals)
            where TPoint : IPosition, IPoint, IFeature<Point, P?>
            where TGeom : IGeometry, IFeature<Geometry, P?>
            where P : class;

        /// <summary>
        /// Calculates the convex hull of a set of positions or geometries. 
        /// The convex hull is the smallest polygon that contains all the points in the input data.
        /// </summary>
        /// <param name="data">
        /// The input data for which to calculate the convex hull.
        /// Formats supported include:
        /// Position[] | Geometry | Feature{Geometry, any} | FeatureCollection | GeometryCollection | Geometry[] | Feature{Geometry, any}[],
        /// or an <see cref="IJSObjectReference"/> including Shape[] | Shape.
        /// </param>
        /// <returns>The convex hull as a polygon.</returns>
        ValueTask<Polygon> GetConvexHull<T, P>(T data)
            where T : IJSObjectReference, IEnumerable<Position>, IGeometry, IEnumerable<Geometry>, IFeature<Geometry, P>, IEnumerable<IFeature<Geometry, P>>, IFeatureCollection, IGeometryCollection
            where P : class;

        /// <summary>
        /// Calculates a destination position based on a starting position, a heading, a distance, and a distance unit type.
        /// </summary>
        /// <param name="origin">Position or Point that the destination is relative to. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="heading">A heading angle between 0 - 360 degrees. 0 - North, 90 - East, 180 - South, 270 - West.</param>
        /// <param name="distance">Distance that destination is away.</param>
        /// <param name="units">Unit of distance measurement. Default is meters.</param>
        /// <returns>A position that is the specified distance away from the origin.</returns>
        ValueTask<Position> GetDestination<T>(T origin, double heading, double distance, DistanceUnits? units = null) where T: IJSObjectReference, IPoint, IPosition;

        /// <summary>
        /// Calculates the distance between two position/point objects on the surface of the earth using the Haversine formula.
        /// </summary>
        /// <param name="origin"><see cref="Position"/> or <see cref="Point"/>. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="destination"><see cref="Position"/> or <see cref="Point"/>. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="units">The unit of distance measurement. Default is meters.</param>
        /// <returns>The distance between the two positions.</returns>
        ValueTask<double> GetDistanceTo<T>(T origin, T destination, DistanceUnits? units = null) where T: IJSObjectReference, IPoint, IPosition;

        /// <summary>
        /// Retrieves the radius of the earth in a specific distance unit for WGS84.
        /// </summary>
        /// <param name="units">The unit of distance measurement. Default is meters.</param>
        /// <returns>The radius of the earth.</returns>
        ValueTask<double> GetEarthRadius(DistanceUnits? units = null);

        /// <summary>
        /// Takes a path and fills in the space between its positions with accurately positioned positions to form an approximated Geodesic path.
        /// </summary>
        /// <param name="path">List of <see cref="Position"/> or a <see cref="LineString"/>. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="nodeSize">Number of nodes to insert between each position. Default: 15.</param>
        /// <returns>The interpolated geodesic path. A geodesic path crossing antimeridian will contain longitude outside of -180 to 180 range. 
        /// See <see cref="IAzureMapsMath.GetGeodesicPaths{T}(T, double?)"/> when this is undesired.</returns>
        ValueTask<List<Position>> GetGeodesicPath<T>(T path, double? nodeSize = null) where T: IJSObjectReference, IEnumerable<Position>, ILineString;

        /// <summary>
        /// Takes an array of positions objects and fills in the space between them with accurately positioned positions
        /// to form an approximated Geodesic path broken by antimeridian into multiple sub-paths.
        /// </summary>
        /// <param name="path">List of <see cref="Position"/> or a <see cref="LineString"/>. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="nodeSize">Number of nodes to insert between each position. Default: 15.</param>
        /// <returns>An list of paths that form geodesic paths, Comparing to <see cref="IAzureMapsMath.GetGeodesicPath{T}(T, double?)"/>, 
        /// sub-paths will always contain longitude in -180 to 180 range</returns>
        ValueTask<List<List<Position>>> GetGeodesicPaths<T>(T path, double? nodeSize = null) where T : IJSObjectReference, IEnumerable<Position>, ILineString;

        /// <summary>
        /// Calculates the heading from an origin position to a destination position. 
        /// </summary>
        /// <param name="origin"><see cref="Point"/> or <see cref="Position"/>. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="destination">The destination position.</param>
        /// <returns>A heading in degrees between 0 and 360. 0 degrees points due North.</returns>
        ValueTask<double> GetHeading<T>(T origin, T destination) where T: IJSObjectReference, IPoint, IPosition;

        /// <summary>
        /// Calculates the length of a path.
        /// </summary>
        /// <param name="path">List of <see cref="Position"/> or a <see cref="LineString"/>. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <returns>The distance between all positions in between all position objects in an array 
        /// on the surface of a earth in the specified units.</returns>
        ValueTask<double> GetLengthOfPath<T>(T path, DistanceUnits? units = null) where T: IJSObjectReference, IEnumerable<Position>, ILineString;

        /// <summary>
        /// Denormalizes path on antimeridian, this makes lines with coordinates on the opposite side of the antimeridian to always cross it.
        /// Note that the path crossing antimeridian will contain longitude outside of -180 to 180 range.
        /// See <see cref="IAzureMapsMath.GetPathSplitByAntimeridian{T}(T)"/> when this is not desired.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">List of position objects or linestring to denormalize. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns>A denormalized list of position objects, path crossing antimeridian will contain longitude outside of -180 to 180 range.</returns>
        ValueTask<List<Position>> GetPathDenormalizedAtAntimerian<T>(T path) where T : IJSObjectReference, IEnumerable<Position>, ILineString;

        /// <summary>
        /// Split path on antimeridian into multiple paths.
        /// See <see cref="IAzureMapsMath.GetPathDenormalizedAtAntimerian{T}(T)"/> when this is not desired.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">>List of position objects or linestring to split. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns>A path split into multiple paths by antimeridian.</returns>
        ValueTask<List<List<Position>>> GetPathSplitByAntimeridian<T>(T path) where T : IJSObjectReference, IEnumerable<Position>, ILineString;

        /// <summary>
        /// Calculates the pixel accurate heading from one position to another based on the Mercator map projection.
        /// </summary>
        /// <param name="origin"><see cref="Position"/> or <see cref="Point"/>. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="destination"><see cref="Position"/> or <see cref="Point"/>. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns></returns>
        ValueTask<double> GetPixelHeading<T>(T origin, T destination) where T : IGeoJsonObject, IPosition, IPoint;

        /// <summary>
        /// Gets a point with heading a specified distance along a path.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">List of <see cref="Position"/> or a <see cref="LineString"/>. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="distance">The distance along the path to get the point at.</param>
        /// <param name="units">The distance units.</param>
        /// <returns>A point with heading a specified distance along a path.</returns>
        ValueTask<Feature<Point, HeadingProperties>> GetPointWithHeadingAlongPath<T>(T path, double distance, DistanceUnits? units) where T : IJSObjectReference, IEnumerable<Position>, ILineString;

        /// <summary>
        /// Gets an array of evenly spaced points with headings along a path.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">List of <see cref="Position"/> or a <see cref="LineString"/>. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="numPoints">The number of points to get.</param>
        /// <returns>An array of evenly spaced points with headings along a path.</returns>
        ValueTask<List<Feature<Point, HeadingProperties>>> GetPointsWithHeadingAlongPath<T>(T path, double numPoints) where T : IJSObjectReference, IEnumerable<Position>, ILineString;

        /// <summary>
        /// Gets the position of an object that is a position, point, point feature, or circle. If it is a circle, its center coordinate will be returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="P"></typeparam>
        /// <param name="data">Position, point, point feature, or circle. May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns></returns>
        ValueTask<Position> GetPosition<T, P>(T data) where T : IJSObjectReference, IPosition, IPoint, IFeature<Point,  P?> where P : class;

        /// <summary>
        /// Calculates a position along a path.
        /// </summary>
        /// <param name="path">List of <see cref="Position"/> or a <see cref="LineString"/>. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="distance">The distance from the start of the path.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <returns>The position along the path at the specified distance.</returns>
        ValueTask<Position> GetPositionAlongPath<T>(T path, double distance, DistanceUnits? units = null) where T : IJSObjectReference, IEnumerable<Position>, ILineString;

        /// <summary>
        /// Retrieves a list of all positions in the provided geometry, feature or array of geometries/features or shapes/shape.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="P"></typeparam>
        /// <param name="data">Position[], IGeometry, IFeature{Geometry, P?}, IFeatureCollection, IGeometryCollection, Geometry[], or Shape[]/Shape.
        /// May be an <see cref="IJSObjectReference"/>.</param>
        /// <returns>A list of positions.</returns>
        ValueTask<List<Position>> GetPositions<T, P>(T data) 
            where T : IJSObjectReference, IEnumerable<Position>, IGeometry, IFeature<Geometry, P?>, IFeatureCollection, IGeometryCollection, IEnumerable<Geometry>
            where P: class;

        /// <summary>
        /// Gets an array of evenly spaced positions along a path.
        /// </summary>
        /// <typeparam name="T">List of <see cref="Position"/> or a <see cref="LineString"/>. May be an <see cref="IJSObjectReference"/>.</typeparam>
        /// <param name="path">The path to get the positions from.</param>
        /// <param name="numPositions">The number of positions to get.</param>
        /// <returns></returns>
        ValueTask<List<Position>> GetPositionsAlongPath<T>(T path, long numPositions) where T : IJSObjectReference, IEnumerable<Position>, ILineString;

        /// <summary>
        /// Calculates a list of positions that form a regular polygon around a specified origin position.
        /// </summary>
        /// <param name="origin"><see cref="Position"/> or <see cref="Point"/>. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="radius">The radius of the polygon.</param>
        /// <param name="numberOfPositions">The number of positions in the polygon.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <param name="offset">The offset for the polygon. When 0 the first position will align with North. Default: 0</param>
        /// <returns>A list of positions that form the regular polygon.</returns>
        ValueTask<List<Position>> GetRegularPolygonPath<T>(T origin, double radius, int numberOfPositions, DistanceUnits? units = null, double? offset = null)
            where T: IJSObjectReference, IPosition, IPoint;

        /// <summary>
        /// Calculates a list of positions that form a regular polygon around a specified origin position.
        /// </summary>
        /// <param name="origin"><see cref="Position"/> or <see cref="Point"/>. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="radius">The radius of the polygon.</param>
        /// <param name="numberOfPositions">The number of positions in the polygon.</param>
        /// <param name="units">Unit of distance measurement. Default: meters</param>
        /// <param name="offset">The offset for the polygon. When 0 the first position will align with North. Default: 0</param>
        /// <returns>A list of lists of positions that form the regular polygon. 
        /// Comparing to <see cref="IAzureMapsMath.GetRegularPolygonPaths{T}(T, double, int, DistanceUnits?, double?)"/>, sub-paths will always contain longitude in -180 to 180 range</returns>
        ValueTask<List<List<Position>>> GetRegularPolygonPaths<T>(T origin, double radius, int numberOfPositions, DistanceUnits? units = null, double? offset = null)
            where T : IJSObjectReference, IPosition, IPoint;

        /// <summary>
        /// Calculates the average speed of travel between two points based on the provided amount of time.
        /// </summary>
        /// <param name="origin"><see cref="Position"/>, <see cref="Point"/>, or Feature{Point, P?}. Many be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="destination"><see cref="Position"/>, <see cref="Point"/>, or Feature{Point, P?}. Many be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="timespan">The time span over which the speed is calculated.</param>
        /// <param name="timeUnits">The units for the time span. Default: seconds</param>
        /// <param name="speedUnits">The units for the speed. Default: meters/second</param>
        /// <param name="decimals">The number of decimal places to round the result to.</param>
        /// <returns>The average speed of travel between the two points.</returns>
        ValueTask<double> GetSpeed<T, P>(T origin, T destination, double timespan, TimeUnits? timeUnits = null, SpeedUnits? speedUnits = null, int? decimals = null) 
            where T : IJSObjectReference, IPosition, IPoint, IFeature<Point, P?>
            where P : class;

        /// <summary>
        /// Calculates the average speed of travel between two features based on the timestamp property of each feature.
        /// </summary>
        /// <typeparam name="T"> Feature{Point, P?}. May be an <see cref="IJSObjectReference"/>.</typeparam>
        /// <typeparam name="P">Feature{Point, P?}.  May be an <see cref="IJSObjectReference"/>.</typeparam>
        /// <param name="origin">The initial point in which the speed is calculated from.</param>
        /// <param name="destination">The final point in which the speed is calculated to.</param>
        /// <param name="timestampProperty">The property name for the timestamp values.</param>
        /// <param name="speedUnits">The units for the speed. Default: meters/second</param>
        /// <param name="decimals">The number of decimal places to round the result to.</param>
        /// <returns>The speed in the specified units or NaN if valid timestamps are not found.</returns>
        ValueTask<double> GetSpeedFromFeatures<T, P>(T origin, T destination, string timestampProperty, SpeedUnits? speedUnits = null, int? decimals = null) where T : IJSObjectReference, IFeature<Point, P?>;

        /// <summary>
        /// Calculates the distance traveled based on a given time span, speed, and optional acceleration.
        /// Formula: d = v*t + 0.5*a*t^2
        /// </summary>
        /// <param name="timespan">The timespan to calculate the distance for.</param>
        /// <param name="speed">The speed at which the distance is traveled.</param>
        /// <param name="distanceUnits">The units for the distance. Default: meters</param>
        /// <param name="timeUnits">The units for the time span. Default: seconds</param>
        /// <param name="speedUnits">The units for the speed. Default: meters/second</param>
        /// <param name="accelerationUnits">The units for the acceleration. Default: meters/second^2</param>
        /// <param name="acceleration">The acceleration during the travel. Default: 0</param>
        /// <param name="decimals">The number of decimal places to round the result to.</param>
        /// <returns>The calculated travel distance.</returns>
        ValueTask<double> GetTravelDistance(double timespan, double speed, DistanceUnits? distanceUnits = null, TimeUnits? timeUnits = null, SpeedUnits? speedUnits = null, AccelerationUnits? accelerationUnits = null, double? acceleration = null, int? decimals = null);

        /// <summary>
        /// Calculates a position along a path defined by an origin and destination at a specified fraction of the distance between the two positions.
        /// </summary>
        /// <param name="origin">The origin <see cref="Position"/>. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="destination">The destination <see cref="Position"/>. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="fraction">The fraction of the distance between the two positions. Default 0.5.</param>
        /// <returns>The interpolated position.</returns>
        ValueTask<Position> Interpolate<T>(T origin, T destination, double? fraction = null) where T : IJSObjectReference, IPosition;

        /// <summary>
        /// Converts an array of global Mercator pixel coordinates into an array of geospatial positions at a specified zoom level.
        /// Global pixel coordinates are relative to the top left corner of the map [-180, 90].
        /// </summary>
        /// <param name="pixels">The list of pixels to convert. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="zoom">The zoom level.</param>
        /// <returns>The list of converted positions.</returns>
        ValueTask<List<Position>> MercatorPixelsToPositions<T>(T pixels, double zoom) where T : IJSObjectReference, IEnumerable<Pixel>;

        /// <summary>
        /// Converts an array of positions into an array of global Mercator pixel coordinates at a specified zoom level.
        /// </summary>
        /// <param name="positions">The list of <see cref="Position"/> to convert. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="zoom">The zoom level.</param>
        /// <returns>The list of converted global Mercator pixels.</returns>
        ValueTask<List<Pixel>> MercatorPositionsToPixels<T>(T positions, double zoom) where T : IJSObjectReference, IEnumerable<Position>;

        /// <summary>
        /// Normalizes a latitude value to be within the range of -90 to 90 degrees.
        /// </summary>
        /// <param name="lat">The latitude value to normalize.</param>
        /// <returns>The normalized latitude value.</returns>
        ValueTask<double> NormalizeLatitude(double lat);

        /// <summary>
        /// Normalizes a longitude value to be within the range of -180 to 180 degrees.
        /// </summary>
        /// <param name="lng">The longitude value to normalize.</param>
        /// <returns>The normalized longitude value.</returns>
        ValueTask<double> NormalizeLongitude(double lng);

        /// <summary>
        /// Rotates a list of positions around a specified origin by a given angle in degrees.
        /// </summary>
        /// <param name="positions">The list of <see cref="Position"/> or <see cref="Point"/> to rotate. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="origin">The <see cref="Position"/> or <see cref="Point"/> around which to rotate. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="angle">The amount to rotate in degrees clockwise.</param>
        /// <returns>The list of rotated positions.</returns>
        ValueTask<List<Position>> RotatePositions<T, TOrigin>(T positions, TOrigin origin, double angle) 
            where T : IJSObjectReference, IEnumerable<Position>, IEnumerable<Point>
            where TOrigin : IJSObjectReference, IPosition, IPoint;

        /// <summary>
        /// Perform a Douglas-Peucker simplification on an array of positions.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="points">The positions to simplify. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="tolerance">A tolerance to use in the simplification.</param>
        /// <returns></returns>
        ValueTask<List<Position>> SimplifyPositions<T>(T points, double tolerance) where T : IJSObjectReference, IEnumerable<Position>;

        /// <summary>
        /// Perform a Douglas-Peucker simplification on an array of pixels.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="points">The pixels to simplify. May be an <see cref="IJSObjectReference"/>.</param>
        /// <param name="tolerance">A tolerance to use in the simplification.</param>
        /// <returns></returns>
        ValueTask<List<Pixel>> SimplifyPixels<T>(T points, double tolerance) where T : IJSObjectReference, IEnumerable<Pixel>;
    }

    internal class AzMath(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsMath
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask<List<Polygon>> BoundingBoxesToPolygons<T>(T boundingBoxes) where T : IJSObjectReference, IEnumerable<BoundingBox>
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Polygon>>(GetJsInteropMethod(), boundingBoxes);
        }

        public async ValueTask<List<double>> ConvertDistances(List<double> distances, DistanceUnits fromUnits, DistanceUnits toUnits, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<double>>(GetJsInteropMethod(), distances, fromUnits, toUnits, decimals);
        }

        public async ValueTask<double> ConvertAcceleration(double acceleration, AccelerationUnits fromUnits, AccelerationUnits toUnits, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), acceleration, fromUnits, toUnits, decimals);
        }

        public async ValueTask<double> ConvertArea(double area, AreaUnits fromUnits, AreaUnits toUnits, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), area, fromUnits, toUnits, decimals);
        }

        public async ValueTask<double> ConvertSpeed(double speed, SpeedUnits fromUnits, SpeedUnits toUnits, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), speed, fromUnits, toUnits, decimals);
        }

        public async ValueTask<double> ConvertTimeSpan(double timespan, TimeUnits fromUnits, TimeUnits toUnits, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), timespan, fromUnits, toUnits, decimals);
        }

        public async ValueTask<double> GetAcceleration(double initialSpeed, double distance, double timespan, SpeedUnits? speedUnits = null, DistanceUnits? distanceUnits = null, TimeUnits? timeUnits = null, AccelerationUnits? accelerationUnits = null, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), initialSpeed, distance, timespan, speedUnits, distanceUnits, timeUnits, accelerationUnits, decimals);
        }

        public async ValueTask<double> GetAccelerationFromFeatures<T, P>(T origin, T destination, string timestampProperty, string? speedProperty = null, SpeedUnits? speedUnits = null, AccelerationUnits? accelerationUnits = null, int? decimals = null)
            where T : IJSObjectReference, IFeature<Point, P>
            where P : class
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination, timestampProperty, speedProperty, speedUnits, accelerationUnits, decimals);
        }

        public async ValueTask<double> GetAccelerationFromSpeeds(double initialSpeed, double finalSpeed, double timespan, SpeedUnits? speedUnits = null, TimeUnits? timeUnits = null, AccelerationUnits? accelerationUnits = null, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), initialSpeed, finalSpeed, timespan, speedUnits, timeUnits, accelerationUnits, decimals);
        }

        public async ValueTask<double[][]> GetAffineTransformToSource(double[][] source, double[][] target, double[][] targetPoints, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double[][]>(GetJsInteropMethod(), source, target, targetPoints, decimals);
        }

        public async ValueTask<double[][]> GetAffineTransformToTarget(double[][] source, double[][] target, double[][] sourcePoints, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double[][]>(GetJsInteropMethod(), source, target, sourcePoints, decimals);
        }

        public async ValueTask<double> GetArea<T, P>(T data, AreaUnits? areaUnits = null, int? decimals = null)
            where T : IJSObjectReference, IFeature<Geometry, P?>
            where P : class
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), data, areaUnits, decimals);
        }

        public async ValueTask<List<Position>> GetCardinalSpline<T>(T positions, double? tension = null, double? nodeSize = null, bool? close = null) where T : IJSObjectReference, IEnumerable<Position>
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), positions, tension, nodeSize, close);
        }

        public async ValueTask<Feature<Point, DistanceProperties>> GetClosestPointOnGeometry<TPoint, TGeom, P>(TPoint pt, TGeom geom, DistanceUnits? units, double? decimals)
            where TPoint : IPosition, IPoint, IFeature<Point, P?>
            where TGeom : IGeometry, IFeature<Geometry, P?>
            where P : class
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Feature<Point, DistanceProperties>>(GetJsInteropMethod(), pt, geom, units, decimals);
        }

        public async ValueTask<Polygon> GetConvexHull<T, P>(T data)
            where T : IJSObjectReference, IEnumerable<Position>, IGeometry, IEnumerable<Geometry>, IFeature<Geometry, P>, IEnumerable<IFeature<Geometry, P>>, IFeatureCollection, IGeometryCollection
            where P : class
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Polygon>(GetJsInteropMethod(), data);
        }
        
        public async ValueTask<Position> GetDestination<T>(T origin, double heading, double distance, DistanceUnits? units = null) where T : IJSObjectReference, IPoint, IPosition
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), origin, heading, distance, units);
        }

        public async ValueTask<double> GetDistanceTo<T>(T origin, T destination, DistanceUnits? units = null) where T : IJSObjectReference, IPoint, IPosition
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination, units);
        }

        public async ValueTask<double> GetEarthRadius(DistanceUnits? units = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), units);
        }

        public async ValueTask<List<Position>> GetGeodesicPath<T>(T path, double? nodeSize = null) where T : IJSObjectReference, IEnumerable<Position>, ILineString
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), path, nodeSize);
        }

        public async ValueTask<List<List<Position>>> GetGeodesicPaths<T>(T path, double? nodeSize = null) where T : IJSObjectReference, IEnumerable<Position>, ILineString
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<List<Position>>>(GetJsInteropMethod(), path, nodeSize);
        }

        public async ValueTask<double> GetHeading<T>(T origin, T destination) where T : IJSObjectReference, IPoint, IPosition
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination);
        }

        public async ValueTask<double> GetLengthOfPath<T>(T path, DistanceUnits? units = null) where T : IJSObjectReference, IEnumerable<Position>, ILineString
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), path, units);
        }

        public async ValueTask<List<Position>> GetPathDenormalizedAtAntimerian<T>(T path) where T : IJSObjectReference, IEnumerable<Position>, ILineString
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), path);
        }

        public async ValueTask<List<List<Position>>> GetPathSplitByAntimeridian<T>(T path) where T : IJSObjectReference, IEnumerable<Position>, ILineString
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<List<Position>>>(GetJsInteropMethod(), path);
        }

        public async ValueTask<double> GetPixelHeading<T>(T origin, T destination) where T : IGeoJsonObject, IPosition, IPoint
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination);
        }

        public async ValueTask<Feature<Point, HeadingProperties>> GetPointWithHeadingAlongPath<T>(T path, double distance, DistanceUnits? units) where T : IJSObjectReference, IEnumerable<Position>, ILineString
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Feature<Point, HeadingProperties>>(GetJsInteropMethod(), path, distance, units);
        }

        public async ValueTask<List<Feature<Point, HeadingProperties>>> GetPointsWithHeadingAlongPath<T>(T path, double distance) where T : IJSObjectReference, IEnumerable<Position>, ILineString
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Feature<Point, HeadingProperties>>>(GetJsInteropMethod(), path, distance);
        }

        public async ValueTask<Position> GetPosition<T, P>(T data) where T : IJSObjectReference, IPosition, IPoint, IFeature<Point, P?> where P : class
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), data);
        }

        public async ValueTask<Position> GetPositionAlongPath<T>(T path, double distance, DistanceUnits? units = null) where T : IJSObjectReference, IEnumerable<Position>, ILineString
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), path, distance, units);
        }

        public async ValueTask<List<Position>> GetPositions<T, P>(T data)
        where T : IJSObjectReference, IEnumerable<Position>, IGeometry, IFeature<Geometry, P?>, IFeatureCollection, IGeometryCollection, IEnumerable<Geometry>
        where P : class
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), data);
        }

        public async ValueTask<List<Position>> GetPositionsAlongPath<T>(T path, long numPositions) where T : IJSObjectReference, IEnumerable<Position>, ILineString
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), path, numPositions);
        }

        public async ValueTask<List<Position>> GetRegularPolygonPath<T>(T origin, double radius, int numberOfPositions, DistanceUnits? units = null, double? offset = null) where T : IJSObjectReference, IPosition, IPoint
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), origin, radius, numberOfPositions, units, offset);
        }

        public async ValueTask<List<List<Position>>> GetRegularPolygonPaths<T>(T origin, double radius, int numberOfPositions, DistanceUnits? units = null, double? offset = null) where T : IJSObjectReference, IPosition, IPoint
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<List<Position>>>(GetJsInteropMethod(), origin, radius, numberOfPositions, units, offset);
        }

        public async ValueTask<double> GetSpeed<T, P>(T origin, T destination, double timespan, TimeUnits? timeUnits = null, SpeedUnits? speedUnits = null, int? decimals = null)
            where T : IJSObjectReference, IPosition, IPoint, IFeature<Point, P?>
            where P : class
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination, timespan, timeUnits, speedUnits, decimals);
        }

        public async ValueTask<double> GetSpeedFromFeatures<T, P>(T origin, T destination, string timestampProperty, SpeedUnits? speedUnits = null, int? decimals = null) where T : IJSObjectReference, IFeature<Point, P?>
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination, timestampProperty, speedUnits, decimals);
        }

        public async ValueTask<double> GetTravelDistance(double timespan, double speed, DistanceUnits? distanceUnits = null, TimeUnits? timeUnits = null, SpeedUnits? speedUnits = null, AccelerationUnits? accelerationUnits = null, double? acceleration = null, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), distanceUnits, timespan, speed, acceleration, timeUnits, speedUnits, accelerationUnits, decimals);
        }

        public async ValueTask<Position> Interpolate<T>(T origin, T destination, double? fraction = null) where T : IJSObjectReference, IPosition
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), origin, destination, fraction);
        }

        public async ValueTask<List<Position>> MercatorPixelsToPositions<T>(T pixels, double zoom) where T : IJSObjectReference, IEnumerable<Pixel>
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), pixels, zoom);
        }

        public async ValueTask<List<Pixel>> MercatorPositionsToPixels<T>(T positions, double zoom) where T : IJSObjectReference, IEnumerable<Position>
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Pixel>>(GetJsInteropMethod(), positions, zoom);
        }

        public async ValueTask<double> NormalizeLatitude(double lat)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), lat);
        }

        public async ValueTask<double> NormalizeLongitude(double lng)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), lng);
        }

        public async ValueTask<List<Position>> RotatePositions<T, TOrigin>(T positions, TOrigin origin, double angle)
            where T : IJSObjectReference, IEnumerable<Position>, IEnumerable<Point>
            where TOrigin : IJSObjectReference, IPosition, IPoint
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), positions, origin, angle);
        }

        public async ValueTask<List<Position>> SimplifyPositions<T>(T points, double tolerance) where T : IJSObjectReference, IEnumerable<Position>
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod("Simplify"), points, tolerance);
        }

        public async ValueTask<List<Pixel>> SimplifyPixels<T>(T points, double tolerance) where T : IJSObjectReference, IEnumerable<Pixel>
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Pixel>>(GetJsInteropMethod("Simplify"), points, tolerance);
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.Math.GetJsModuleMethod(name);
    }
}

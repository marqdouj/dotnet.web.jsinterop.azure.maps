using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models.Atlas;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;
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
        /// Converts an acceleration from one acceleration units to another. 
        /// Supported units: <see cref="AccelerationUnits"/>
        /// </summary>
        /// <param name="acceleration">The acceleration value to convert.</param>
        /// <param name="fromUnits">The units to convert from.</param>
        /// <param name="toUnits">The units to convert to.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>An acceleration value convertered from one unit to another.</returns>
        ValueTask<double> ConvertAcceleration(double acceleration, string fromUnits, string toUnits, int? decimals = null);

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
        /// Converts an area from one area units to another. Supported units: <see cref="AreaUnits"/>
        /// </summary>
        /// <param name="area">The area value to convert.</param>
        /// <param name="fromUnits">The units to convert from.</param>
        /// <param name="toUnits">The units to convert to.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>An area value converted from one unit to another.</returns>
        ValueTask<double> ConvertArea(double area, string fromUnits, string toUnits, int? decimals = null);

        /// <summary>
        /// Converts an area from one area units to another. Supported units: <see cref="AreaUnits"/>
        /// </summary>
        /// <param name="area">The area value to convert.</param>
        /// <param name="fromUnits">The units to convert from.</param>
        /// <param name="toUnits">The units to convert to.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>An area value converted from one unit to another.</returns>
        ValueTask<double> ConvertArea(double area, AreaUnits fromUnits, AreaUnits toUnits, int? decimals = null);

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
        /// Converts a speed from one speed units to another. Supported units: <see cref="SpeedUnits"/>
        /// </summary>
        /// <param name="speed">The speed value to convert.</param>
        /// <param name="fromUnits">The speed units to convert from.</param>
        /// <param name="toUnits">The speed units to convert to.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>A speed value convertered from one unit to another.</returns>
        ValueTask<double> ConvertSpeed(double speed, string fromUnits, string toUnits, int? decimals = null);

        /// <summary>
        /// Converts a speed from one speed units to another. Supported units: <see cref="SpeedUnits"/>
        /// </summary>
        /// <param name="speed">The speed value to convert.</param>
        /// <param name="fromUnits">The speed units to convert from.</param>
        /// <param name="toUnits">The speed units to convert to.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>A speed value convertered from one unit to another.</returns>
        ValueTask<double> ConvertSpeed(double speed, SpeedUnits fromUnits, SpeedUnits toUnits, int? decimals = null);

        /// <summary>
        /// Converts a timespan from one time units to another. Supported units: <see cref="TimeUnits"/>
        /// </summary>
        /// <param name="timespan">The timespan value to convert.</param>
        /// <param name="fromUnits">The time units to convert from.</param>
        /// <param name="toUnits">The time units to convert to.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>A timespan value converted from one unit to another.</returns>
        ValueTask<double> ConvertTimeSpan(double timespan, string fromUnits, string toUnits, int? decimals = null);

        /// <summary>
        /// Converts a timespan from one time units to another. Supported units: <see cref="TimeUnits"/>
        /// </summary>
        /// <param name="timespan">The timespan value to convert.</param>
        /// <param name="fromUnits">The time units to convert from.</param>
        /// <param name="toUnits">The time units to convert to.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>A timespan value converted from one unit to another.</returns>
        ValueTask<double> ConvertTimeSpan(double timespan, TimeUnits fromUnits, TimeUnits toUnits, int? decimals = null);

        /// <summary>
        /// Calculates the acceleration based on an initial speed, distance, and timespan. The result can be returned in different acceleration units.
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
        ValueTask<double> GetAcceleration(double initialSpeed, double distance, double timespan, string? speedUnits = null, string? distanceUnits = null, string? timeUnits = null, string? accelerationUnits = null, int? decimals = null);

        /// <summary>
        /// Calculates the acceleration based on an initial speed, distance, and timespan. The result can be returned in different acceleration units.
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
        /// <param name="origin">The initial point in which the acceleration is calculated from. Must be Feature{Point, P?}.</param>
        /// <param name="destination">The destination point for which the acceleration is calculated. Must be Feature{Point, P?}</param>
        /// <param name="timestampProperty">The property name for the timestamp.</param>
        /// <param name="speedProperty">The property name for the speed.</param>
        /// <param name="speedUnits">The units for the speed. If not specified m/s are used.</param>
        /// <param name="accelerationUnits">The units for the acceleration. If not specified m/s^2 are used.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>An acceleration between two point features that have a timestamp property and optionally a speed property. 
        /// Returns NaN if unable to parse timestamp.</returns>
        ValueTask<double> GetAccelerationFromFeatures(IJSObjectReference origin, IJSObjectReference destination, string timestampProperty, string? speedProperty = null, string? speedUnits = null, string? accelerationUnits = null, int? decimals = null);

        /// <summary>
        /// Calculates an acceleration between two point features that have a timestamp property and optionally a speed property.
        /// If speeds are provided, ignore distance between points as the path may not have been straight and calculate: a = (v2 - v1)/(t2 - t1).
        /// If speeds are not provided or only provided on first point, calculate straight line distance between points and calculate: a = 2*(d - v*t)/t^2.
        /// </summary>
        /// <param name="origin">The initial point in which the acceleration is calculated from. Must be Feature{Point, P?}.</param>
        /// <param name="destination">The destination point for which the acceleration is calculated. Must be Feature{Point, P?}</param>
        /// <param name="timestampProperty">The property name for the timestamp.</param>
        /// <param name="speedProperty">The property name for the speed.</param>
        /// <param name="speedUnits">The units for the speed. If not specified m/s are used.</param>
        /// <param name="accelerationUnits">The units for the acceleration. If not specified m/s^2 are used.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>An acceleration between two point features that have a timestamp property and optionally a speed property. 
        /// Returns NaN if unable to parse timestamp.</returns>
        ValueTask<double> GetAccelerationFromFeatures(IJSObjectReference origin, IJSObjectReference destination, string timestampProperty, string? speedProperty = null, SpeedUnits? speedUnits = null, AccelerationUnits? accelerationUnits = null, int? decimals = null);

        /// <summary>
        /// Calculates an acceleration between two point features that have a timestamp property and optionally a speed property.
        /// If speeds are provided, ignore distance between points as the path may not have been straight and calculate: a = (v2 - v1)/(t2 - t1).
        /// If speeds are not provided or only provided on first point, calculate straight line distance between points and calculate: a = 2*(d - v*t)/t^2.
        /// </summary>
        /// <param name="origin">The initial point in which the acceleration is calculated from.</param>
        /// <param name="destination">The destination point for which the acceleration is calculated.</param>
        /// <param name="timestampProperty">The property name for the timestamp.</param>
        /// <param name="speedProperty">The property name for the speed.</param>
        /// <param name="speedUnits">The units for the speed. If not specified m/s are used.</param>
        /// <param name="accelerationUnits">The units for the acceleration. If not specified m/s^2 are used.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>An acceleration between two point features that have a timestamp property and optionally a speed property. 
        /// Returns NaN if unable to parse timestamp.</returns>
        ValueTask<double> GetAccelerationFromFeatures<P>(Feature<Point, P?> origin, Feature<Point, P?> destination, string timestampProperty, string? speedProperty = null, string? speedUnits = null, string? accelerationUnits = null, int? decimals = null) where P : class;

        /// <summary>
        /// Calculates an acceleration between two point features that have a timestamp property and optionally a speed property.
        /// If speeds are provided, ignore distance between points as the path may not have been straight and calculate: a = (v2 - v1)/(t2 - t1).
        /// If speeds are not provided or only provided on first point, calculate straight line distance between points and calculate: a = 2*(d - v*t)/t^2.
        /// </summary>
        /// <param name="origin">The initial point in which the acceleration is calculated from.</param>
        /// <param name="destination">The destination point for which the acceleration is calculated.</param>
        /// <param name="timestampProperty">The property name for the timestamp.</param>
        /// <param name="speedProperty">The property name for the speed.</param>
        /// <param name="speedUnits">The units for the speed. If not specified m/s are used.</param>
        /// <param name="accelerationUnits">The units for the acceleration. If not specified m/s^2 are used.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>An acceleration between two point features that have a timestamp property and optionally a speed property. 
        /// Returns NaN if unable to parse timestamp.</returns>
        ValueTask<double> GetAccelerationFromFeatures<P>(Feature<Point, P?> origin, Feature<Point, P?> destination, string timestampProperty, string? speedProperty = null, SpeedUnits? speedUnits = null, AccelerationUnits? accelerationUnits = null, int? decimals = null) where P : class;

        /// <summary>
        /// Calculates the acceleration based on an initial speed, final speed, and timespan. The result can be returned in different acceleration units.
        /// </summary>
        /// <param name="initialSpeed">The initial speed.</param>
        /// <param name="finalSpeed">The final speed.</param>
        /// <param name="timespan">The timespan.</param>
        /// <param name="speedUnits">The units for the speed. If not specified meters are used.</param>
        /// <param name="timeUnits">The units for the timespan. If not specified seconds are used.</param>
        /// <param name="accelerationUnits">The units for the acceleration. If not specified m/s^2 are used.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>The calculated acceleration.</returns>
        ValueTask<double> GetAccelerationFromSpeeds(double initialSpeed, double finalSpeed, double timespan, string? speedUnits = null, string? timeUnits = null, string? accelerationUnits = null, int? decimals = null);

        /// <summary>
        /// Calculates the acceleration based on an initial speed, final speed, and timespan. The result can be returned in different acceleration units.
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
        /// <param name="data">The Geometry, Feature{Geometry, P} or Shape for which to calculate the area.</param>
        /// <param name="areaUnits">The units for the area. If not specified square meters are used.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>The calculated area.</returns>
        ValueTask<double> GetArea(IJSObjectReference data, string? areaUnits = null, int? decimals = null);

        /// <summary>
        /// Calculates the approximate area of a geometry in the specified units.
        /// </summary>
        /// <param name="data">The Geometry for which to calculate the area.</param>
        /// <param name="areaUnits">The units for the area. If not specified square meters are used.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>The calculated area.</returns>
        ValueTask<double> GetArea(Geometry data, string? areaUnits = null, int? decimals = null);

        /// <summary>
        /// Calculates the approximate area of a geometry in the specified units.
        /// </summary>
        /// <param name="data">The Feature{Geometry, P} for which to calculate the area.</param>
        /// <param name="areaUnits">The units for the area. If not specified square meters are used.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>The calculated area.</returns>
        ValueTask<double> GetArea<P>(Feature<Geometry, P?> data, string? areaUnits = null, int? decimals = null) where P : class;

        /// <summary>
        /// Calculates the approximate area of a geometry in the specified units.
        /// </summary>
        /// <param name="data">The Geometry, Feature{Geometry, P} or Shape for which to calculate the area.</param>
        /// <param name="areaUnits">The units for the area. If not specified square meters are used.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>The calculated area.</returns>
        ValueTask<double> GetArea(IJSObjectReference data, AreaUnits? areaUnits = null, int? decimals = null);

        /// <summary>
        /// Calculates the approximate area of a geometry in the specified units.
        /// </summary>
        /// <param name="data">The Geometry for which to calculate the area.</param>
        /// <param name="areaUnits">The units for the area. If not specified square meters are used.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>The calculated area.</returns>
        ValueTask<double> GetArea(Geometry data, AreaUnits? areaUnits = null, int? decimals = null);

        /// <summary>
        /// Calculates the approximate area of a geometry in the specified units.
        /// </summary>
        /// <param name="data">The Feature{Geometry, P} for which to calculate the area.</param>
        /// <param name="areaUnits">The units for the area. If not specified square meters are used.</param>
        /// <param name="decimals">The number of decimal places to round the result to. If undefined, no rounding will occur.</param>
        /// <returns>The calculated area.</returns>
        ValueTask<double> GetArea<P>(Feature<Geometry, P?> data, AreaUnits? areaUnits = null, int? decimals = null) where P : class;

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
        /// Calculates the pixel accurate heading from one position to another based on the Mercator map projection. This heading is visually accurate.
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        ValueTask<double> GetPixelHeading(Position origin, Position destination);

        /// <summary>
        /// Calculates the pixel accurate heading from one position to another based on the Mercator map projection. This heading is visually accurate.
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        ValueTask<double> GetPixelHeading(Point origin, Point destination);

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

        /// <summary>
        /// Calculates the average speed of travel between two points based on the provided amount of time.
        /// </summary>
        /// <param name="origin">The initial point in which the speed is calculated from. 
        /// Must be a Position, Point, or Feature{Point, P?} or an IJSObjectReference to one.</param>
        /// <param name="destination">The final point in which the speed is calculated to. 
        /// Must be a Position, Point, or Feature{Point, P?} or an IJSObjectReference to one.</param>
        /// <param name="timespan">The time span over which the speed is calculated.</param>
        /// <param name="timeUnits">The units for the time span. Default: seconds</param>
        /// <param name="speedUnits">The units for the speed. Default: meters/second</param>
        /// <param name="decimals">The number of decimal places to round the result to.</param>
        /// <returns>The average speed of travel between the two points.</returns>
        ValueTask<double> GetSpeed<T>(T origin, T destination, double timespan, string? timeUnits = null, string? speedUnits = null, int? decimals = null) where T : class, IJSObjectReference;

        /// <summary>
        /// Calculates the average speed of travel between two points based on the provided amount of time.
        /// </summary>
        /// <param name="origin">The initial point in which the speed is calculated from. 
        /// Must be a Position, Point, or Feature{Point, P?} or an IJSObjectReference to one.</param>
        /// <param name="destination">The final point in which the speed is calculated to. 
        /// Must be a Position, Point, or Feature{Point, P?} or an IJSObjectReference to one.</param>
        /// <param name="timespan">The time span over which the speed is calculated.</param>
        /// <param name="timeUnits">The units for the time span. Default: seconds</param>
        /// <param name="speedUnits">The units for the speed. Default: meters/second</param>
        /// <param name="decimals">The number of decimal places to round the result to.</param>
        /// <returns>The average speed of travel between the two points.</returns>
        ValueTask<double> GetSpeed<T>(T origin, T destination, double timespan, TimeUnits? timeUnits = null, SpeedUnits? speedUnits = null, int? decimals = null) where T : class, IJSObjectReference;

        /// <summary>
        /// Calculates the average speed of travel between two features based on the timestamp property of each feature.
        /// </summary>
        /// <typeparam name="T"> Feature{Point, P?} or IJSObjectReference to one.</typeparam>
        /// <typeparam name="P">Feature{Point, P?}</typeparam>
        /// <param name="origin">The initial point in which the speed is calculated from.</param>
        /// <param name="destination">The final point in which the speed is calculated to.</param>
        /// <param name="timestampProperty">The property name for the timestamp values.</param>
        /// <param name="speedUnits">The units for the speed. Default: meters/second</param>
        /// <param name="decimals">The number of decimal places to round the result to.</param>
        /// <returns>The speed in the specified units or NaN if valid timestamps are not found.</returns>
        ValueTask<double> GetSpeedFromFeatures<T, P>(T origin, T destination, string timestampProperty, string? speedUnits = null, int? decimals = null) where T : Feature<Point, P?>, IJSObjectReference;

        /// <summary>
        /// Calculates the average speed of travel between two features based on the timestamp property of each feature.
        /// </summary>
        /// <typeparam name="T"> Feature{Point, P?} or IJSObjectReference to one.</typeparam>
        /// <typeparam name="P">Feature{Point, P?}</typeparam>
        /// <param name="origin">The initial point in which the speed is calculated from.</param>
        /// <param name="destination">The final point in which the speed is calculated to.</param>
        /// <param name="timestampProperty">The property name for the timestamp values.</param>
        /// <param name="speedUnits">The units for the speed. Default: meters/second</param>
        /// <param name="decimals">The number of decimal places to round the result to.</param>
        /// <returns>The speed in the specified units or NaN if valid timestamps are not found.</returns>
        ValueTask<double> GetSpeedFromFeatures<T, P>(T origin, T destination, string timestampProperty, SpeedUnits? speedUnits = null, int? decimals = null) where T : Feature<Point, P?>, IJSObjectReference;

        /// <summary>
        /// Calculates a position along a path defined by an origin and destination 
        /// at a specified fraction of the distance between the two positions.
        /// </summary>
        /// <param name="origin">The origin position.</param>
        /// <param name="destination">The destination position.</param>
        /// <param name="fraction">The fraction of the distance between the two positions. Default 0.5.</param>
        /// <returns>The interpolated position.</returns>
        ValueTask<Position> Interpolate(Position origin, Position destination, double? fraction = null);

        /// <summary>
        /// Converts an array of global Mercator pixel coordinates into an array of geospatial positions at a specified zoom level.
        /// Global pixel coordinates are relative to the top left corner of the map [-180, 90].
        /// </summary>
        /// <param name="pixels">The list of pixels to convert.</param>
        /// <param name="zoom">The zoom level.</param>
        /// <returns>The list of converted positions.</returns>
        ValueTask<List<Position>> MercatorPixelsToPositions(List<Pixel> pixels, double zoom);

        /// <summary>
        /// Converts an array of positions into an array of global Mercator pixel coordinates at a specified zoom level.
        /// </summary>
        /// <param name="positions">The list of positions to convert.</param>
        /// <param name="zoom">The zoom level.</param>
        /// <returns>The list of converted global Mercator pixels.</returns>
        ValueTask<List<Pixel>> MercatorPositionsToPixels(List<Position> positions, double zoom);

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
        /// <param name="positions">The list of positions to rotate.</param>
        /// <param name="origin">The origin around which to rotate.</param>
        /// <param name="angle">The amount to rotate in degrees clockwise.</param>
        /// <returns>The list of rotated positions.</returns>
        ValueTask<List<Position>> RotatePositions(List<Position> positions, Position origin, double angle);

        /// <summary>
        /// Rotates a list of positions around a specified origin by a given angle in degrees.
        /// </summary>
        /// <param name="positions">The list of positions to rotate.</param>
        /// <param name="origin">The origin around which to rotate.</param>
        /// <param name="angle">The amount to rotate in degrees clockwise.</param>
        /// <returns>The list of rotated positions.</returns>
        ValueTask<List<Position>> RotatePositions(List<Position> positions, Point origin, double angle);
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

        #region GetRegularPolygonPath
        
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

        public async ValueTask<Position> Interpolate(Position origin, Position destination, double? fraction = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Position>(GetJsInteropMethod(), origin, destination, fraction);
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

        #region RotatePositions

        public async ValueTask<List<Position>> RotatePositions(List<Position> positions, Position origin, double angle)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), positions, origin, angle);
        }

        public async ValueTask<List<Position>> RotatePositions(List<Position> positions, Point origin, double angle)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), positions, origin, angle);
        }

        #endregion

        #region GetPixelHeading

        public async ValueTask<double> GetPixelHeading(Position origin, Position destination)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination);
        }

        public async ValueTask<double> GetPixelHeading(Point origin, Point destination)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination);
        }

        #endregion

        public async ValueTask<List<Position>> MercatorPixelsToPositions(List<Pixel> pixels, double zoom)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Position>>(GetJsInteropMethod(), pixels, zoom);
        }

        public async ValueTask<List<Pixel>> MercatorPositionsToPixels(List<Position> positions, double zoom)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<List<Pixel>>(GetJsInteropMethod(), positions, zoom);
        }

        #region ConvertAcceleration

        public async ValueTask<double> ConvertAcceleration(double acceleration, string fromUnits, string toUnits, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), acceleration, fromUnits, toUnits, decimals);
        }

        public async ValueTask<double> ConvertAcceleration(double acceleration, AccelerationUnits fromUnits, AccelerationUnits toUnits, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), acceleration, fromUnits, toUnits, decimals);
        }

        #endregion

        #region ConvertArea

        public async ValueTask<double> ConvertArea(double area, string fromUnits, string toUnits, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), area, fromUnits, toUnits, decimals);
        }

        public async ValueTask<double> ConvertArea(double area, AreaUnits fromUnits, AreaUnits toUnits, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), area, fromUnits, toUnits, decimals);
        }

        #endregion

        #region ConvertSpeed

        public async ValueTask<double> ConvertSpeed(double speed, string fromUnits, string toUnits, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), speed, fromUnits, toUnits, decimals);
        }

        public async ValueTask<double> ConvertSpeed(double speed, SpeedUnits fromUnits, SpeedUnits toUnits, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), speed, fromUnits, toUnits, decimals);
        }

        #endregion

        #region ConvertTimeSpan

        public async ValueTask<double> ConvertTimeSpan(double timespan, string fromUnits, string toUnits, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), timespan, fromUnits, toUnits, decimals);
        }

        public async ValueTask<double> ConvertTimeSpan(double timespan, TimeUnits fromUnits, TimeUnits toUnits, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), timespan, fromUnits, toUnits, decimals);
        }

        #endregion

        #region GetAcceleration

        public async ValueTask<double> GetAcceleration(double initialSpeed, double distance, double timespan, string? speedUnits = null, string? distanceUnits = null, string? timeUnits = null, string? accelerationUnits = null, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), initialSpeed, distance, timespan, speedUnits, distanceUnits, timeUnits, accelerationUnits, decimals);
        }

        public async ValueTask<double> GetAcceleration(double initialSpeed, double distance, double timespan, SpeedUnits? speedUnits = null, DistanceUnits? distanceUnits = null, TimeUnits? timeUnits = null, AccelerationUnits? accelerationUnits = null, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), initialSpeed, distance, timespan, speedUnits, distanceUnits, timeUnits, accelerationUnits, decimals);
        }

        #endregion

        #region GetAccelerationFromSpeeds

        public async ValueTask<double> GetAccelerationFromSpeeds(double initialSpeed, double finalSpeed, double timespan, string? speedUnits = null, string? timeUnits = null, string? accelerationUnits = null, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), initialSpeed, finalSpeed, timespan, speedUnits, timeUnits, accelerationUnits, decimals);
        }

        public async ValueTask<double> GetAccelerationFromSpeeds(double initialSpeed, double finalSpeed, double timespan, SpeedUnits? speedUnits = null, TimeUnits? timeUnits = null, AccelerationUnits? accelerationUnits = null, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), initialSpeed, finalSpeed, timespan, speedUnits, timeUnits, accelerationUnits, decimals);
        }

        #endregion

        #region GetAccelerationFromFeatures

        public async ValueTask<double> GetAccelerationFromFeatures(IJSObjectReference origin, IJSObjectReference destination, string timestampProperty, string? speedProperty = null, string? speedUnits = null, string? accelerationUnits = null, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination, timestampProperty, speedProperty, speedUnits, accelerationUnits, decimals);
        }

        public async ValueTask<double> GetAccelerationFromFeatures(IJSObjectReference origin, IJSObjectReference destination, string timestampProperty, string? speedProperty = null, SpeedUnits? speedUnits = null, AccelerationUnits? accelerationUnits = null, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination, timestampProperty, speedProperty, speedUnits, accelerationUnits, decimals);
        }

        public async ValueTask<double> GetAccelerationFromFeatures<P>(Feature<Point, P?> origin, Feature<Point, P?> destination, string timestampProperty, string? speedProperty = null, string? speedUnits = null, string? accelerationUnits = null, int? decimals = null) where P : class
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination, timestampProperty, speedProperty, speedUnits, accelerationUnits, decimals);
        }

        public async ValueTask<double> GetAccelerationFromFeatures<P>(Feature<Point, P?> origin, Feature<Point, P?> destination, string timestampProperty, string? speedProperty = null, SpeedUnits? speedUnits = null, AccelerationUnits? accelerationUnits = null, int? decimals = null) where P : class
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination, timestampProperty, speedProperty, speedUnits, accelerationUnits, decimals);
        }

        #endregion

        #region GetArea

        //getArea (data: atlas.data.Geometry | atlas.data.Feature<atlas.data.Geometry, any> | atlas.Shape, areaUnits?: AreaUnits, decimals?: number): number
        public async ValueTask<double> GetArea(IJSObjectReference data, string? areaUnits = null, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), data, areaUnits, decimals);
        }

        public async ValueTask<double> GetArea(Geometry data, string? areaUnits = null, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), data, areaUnits, decimals);
        }

        public async ValueTask<double> GetArea<P>(Feature<Geometry, P?> data, string? areaUnits = null, int? decimals = null) where P : class
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), data, areaUnits, decimals);
        }

        public async ValueTask<double> GetArea(IJSObjectReference data, AreaUnits? areaUnits = null, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), data, areaUnits, decimals);
        }

        public async ValueTask<double> GetArea(Geometry data, AreaUnits? areaUnits = null, int? decimals = null)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), data, areaUnits, decimals);
        }

        public async ValueTask<double> GetArea<P>(Feature<Geometry, P?> data, AreaUnits? areaUnits = null, int? decimals = null) where P : class
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), data, areaUnits, decimals);
        }

        #endregion

        #region GetSpeed

        public async ValueTask<double> GetSpeed<T>(T origin, T destination, double timespan, string? timeUnits = null, string? speedUnits = null, int? decimals = null) where T : class, IJSObjectReference
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination, timespan, timeUnits, speedUnits, decimals);
        }

        public async ValueTask<double> GetSpeed<T>(T origin, T destination, double timespan, TimeUnits? timeUnits = null, SpeedUnits? speedUnits = null, int? decimals = null) where T : class, IJSObjectReference
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination, timespan, timeUnits, speedUnits, decimals);
        }

        #endregion

        #region GetSpeedFromFeatures

        public async ValueTask<double> GetSpeedFromFeatures<T, P>(T origin, T destination, string timestampProperty, string? speedUnits = null, int? decimals = null) where T : Feature<Point, P?>, IJSObjectReference
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination, timestampProperty, speedUnits, decimals);
        }

        public async ValueTask<double> GetSpeedFromFeatures<T, P>(T origin, T destination, string timestampProperty, SpeedUnits? speedUnits = null, int? decimals = null) where T : Feature<Point, P?>, IJSObjectReference
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<double>(GetJsInteropMethod(), origin, destination, timestampProperty, speedUnits, decimals);
        }

        #endregion

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.Math.GetJsModuleMethod(name);
    }
}

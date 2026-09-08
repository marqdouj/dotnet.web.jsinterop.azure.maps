import * as atlas from "azure-maps-control"
import { Logger, LogLevel } from "./common/";

export class Math {
    public static boundingBoxToPolygon(bboxes: atlas.data.BoundingBox[]): atlas.data.Polygon[] {
        //Logger.logMessage("Math.boundingBoxToPolygon", LogLevel.Trace, "", bboxes);
        return bboxes.map((d) => atlas.math.boundingBoxToPolygon(d));
    }

    public static convertAcceleration(accelerations: number[], fromUnits: string, toUnits: string, decimals?: number): number[] {
        //Logger.logMessage("Math.convertAcceleration", LogLevel.Trace, "", accelerations, fromUnits, toUnits, decimals);
        return accelerations.map((a) => atlas.math.convertAcceleration(a, fromUnits, toUnits, decimals));
    }

    public static convertArea(areas: number[], fromUnits: string, toUnits: string, decimals?: number): number[] {
        //Logger.logMessage("Math.convertArea", LogLevel.Trace, "", areas, fromUnits, toUnits, decimals);
        return areas.map((a) => atlas.math.convertArea(a, fromUnits, toUnits, decimals));
    }

    public static convertDistance(distances: number[], fromUnits: string, toUnits: string, decimals?: number): number[] {
        //Logger.logMessage("Math.convertDistance", LogLevel.Trace, "", distances, fromUnits, toUnits, decimals);
        return distances.map((d) => atlas.math.convertDistance(d, fromUnits, toUnits, decimals));
    }

    public static convertSpeed(speeds: number[], fromUnits: string, toUnits: string, decimals?: number): number[] {
        //Logger.logMessage("Math.convertSpeed", LogLevel.Trace, "", speeds, fromUnits, toUnits, decimals);
        return speeds.map((speed) => atlas.math.convertSpeed(speed, fromUnits, toUnits, decimals));
    }

    public static convertTimespan(timespans: number[], fromUnits: string, toUnits: string, decimals?: number): number[] {
        //Logger.logMessage("Math.convertTimespan", LogLevel.Trace, "", timespans, fromUnits, toUnits, decimals);
        return timespans.map((t) => atlas.math.convertTimespan(t, fromUnits, toUnits, decimals));
    }

    public static getAcceleration(initialSpeed: number, distance: number, timespan: number, speedUnits?: string, distanceUnits?: string, timeUnits?: string, accelerationUnits?: string, decimals?: number): number {
        //Logger.logMessage("Math.getAcceleration", LogLevel.Trace, "", initialSpeed, distance, timespan, speedUnits, distanceUnits, timeUnits, accelerationUnits, decimals);
        return atlas.math.getAcceleration(initialSpeed, distance, timespan, speedUnits, distanceUnits, timeUnits, accelerationUnits, decimals);
    }

    public static getAccelerationFromFeatures(origin: atlas.data.Feature<atlas.data.Point, any>, destination: atlas.data.Feature<atlas.data.Point, any>, timestampProperty: string, speedProperty?: string, speedUnits?: string, accelerationUnits?: string, decimals?: number): number {
        return atlas.math.getAccelerationFromFeatures(origin, destination, timestampProperty, speedProperty, speedUnits, accelerationUnits, decimals);
    }

    public static getAccelerationFromSpeeds(initialSpeed: number, finalSpeed: number, timespan: number, speedUnits?: string, timeUnits?: string, accelerationUnits?: string, decimals?: number): number {
        return atlas.math.getAccelerationFromSpeeds(initialSpeed, finalSpeed, timespan, speedUnits, timeUnits, accelerationUnits, decimals);
    }

    public static getAffineTransformToSource(source: number[][], target: number[][], targetPoints: number[][], decimals?: number): number[][] {
        const at = new atlas.math.AffineTransform(source, target);
        return at.toSource(targetPoints, decimals);
    }

    public static getAffineTransformToTarget(source: number[][], target: number[][], sourcePoints: number[][], decimals?: number): number[][] {
        const at = new atlas.math.AffineTransform(source, target);
        return at.toTarget(sourcePoints, decimals);
    }

    public static getArea(data: any[], areaUnits?: atlas.math.AreaUnits, decimals?: number): number[] {
        Logger.logMessage("Math.getArea", LogLevel.Trace, "", data, areaUnits, decimals);
        const results = data.map((d) => atlas.math.getArea(d, areaUnits, decimals));
        Logger.logMessage("Math.getArea", LogLevel.Trace, "results", results);
        return results;
    }

    public static getCardinalSpline(positions: atlas.data.Position[], tension?: number, nodeSize?: number, close?: boolean): atlas.data.Position[] {
        return atlas.math.getCardinalSpline(positions, tension, nodeSize, close);
    }

    public static getClosestPointOnGeometry(pt: atlas.data.Position | atlas.data.Point | atlas.data.Feature<atlas.data.Point, any> | atlas.Shape, geom: atlas.data.Geometry | atlas.data.Feature<atlas.data.Geometry, any> | atlas.Shape, units?: string | atlas.math.DistanceUnits, decimals?: number): atlas.data.Feature<atlas.data.Point, { distance: number }> {
        return atlas.math.getClosestPointOnGeometry(pt, geom, units, decimals);
    }

    public static getConvexHull(data: atlas.data.Position[] | atlas.data.Geometry | atlas.data.Feature<atlas.data.Geometry, any> | atlas.data.FeatureCollection | atlas.data.GeometryCollection | atlas.data.Geometry[] | Array<atlas.data.Feature<atlas.data.Geometry, any> | atlas.Shape> | atlas.Shape): atlas.data.Polygon {
        return atlas.math.getConvexHull(data);
    }

    public static getDestination(origin: atlas.data.Position | atlas.data.Point, heading: number, distance: number, units?: string): atlas.data.Position {
        return atlas.math.getDestination(origin, heading, distance, units);
    }

    public static getDistanceTo(origin: atlas.data.Position | atlas.data.Point, destination: atlas.data.Position | atlas.data.Point, units?: string): number {
        return atlas.math.getDistanceTo(origin, destination, units);
    }

    public static getEarthRadius(units?: string | atlas.math.DistanceUnits): number {
        return atlas.math.getEarthRadius(units);
    }

    public static getGeodesicPath(path: atlas.data.LineString | atlas.data.Position[], nodeSize?: number): atlas.data.Position[] {
        return atlas.math.getGeodesicPath(path, nodeSize);
    }

    public static getGeodesicPaths(path: atlas.data.LineString | atlas.data.Position[], nodeSize?: number): atlas.data.Position[][] {
        return atlas.math.getGeodesicPaths(path, nodeSize);
    }

    public static getHeading(origin: atlas.data.Position | atlas.data.Point, destination: atlas.data.Position | atlas.data.Point): number {
        return atlas.math.getHeading(origin, destination);
    }

    public static getLengthOfPath(path: atlas.data.LineString | atlas.data.Position[], units?: string): number {
        return atlas.math.getLengthOfPath(path, units);
    }

    public static getPathDenormalizedAtAntimerian(path: atlas.data.LineString | atlas.data.Position[]): atlas.data.Position[] {
        return atlas.math.getPathDenormalizedAtAntimerian(path);
    }

    public static getPathSplitByAntimeridian(path: atlas.data.LineString | atlas.data.Position[]): atlas.data.Position[][] {
        return atlas.math.getPathSplitByAntimeridian(path);
    }

    public static getPixelHeading(origin: atlas.data.Position | atlas.data.Point, destination: atlas.data.Position | atlas.data.Point): number {
        return atlas.math.getPixelHeading(origin, destination);
    }

    public static getPointWithHeadingAlongPath(path: atlas.data.LineString | atlas.data.Position[], distance: number, units?: string | atlas.math.DistanceUnits): atlas.data.Feature<atlas.data.Point, { heading: number }> {
        return atlas.math.getPointWithHeadingAlongPath(path, distance, units);
    }

    public static getPointsWithHeadingAlongPath(path: atlas.data.LineString | atlas.data.Position[], numPoints: number): atlas.data.Feature<atlas.data.Point, { heading: number }>[] {
        return atlas.math.getPointsWithHeadingsAlongPath(path, numPoints);
    }

    public static getPosition(data: atlas.data.Position | atlas.data.Point | atlas.data.Feature<atlas.data.Point, any> | atlas.Shape): atlas.data.Position {
        return atlas.math.getPosition(data);
    }

    public static getPositionAlongPath(path: atlas.data.LineString | atlas.data.Position[], distance: number, units?: string): atlas.data.Position {
        return atlas.math.getPositionAlongPath(path, distance, units);
    }

    public static getPositions(data: atlas.data.Position[] | atlas.data.Geometry | atlas.data.Feature<atlas.data.Geometry, any> | atlas.data.FeatureCollection | atlas.data.GeometryCollection | atlas.data.Geometry[] | Array<atlas.data.Feature<atlas.data.Geometry, any> | atlas.Shape> | atlas.Shape): atlas.data.Position[] {
        return atlas.math.getPositions(data);
    }


    public static getPositionsAlongPath(path: atlas.data.LineString | atlas.data.Position[], numPositions: number): atlas.data.Position[] {
        return atlas.math.getPositionsAlongPath(path, numPositions);
    }

    public static getRegularPolygonPath(origin: atlas.data.Position | atlas.data.Point, radius: number, numberOfPositions: number, units?: string, offset?: number): atlas.data.Position[] {
        return atlas.math.getRegularPolygonPath(origin, radius, numberOfPositions, units, offset);
    }

    public static getRegularPolygonPaths(origin: atlas.data.Position | atlas.data.Point, radius: number, numberOfPositions: number, units?: string, offset?: number): atlas.data.Position[][] {
        return atlas.math.getRegularPolygonPaths(origin, radius, numberOfPositions, units, offset);
    }

    public static getSpeed(origin: atlas.data.Position | atlas.data.Point | atlas.data.Feature<atlas.data.Point, any>, destination: atlas.data.Position | atlas.data.Point | atlas.data.Feature<atlas.data.Point, any>, timespan: number, timeUnits?: string | atlas.math.TimeUnits, speedUnits?: string | atlas.math.SpeedUnits, decimals?: number): number {
        return atlas.math.getSpeed(origin, destination, timespan, timeUnits, speedUnits, decimals);
    }

    public static getSpeedFromFeatures(origin: atlas.data.Feature<atlas.data.Point, any>, destination: atlas.data.Feature<atlas.data.Point, any>, timestampProperty: string, speedUnits?: string | atlas.math.SpeedUnits, decimals?: number): number {
        return atlas.math.getSpeedFromFeatures(origin, destination, timestampProperty, speedUnits, decimals);
    }

    public static getTravelDistance(distanceUnits: string, timespan: number, speed: number, acceleration?: number, timeUnits?: string | atlas.math.TimeUnits, speedUnits?: string | atlas.math.SpeedUnits, accelerationUnits?: string, decimals?: number): number {
        return atlas.math.getTravelDistance(distanceUnits, timespan, speed, acceleration, timeUnits, speedUnits, accelerationUnits, decimals);
    }

    public static interpolate(origin: atlas.data.Position | atlas.data.Point, destination: atlas.data.Position | atlas.data.Point, fraction?: number): atlas.data.Position {
        return atlas.math.interpolate(origin, destination, fraction);
    }

    public static mercatorPixelsToPositions(pixels: atlas.Pixel[], zoom: number): atlas.data.Position[] {
        return atlas.math.mercatorPixelsToPositions(pixels, zoom);
    }

    public static mercatorPositionsToPixels(positions: atlas.data.Position[], zoom: number): atlas.Pixel[] {
        return atlas.math.mercatorPositionsToPixels(positions, zoom);
    }

    public static normalizeLatitude(lat: number): number {
        return atlas.math.normalizeLatitude(lat);
    }

    public static normalizeLongitude(lng: number): number {
        return atlas.math.normalizeLongitude(lng);
    }

    public static rotatePositions(positions: atlas.data.Position[], origin: atlas.data.Position | atlas.data.Point, angle: number): atlas.data.Position[] {
        return atlas.math.rotatePositions(positions, origin, angle);
    }

    public static simplify(points: (atlas.data.Position | atlas.Pixel)[], tolerance: number): (atlas.data.Position | atlas.Pixel)[] {
        return atlas.math.simplify(points, tolerance);
    }
} 
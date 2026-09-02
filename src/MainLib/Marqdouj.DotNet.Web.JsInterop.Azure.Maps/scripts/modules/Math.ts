import * as atlas from "azure-maps-control"

export class Math {
    public static boundingBoxesToPolygons(boundingBoxes: atlas.data.BoundingBox[]): atlas.data.Polygon[] {
        return boundingBoxes.map(atlas.math.boundingBoxToPolygon);
    }

    public static convertDistances(distances: number[], fromUnits: string, toUnits: string, decimals?: number): number[] {
        return distances.map((d) => atlas.math.convertDistance(d, fromUnits, toUnits, decimals));
    }

    public static getCardinalSpline(positions: atlas.data.Position[], tension?: number, nodeSize?: number, close?: boolean): atlas.data.Position[] {
        return atlas.math.getCardinalSpline(positions, tension, nodeSize, close);
    }

    public static getDestination(origin: atlas.data.Position | atlas.data.Point, heading: number, distance: number, units?: string): atlas.data.Position {
        return atlas.math.getDestination(origin, heading, distance, units);
    }

    public static getDistanceTo(origin: atlas.data.Position | atlas.data.Point, destination: atlas.data.Position | atlas.data.Point, units?: string): number {
        return atlas.math.getDistanceTo(origin, destination, units);
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

    public static getPositionAlongPath(path: atlas.data.LineString | atlas.data.Position[], distance: number, units?: string): atlas.data.Position {
        return atlas.math.getPositionAlongPath(path, distance, units);
    }

    public static getRegularPolygonPath(origin: atlas.data.Position | atlas.data.Point, radius: number, numberOfPositions: number, units?: string, offset?: number): atlas.data.Position[] {
        return atlas.math.getRegularPolygonPath(origin, radius, numberOfPositions, units, offset);
    }

    public static getRegularPolygonPaths(origin: atlas.data.Position | atlas.data.Point, radius: number, numberOfPositions: number, units?: string, offset?: number): atlas.data.Position[][] {
        return atlas.math.getRegularPolygonPaths(origin, radius, numberOfPositions, units, offset);
    }

    public static interpolate(origin: atlas.data.Position | atlas.data.Point, destination: atlas.data.Position | atlas.data.Point, fraction?: number): atlas.data.Position {
        return atlas.math.interpolate(origin, destination, fraction);
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

    public static getPixelHeading(origin: atlas.data.Position | atlas.data.Point, destination: atlas.data.Position | atlas.data.Point): number {
        return atlas.math.getPixelHeading(origin, destination);
    }
} 
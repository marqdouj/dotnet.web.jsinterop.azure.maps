import * as atlas from "azure-maps-control"

export class BoundingBox {
    public static containsPosition(bounds: atlas.data.BoundingBox, position: atlas.data.Position) {
        return atlas.data.BoundingBox.containsPosition(bounds, position);
    }

    public static crossesAntimeridian(bounds: atlas.data.BoundingBox) {
        return atlas.data.BoundingBox.crossesAntimeridian(bounds);
    }

    public static fromBoundingBox(data: any) {
        return atlas.data.BoundingBox.fromBoundingBox(data);
    }

    public static fromData(data: any) {
        return atlas.data.BoundingBox.fromData(data);
    }

    public static fromDimensions(center: atlas.data.Position, width: number, height: number) {
        return atlas.data.BoundingBox.fromDimensions(center, width, height);
    }

    public static fromEdges(west: number, south: number, east: number, north: number) {
        return atlas.data.BoundingBox.fromEdges(west, south, east, north);
    }

    public static fromLatLngs(latLngs: Array<object | number[]>) {
        return atlas.data.BoundingBox.fromLatLngs(latLngs);
    }

    public static fromPositions(positions: atlas.data.Position[]) {
        return atlas.data.BoundingBox.fromPositions(positions);
    }

    public static getCenter(bounds: atlas.data.BoundingBox) {
        return atlas.data.BoundingBox.getCenter(bounds);
    }

    public static getHeight(bounds: atlas.data.BoundingBox) {
        return atlas.data.BoundingBox.getHeight(bounds);
    }

    public static getNorthEast(bounds: atlas.data.BoundingBox) {
        return atlas.data.BoundingBox.getNorthEast(bounds);
    }

    public static getNorthWest(bounds: atlas.data.BoundingBox) {
        return atlas.data.BoundingBox.getNorthWest(bounds);
    }

    public static getSouthEast(bounds: atlas.data.BoundingBox) {
        return atlas.data.BoundingBox.getSouthEast(bounds);
    }

    public static getSouthWest(bounds: atlas.data.BoundingBox) {
        return atlas.data.BoundingBox.getSouthWest(bounds);
    }

    public static getNorth(bounds: atlas.data.BoundingBox) {
        return atlas.data.BoundingBox.getNorth(bounds);
    }

    public static getEast(bounds: atlas.data.BoundingBox) {
        return atlas.data.BoundingBox.getEast(bounds);
    }

    public static getSouth(bounds: atlas.data.BoundingBox) {
        return atlas.data.BoundingBox.getSouth(bounds);
    }

    public static getWest(bounds: atlas.data.BoundingBox) {
        return atlas.data.BoundingBox.getWest(bounds);
    }

    public static getWidth(bounds: atlas.data.BoundingBox) {
        return atlas.data.BoundingBox.getWidth(bounds);
    }

    public static intersect(bounds1: atlas.data.BoundingBox, bounds2: atlas.data.BoundingBox) {
        return atlas.data.BoundingBox.intersect(bounds1, bounds2);
    }

    public static merge(bounds1: atlas.data.BoundingBox, bounds2: atlas.data.BoundingBox) {
        return atlas.data.BoundingBox.merge(bounds1, bounds2);
    }

    public static splitOnAntimeridian(bounds: atlas.data.BoundingBox) {
        return atlas.data.BoundingBox.splitOnAntimeridian(bounds);
    }
}

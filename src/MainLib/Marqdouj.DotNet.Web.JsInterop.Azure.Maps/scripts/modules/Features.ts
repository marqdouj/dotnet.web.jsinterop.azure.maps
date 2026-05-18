import atlas from "azure-maps-control";
import { Logger, LogLevel, Properties } from "./common/";
import { Factory, MapReference } from "./Factory";
import { SourceHelper } from "./Sources";

export class Features {
    public static async add(
        mapId: string,
        mapFeatures: MapFeature[],
        sourceId: string,
        replace?: boolean): Promise<void> {

        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        const ds = SourceHelper.getSource(mapRef, sourceId);
        if (!ds)
            return;

        mapFeatures ??= [];

        mapFeatures.forEach(mapFeature => {
            Features.#doAddFeature(mapRef, mapFeature, ds, replace);
        });
    }

    static #doAddFeature(
        mapRef: MapReference,
        mapFeature: MapFeature,
        ds: atlas.source.Source,
        replace?: boolean) {

        if (ds instanceof atlas.source.DataSource === false) {
            Logger.logMessage(mapRef.mapId, LogLevel.Error, `adding feature: source with ID '${ds.getId()}' is not a DataSource`);
            return;
        }

        if (replace && mapFeature.id) {
            const shape = ds.getShapeById(mapFeature.id);
            if (shape) {
                ds.remove(shape);
            }
        }

        let geom: atlas.data.Geometry | undefined;
        const geomType = mapFeature.geometry.type as string;
        const bbox: atlas.data.BoundingBox | undefined = mapFeature.bbox ? new atlas.data.BoundingBox(mapFeature.bbox) : undefined;

        switch (geomType.toLowerCase()) {
            case GeoJSONType.Point:
                geom = new atlas.data.Point(mapFeature.geometry.coordinates);
                break;
            case GeoJSONType.MultiPoint:
                geom = new atlas.data.MultiPoint(mapFeature.geometry.coordinates, bbox);
                break;
            case GeoJSONType.LineString:
                geom = new atlas.data.LineString(mapFeature.geometry.coordinates, bbox);
                break;
            case GeoJSONType.Polygon:
                geom = new atlas.data.Polygon(mapFeature.geometry.coordinates, bbox);
                break;
        }

        if (!geom) {
            Logger.logMessage(mapRef.mapId, LogLevel.Error, `adding feature error: geometry type '${mapFeature.geometry.type}' not supported`);
            return;
        }

        const properties: Properties = { ...mapFeature.properties };

        let feature = new atlas.data.Feature(geom, properties, mapFeature.id);

        if (mapFeature.asShape) {
            let shape = new atlas.Shape(feature);
            ds.add(shape);
        }
        else {
            ds.add(feature);
        }
    }

    public static async remove(
        mapId: string,
        mapFeatures: MapFeature[],
        sourceId: string): Promise<void> {

        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        const ds = SourceHelper.getSource(mapRef, sourceId);
        if (!ds)
            return;

        mapFeatures ??= [];

        mapFeatures.forEach(mapFeature => {
            Features.#doRemoveFeature(mapRef, mapFeature, ds);
        });
    }

    static #doRemoveFeature(
        mapRef: MapReference,
        mapFeature: MapFeature,
        ds: atlas.source.Source) {

        if (ds instanceof atlas.source.DataSource === false) {
            Logger.logMessage(mapRef.mapId, LogLevel.Error, `removing feature: source with ID '${ds.getId()}' is not a DataSource`);
            return;
        }

        if (mapFeature.id) {
            const shape = ds.getShapeById(mapFeature.id);
            if (shape) {
                ds.remove(shape);
                Logger.logMessage(mapRef.mapId, LogLevel.Trace, `removing feature: feature with ID '${mapFeature.id}' was removed.`);
            }
        }
    }

    public static update(
        mapId: string,
        mapFeatures: MapFeature[],
        datasourceId: string) {

        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef) return;

        const ds = SourceHelper.getDataSource(mapRef, datasourceId);
        if (!ds) {
            return;
        }

        mapFeatures.forEach(feature => {
            const shape = ds.getShapeById(feature.id);
            if (shape) {
                shape.setCoordinates(feature.geometry.coordinates);
                shape.setProperties(feature.properties);
            }
        });
    }

    public static getCoordinates(mapId: string, featureId: string, datasourceId: string) {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef) return;

        const ds = SourceHelper.getDataSource(mapRef, datasourceId);
        if (!ds) return;

        const shape = ds.getShapeById(featureId);
        if (shape) {
            return shape.getCoordinates();
        }
    }

    public static setCoordinates(mapId: string, featureId: string, coordinates: any, datasourceId: string) {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef) return;

        const ds = SourceHelper.getDataSource(mapRef, datasourceId);
        if (!ds) return;

        const shape = ds.getShapeById(featureId);
        if (shape) {
            shape.setCoordinates(coordinates);
        }
    }

    public static getProperties(mapId: string, featureId: string, datasourceId: string) {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef) return;

        const ds = SourceHelper.getDataSource(mapRef, datasourceId);
        if (!ds) return;

        const shape = ds.getShapeById(featureId);
        if (shape) {
            return shape.getProperties();
        }
    }

    static setProperties(mapId: string, featureId: string, properties: any, datasourceId: string, replace: boolean = false) {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef) return;

        const ds = SourceHelper.getDataSource(mapRef, datasourceId);
        if (!ds) return;

        const shape = ds.getShapeById(featureId);
        if (shape) {
            if (replace) {
                shape.setProperties(properties);
            }
            else {
                let props = shape.getProperties();
                props = { ...props, ...properties };
                shape.setProperties(props);
            }
        }
    }

    static addProperty(mapId: string, featureId: string, name: string, value: any, datasourceId: string) {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef) return;

        const ds = SourceHelper.getDataSource(mapRef, datasourceId);
        if (!ds) return;

        const shape = ds.getShapeById(featureId);
        if (shape) {
            shape.addProperty(name, value);
        }
    }
}

export enum GeoJSONType {
    Point = 'point',
    MultiPoint = 'multipoint',
    LineString = 'linestring',
    MultiLineString = 'multilinestring',
    Polygon = 'polygon',
    MultiPolygon = 'multipolygon'
}

export interface MapFeature {
    id: string;
    geometry: any;
    bbox?: number[];
    properties?: Properties;
    asShape: boolean;
}

import * as atlas from "azure-maps-control"
import * as spatial from "azure-maps-spatial-io"
import { Factory, MapReference } from "./Factory";
import { Helpers, Logger, LogLevel } from "./common/"
import { DataSource, SourceHelper, Sources } from "./Sources";
import { layer } from "azure-maps-animations";

export class SpatialLayers {
    public static add(mapId: string, layers: SimpleDataLayer[]): spatialLayerInfo[] {
        // const eventName = "SpatialLayers.add";
        // Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: entering`, layers);
        const layerIDs: spatialLayerInfo[] = [];

        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return layerIDs;

        layers.forEach((layer) => {
            const info = this.#addLayer(mapRef, layer);
            layerIDs.push(info);
        });

        return layerIDs;
        //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: leaving`);
    }

    static #addLayer(mapRef: MapReference, layer: SimpleDataLayer): spatialLayerInfo {
        const eventName = "SpatialLayers.addLayer";
        const mapId = mapRef.mapId;
        const map = mapRef.map;
        const layerId = layer.id;
        const result: spatialLayerInfo = { interopId: layer.id, id:"" };

        //Logger.logMapMessage(mapId, LogLevel.Trace, eventName, layer);

        if (Helpers.isEmptyOrNull(layerId)) {
            Logger.logMapMessage(mapId, LogLevel.Error, `${eventName}: layer Id is missing`, layer);
            return result;
        }

        const lyr = mapRef.map.layers.getLayerById(layerId);
        if (lyr) {
            Logger.logMapMessage(mapId, LogLevel.Error, `${eventName}: layer already exists where layer ID=${layerId}`, layer);
            return result;
        }

        let src: atlas.source.Source | atlas.source.DataSource | undefined;
        let dsDef: DataSource = layer.source;
        const dsId = dsDef.id;

        if (dsDef && Helpers.isNotEmptyOrNull(dsId)) {
            src = SourceHelper.getSource(mapRef, dsId, false);

            if (!src) {
                Sources.add(mapId, [dsDef]);
                src = SourceHelper.getDataSource(mapRef, dsId);
                if (!src) {
                    Logger.logMapMessage(mapId, LogLevel.Error, `${eventName}: Unable to create datasource.`, dsDef);
                    return result;
                }
            }
        }

        const xlayer = new spatial.layer.SimpleDataLayer(src as atlas.source.DataSource, layer.options);
        (xlayer as any).typeName = "SimpleDataLayer";
        map.layers.add(xlayer);

        result.id = xlayer.getId();
        return result;
    }

    public static getOptions(mapId: string, layerId: string) : any {
        //const eventName = "SpatialLayers.getOptions";
        //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: entering`, layerId);

        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        var options = this.#getOptions(mapRef, layerId);
        //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: leaving`, options);
        return options;
    }

    static #getOptions(mapRef:MapReference, layerId: string): any {
        //const eventName = "SpatialLayers.#getOptions";
        //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: entering`, layers);

        const layer = this.#getLayer(mapRef, layerId, true);

        if (layer) {
            const options = layer.getOptions();
            //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: layer with id = '${layerId}' - getOptions`, options);
            return options;
        }

        //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: leaving`);
    }

    public static setOptions(mapId: string, layerId: string, options: any): void {
        const eventName = "SpatialLayers.setOptions";
        Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: entering`, layerId, options);

        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        const layer = this.#getLayer(mapRef, layerId, true);

        if (layer) {
            layer.setOptions(options);
        }
        //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: leaving`);
    }

    static #getLayer(mapRef: MapReference, layerId: string, logNotFound: boolean): spatial.layer.SimpleDataLayer | undefined {
        const eventName = "SpatialLayers.#getLayer";
        Logger.logMapMessage(mapRef.mapId, LogLevel.Trace, `${eventName}: entering`, layerId);

        const layer = mapRef.map.layers.getLayerById(layerId);

        if (this.#isSimpleDataLayer(layer)) {
            return layer;
        }

        if (logNotFound) {
            Logger.logMapMessage(mapRef.mapId, LogLevel.Warn, `${eventName}: layer with id = '${layerId}' was not found.`);
        }

        return undefined;
        //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: leaving`);
    }

    static #isSimpleDataLayer(obj: unknown): obj is spatial.layer.SimpleDataLayer {
        return (
            typeof obj === "object" &&
            typeof (obj as spatial.layer.SimpleDataLayer).getLayers != undefined
        );
    }
}

interface spatialLayerInfo {
    interopId: string;
    id: string;
}

interface SimpleDataLayer {
    id: string;
    source: DataSource;
    options?: any;
}
import * as atlas from "azure-maps-control"
import { Helpers, Logger, LogLevel } from "./common/"
import { Events, MapEvent } from "./Events";
import { Factory, MapReference } from "./Factory";
import { DataSource, SourceHelper, Sources } from "./Sources";

export class Layers {
    public static add(mapId: string, layer: Layer, events?: MapEvent[]): void {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        Layers.#addLayer(mapRef, layer, events);
    }

    public static addGroups(mapId: string, groups: LayerGroup[]): void {
        Logger.logMapMessage(mapId, LogLevel.Trace, "Layers.addGroups", groups);

        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        groups.forEach((group) => {
            Layers.#addLayer(mapRef, group.layer, group.events);
        });
    }

    static #addLayer(mapRef: MapReference, def: Layer, events?: MapEvent[]): void {
        const eventName = "addLayer";

        //Logger.logMapMessage(mapRef.mapId, LogLevel.Trace, `${eventName}: adding layer.`, def);

        if (Helpers.isEmptyOrNull(def.type)) {
            Logger.logMapMessage(mapRef.mapId, LogLevel.Error, `${eventName}: layer type is missing`, def);
            return;
        }

        const layerId = def.id;

        if (Helpers.isEmptyOrNull(layerId)) {
            Logger.logMapMessage(mapRef.mapId, LogLevel.Error, `${eventName}: layer Id is missing`, def);
            return;
        }

        const lyr = mapRef.map.layers.getLayerById(layerId);
        if (lyr) {
            Logger.logMapMessage(mapRef.mapId, LogLevel.Error, `${eventName}: layer already exists where layer ID=${layerId}`, def);
            return;
        }

        let src: atlas.source.Source | undefined;
        let dsDef: DataSource = def.dataSource;
        const dsId = dsDef.id;

        if (dsDef && Helpers.isNotEmptyOrNull(dsId)) {
            src = SourceHelper.getSource(mapRef, dsId, false);

            if (!src) {
                Sources.add(mapRef.mapId, [dsDef], events);
                src = SourceHelper.getSource(mapRef, dsId);
                if (!src) {
                    Logger.logMapMessage(mapRef.mapId, LogLevel.Error, `${eventName}: Unable to create datasource.`, dsDef);
                    return;
                }
            }
        }

        let layer: atlas.layer.Layer | undefined;
        const layerOptions = (def.options || {}) as any;
        const layerSrc = src!;

        layer = Helpers.switchCaseInsensitive<atlas.layer.Layer | undefined>(def.type, {
            bubble: () => new atlas.layer.BubbleLayer(layerSrc, layerId, layerOptions),
            heatmap: () => new atlas.layer.HeatMapLayer(layerSrc, layerId, layerOptions),
            image: () => new atlas.layer.ImageLayer(layerOptions, layerId),
            line: () => new atlas.layer.LineLayer(layerSrc, layerId, layerOptions),
            polygon: () => new atlas.layer.PolygonLayer(layerSrc, layerId, layerOptions),
            polygonextrusion: () => new atlas.layer.PolygonExtrusionLayer(layerSrc, layerId, layerOptions),
            symbol: () => new atlas.layer.SymbolLayer(layerSrc, layerId, Layers.#resolveSymbolLayerOptions(mapRef.mapId, layerOptions)),
            tile: () => new atlas.layer.TileLayer(layerOptions, layerId)
        }, () => undefined);

        let wasAdded = false;
        if (layer) {
            if (events) {
                Events.layers.addByLayer(mapRef, layer, events);
            }
            
            mapRef.map.layers.add(layer, def.before);
            wasAdded = true;
        }

        if (wasAdded) {
            //Logger.logMapMessage(mapRef.mapId, LogLevel.Trace, `${eventName}: layer added:`, def);
        } else {
            Logger.logMapMessage(mapRef.mapId, LogLevel.Error, `${eventName}: layer type '${def.type}' is not supported.`, def);
        }
    }

    public static remove(mapId: string, layers: Layer[], removeDataSource: boolean): void {
        let idList: string[] = [];

        layers.forEach((layerDef) => {
            idList.push(layerDef.id);
        });

        Layers.removeById(mapId, idList);

        if (removeDataSource) {
            idList = [];
            layers.forEach((layerDef) => {
                if (layerDef.dataSource && Helpers.isNotEmptyOrNull(layerDef.dataSource.id)) {
                    idList.push(layerDef.dataSource.id);
                }
            });

            Sources.removeById(mapId, idList);
        }
    }

    public static removeById(mapId: string, layerIds: string[]): void {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        const eventName = "removeLayer";

        layerIds.forEach((id) => {
            const lyr = mapRef.map.layers.getLayerById(id);
            if (lyr) {
                Events.layers.removeByLayer(mapRef, id);
                mapRef.map.layers.remove(lyr);
                //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: layer with id '${id}' was removed.`);
            }
            else {
                //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: layer with id '${id}' was not found.`);
            }
        });
    }

    public static getOptions(mapId: string, id: string) {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        const lyr = mapRef.map.layers.getLayerById(id);

        if (!lyr) {
            Logger.logMapMessage(mapId, LogLevel.Error, `Layers.getOptions: layer does not exist where layer ID=${id}`);
            return;
        }

        let options = lyr.getOptions();
        options.source = null; //get rid of circular references in the options object that will be serialized and sent to Blazor

        return options;
    }

    public static setOptions(mapId: string, layerDef: Layer): void {
        if (!layerDef?.options) {
            Logger.logMapMessage(mapId, LogLevel.Warn, `Layers.setOptions: options do not exist.`, layerDef);
            return;
        }

        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        const lyr = mapRef.map.layers.getLayerById(layerDef.id);

        if (!lyr) {
            Logger.logMapMessage(mapId, LogLevel.Error, `Layers.setOptions: layer not found.`, layerDef);
            return;
        }

        let layerOptions = Helpers.removeNullish(layerDef.options) as any;

        switch (layerDef.type) {
            case "Symbol":
                layerOptions = Layers.#resolveSymbolLayerOptions(mapId, layerOptions);
                break;
            default:
        }

        //Logger.logMapMessage(mapId, LogLevel.Trace, "Layers.setOptions: setting options.", layerOptions);
        lyr.setOptions(layerOptions);
    }

    static #resolveSymbolLayerOptions(mapId: string, layerOptions: atlas.SymbolLayerOptions): atlas.SymbolLayerOptions {
        const result = { ...layerOptions };
        const iconOptions = result.iconOptions;

        if (!iconOptions) return result;

        const imageId = iconOptions.imageId;
        if (Helpers.isNotEmptyOrNull(imageId)) {
            iconOptions.image = imageId;
        }

        const rotationSpec = iconOptions.rotationSpecification
        if (rotationSpec) {
            iconOptions.rotation = rotationSpec;
        }

        //Logger.logMapMessage(mapId, LogLevel.Trace, "resolveSymbolLayerOptions:", layerOptions);
        return result;
    }

    static showLayer(mapId: string, id: string, isVisible: boolean) {
        const map = Factory.getMap(mapId);
        if (!map)
            return;

        var layer = map.layers.getLayerById(id);
        if (layer) {
            const options = { visible: isVisible ?? true };
            //Logger.logMapMessage(mapId, LogLevel.Trace, "Layers.showLayer: setting options.", options);
            layer.setOptions(options);
        }
    }
}

interface LayerGroup {
    layer: Layer;
    events?: MapEvent[];
}

interface Layer {
    id: string;
    type: 'Bubble' | 'HeatMap' | 'Image' | 'Line' | 'Polygon' | 'PolygonExtrusion' | 'Symbol' | 'Tile';
    dataSource: DataSource;
    before?: string;
    options?: any;
}

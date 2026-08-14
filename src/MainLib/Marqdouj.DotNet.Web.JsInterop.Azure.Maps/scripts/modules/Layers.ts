import * as atlas from "azure-maps-control"
import { Helpers, Logger, LogLevel } from "./common/"
import { Events, MapEvent } from "./Events";
import { Factory, MapReference } from "./Factory";
import { DataSource, ElevationTileSource, VectorTileSource, SourceHelper, Sources } from "./Sources";
import { Popups, PopupDef } from "./Popups";

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
        let dsDef: DataSource | ElevationTileSource | VectorTileSource = def.source;
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
                if (layerDef.source && Helpers.isNotEmptyOrNull(layerDef.source.id)) {
                    idList.push(layerDef.source.id);
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

    public static showLayer(mapId: string, id: string, isVisible: boolean) {
        const map = Factory.getMap(mapId);
        if (!map)
            return;

        const layer = map.layers.getLayerById(id);
        if (layer) {
            const options = { visible: isVisible ?? true };
            //Logger.logMapMessage(mapId, LogLevel.Trace, "Layers.showLayer: setting options.", options);
            layer.setOptions(options);
        }
    }

    public static addHoverPopup(mapId: string, layerId: string, def: PopupDef) {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        const lyr = mapRef.map.layers.getLayerById(layerId);
        if (!lyr) {
            Logger.logMapMessage(mapRef.mapId, LogLevel.Error, `addHoverPopup: layer does not exist where layer ID=${layerId}`);
            return;
        }

        //Create the popup but leave it closed so we can update it and display it later.
        def.show = false;
        def.options.position = [0, 0];
        def.options.pixelOffset = [0, -18];
        Popups.add(mapRef.mapId, [def]);
        const popup = Popups.getPopup(mapRef, def.id);

        if (!popup) {
            Logger.logMapMessage(mapRef.mapId, LogLevel.Error, `addHoverPopup: popup was not created or can't be found where popup ID=${def.id}`);
        }

        //Close the popup when the mouse moves on the map.
        mapRef.map.events.add('mousemove', () => this.#closeSymbolHovered(popup));

        /**
        * Open the popup on mouse move or touchstart on the symbol layer.
        * Mouse move is used as mouseover only fires when the mouse initially goes over a symbol. 
        * If two symbols overlap, moving the mouse from one to the other won't trigger the event for the new shape as the mouse is still over the layer.
        */
        mapRef.map.events.add('mousemove', lyr, (e: atlas.MapMouseEvent) => this.#symbolHovered(e, mapRef.mapId, def, popup));
        mapRef.map.events.add('touchstart', lyr, (e: atlas.MapTouchEvent) => this.#symbolHovered(e, mapRef.mapId, def, popup));
    }

    static #closeSymbolHovered(popup: atlas.Popup | undefined) {
        if (popup) {
            popup.close();
        }
    }

    static #symbolHovered(e: any, mapId: string, def: PopupDef, popup: atlas.Popup | undefined) {
        if (!popup) {
            Logger.logMapMessage(mapId, LogLevel.Error, `symbolHovered: popup is undefined where popup ID=${def.id}`);
            return;
        }

        //Make sure the event occurred on a shape feature.
        if (e.shapes && e.shapes.length > 0) {
            var properties = e.shapes[0].getProperties();
            const tooltipText = properties.tooltip ?? properties.description;

            //Update the content and position of the popup.
            let original = def.options.content as string ?? "";

            if (Helpers.isEmptyOrNull(original)) {
                original = `<div style="padding:5px;border-radius:6px;background-color:black;color:white">${tooltipText}</div>`;
            }

            let updated = original.replace("{tooltip}", tooltipText);
            if (Helpers.isEmptyOrNull(updated)) {
                updated = tooltipText;
            }

            popup.setOptions({
                //Create the content of the popup.
                content: updated,
                position: e.shapes[0].getCoordinates(),
                pixelOffset: [0, -18]
            });

            //Open the popup.
            popup.open();

            // Logger.logMapMessage(mapId, LogLevel.Trace, `symbolHovered: Opened popup`, updated, def, popup);
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
    source: DataSource;
    before?: string;
    options?: any;
}

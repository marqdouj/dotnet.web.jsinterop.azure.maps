import atlas from "azure-maps-control";
import { Helpers, Logger, LogLevel } from "./common/";
import { Factory, MapReference } from "./Factory";
import { Events, MapEvent } from "./Events";

export class Sources {
    // #region Add
    public static add(mapId: string, sources: Source[], events?: MapEvent[]): void {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        sources ??= [];

        sources.forEach((sourceDef) => {
            Sources.#doAdd(mapRef, sourceDef, events);
        });
    }

    static #doAdd(mapRef: MapReference, def: Source, events?: MapEvent[]): void {
        const sourceType = Helpers.switchCaseInsensitive(def.type, {
            datasource: () => "DataSource",
        }, () => "");

        switch (sourceType) {
            case 'DataSource':
                Sources.#doAddDataSource(mapRef, def as DataSource, events);
                break;
            default:
                Logger.logMessage(mapRef.mapId, LogLevel.Warn, `add: unsupported source type: ${def.type}`);
                return;
        }
    }

    static #doAddDataSource(mapRef: MapReference, def: DataSource, events?: MapEvent[]): void {
        if (Helpers.isEmptyOrNull(def.id)) {
            Logger.logMessage(mapRef.mapId, LogLevel.Error, `addDataSource: missing Id.`, def);
            return;
        }

        let ds = mapRef.map.sources.getById(def.id);

        if (ds) {
            Logger.logMessage(mapRef.mapId, LogLevel.Warn, `addDataSource: source with ID '${def.id}' already exists.`);
            return;
        }

        const newDs = new atlas.source.DataSource(def.id, def.options);

        if (events) {
            Events.sources.add(mapRef, events, newDs);
        }

        mapRef.map.sources.add(newDs);

        if (def.url) {
            newDs.importDataFromUrl(def.url);
        }
    }
    // #endregion

    // #region Remove
    public static remove(mapId: string, sources: Source[]): void {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        const idList: string[] = [];
        sources.forEach((sourceDef) => {
            idList.push(sourceDef.id);
        });

        Sources.#doRemoveById(mapRef, idList);
    }

    public static removeById(mapId: string, sources: string[]): void {
        if (sources.length == 0) return;

        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        Sources.#doRemoveById(mapRef, sources);
    }

    static #doRemoveById(mapRef: MapReference, sources: string[]): void {
        sources.forEach((id) => {
            const source = mapRef.map.sources.getById(id);
            if (source) {
                mapRef.map.sources.remove(source);
                //Logger.logMessage(mapRef.mapId, LogLevel.Trace, `remove: source with ID '${id}' was removed.`);
            }
            else {
                //Logger.logMessage(mapRef.mapId, LogLevel.Trace, `remove: source with ID '${id}' was not found.`);
            }
        });
    }
    // #endregion

    // #region Clear
    public static clear(mapId: string, sources: Source[]): void {
        Logger.logMapMessage(mapId, LogLevel.Trace, "Sources.clear", sources);

        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        const idList: string[] = [];
        sources.forEach((sourceDef) => {
            idList.push(sourceDef.id);
        });

        Sources.#doClearById(mapRef, idList);
    }

    public static clearById(mapId: string, sources: string[]): void {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        Sources.#doClearById(mapRef, sources);
    }

    static #doClearById(mapRef: MapReference, sources: string[]): void {
        sources.forEach((id) => {
            const ds = mapRef.map.sources.getById(id);
            if (ds) {
                if ((ds as any).clear != undefined) {
                    (ds as any).clear();
                    Logger.logMessage(mapRef.mapId, LogLevel.Trace, `clear: source with ID '${id}' was cleared.`);
                }
                else {
                    Logger.logMessage(mapRef.mapId, LogLevel.Warn, `clear: source with ID '${id}' does not support 'clear'.`);
                }
            }
            else {
                Logger.logMessage(mapRef.mapId, LogLevel.Warn, `clear: source with ID '${id}' was not found.`);
            }
        });
    }
    // #endregion

    public static getShapes(mapId: string, id: string) {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        let shapes: object[] = [];

        const ds = SourceHelper.getSource(mapRef, id);
        if (ds) {
            if (ds instanceof atlas.source.DataSource) {
                Helpers.buildShapeResults(ds.getShapes());
            }
            else {
                Logger.logMessage(mapId, LogLevel.Warn, `getShapes: source with ID '${id}' does not support 'getShapes'.`);
            }
        }

        return shapes;
    }
}

export class SourceHelper {
    static getSource(mapRef: MapReference, id: string | undefined, logNotFound: boolean = true): atlas.source.Source | undefined {
        if (!id)
            return;

        const source = mapRef.map.sources.getById(id);

        if (!source && logNotFound) {
            Logger.logMessage(mapRef.mapId, LogLevel.Warn, `get: source with ID '${id}' was not found.`);
        }

        return source;
    }

    static getDataSource(mapRef: MapReference, datasourceId: string, logLevelFail: LogLevel = LogLevel.Error): atlas.source.DataSource | undefined {
        const ds = SourceHelper.getSource(mapRef, datasourceId);

        if (!ds) {
            return undefined;
        }

        if (!SourceHelper.isDataSource(ds)) {
            Logger.logMessage(mapRef.mapId, logLevelFail, `getDataSource: source with ID '${datasourceId}' is not a DataSource`);
            return undefined;
        }

        return ds;
    }

    static isDataSource(obj: any): obj is atlas.source.DataSource {
        return obj && (obj instanceof atlas.source.DataSource);
    }
}


interface Source {
    id: string;
    type: 'DataSource' | 'ElevationTile' | 'VectorTile';
}

export interface DataSource extends Source {
    url: string;
    options?: atlas.DataSourceOptions;
}


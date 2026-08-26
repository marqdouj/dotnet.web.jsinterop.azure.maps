import * as atlas from "azure-maps-control"
import * as spatial from "azure-maps-spatial-io"
import { Factory } from "./Factory";
import { Helpers, Logger, LogLevel } from "./common/"
import { SourceHelper } from "./Sources";
import { Animations } from "../AzureMaps";

export class SpatialSources {
    public static async read(mapId: string, parameters: SpatialReadParameters): Promise<SpatialReadResults> {
        const eventName = "SpatialSources.read";
        var result: SpatialReadResults = { success: false };

        //Logger.logMapMessage(mapId, LogLevel.Trace, eventName, parameters);

        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return result;

        var src = SourceHelper.getDataSource(mapRef, parameters.dataSourceId);

        if (!src) {
            Logger.logMapMessage(mapId, LogLevel.Error, `${eventName}: datasource with ID=${parameters.dataSourceId} not found.`);
            return result;
        }

        var newOptions = Helpers.removeNullish(parameters.options);
        Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: removeNullish options.`, newOptions, parameters.options);

        await this.#readUrl(mapId, parameters.url, newOptions)
            .then(r => {
                Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: await readUrl ok.`, r);

                if (r) {
                    const dsAction = Helpers.switchCaseInsensitive(parameters.action, {
                        add: () => "Add",
                        setshapes: () => "SetShapes",
                    }, () => "");

                    //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: dsAction.`, dsAction);
                    
                    switch (dsAction) {
                        case "Add":
                            src!.add(r);
                            break;
                        case "SetShapes":
                            src!.setShapes(r);
                            break;
                        default:
                            throw new Error(`${eventName}: read action not supported '${parameters.action}'.`);
                    }

                    if (parameters.routeLength > 0) {
                        result.route = Animations.extractRoutePointsFromShape(r, parameters.routeLength, parameters.routeTimestamp);
                        //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: extractRoutePointsFromShape`, result.route);
                    }
                    //If bounding box information is known for data, set the map view to it.
                    if (r.bbox) {
                        mapRef.map.setCamera({
                            bounds: r.bbox,
                            padding: parameters.padding
                        });

                        //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: setting result.`, r.bbox, result);
                        result.bbox = r.bbox;
                    }
                    
                    result.success = true;
                }
                else {
                    throw new Error(`${eventName}: read returned empty dataset.`);
                }
            })
            .catch(error => {
                Logger.logMapMessage(mapId, LogLevel.Error, `${eventName}: read failed.`, error.message);
                throw new Error(`${eventName}: read failed.`);
            }
        );

        //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: result.`, result);
        return result;
    }

    static #readUrl(mapId: string, url: string, options?: any): Promise<spatial.SpatialDataSet | undefined> {
        const eventName = "SpatialSources.#readUrl";
        //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: begin.`, url);

        return new Promise((resolve, reject) => {
            try {
                //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: begin read.`);
                spatial.io.read(url, options).then(r => {
                    //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: read ok.`, url);
                    resolve(r);
                }).catch(err => {
                    Logger.logMapMessage(mapId, LogLevel.Error, `${eventName}: read failed.`, url, err);
                    reject(err.message);
                });
            } catch (err) {
                Logger.logMapMessage(mapId, LogLevel.Error, `${eventName}: read failed.`, err);
                reject(err);
            }
        });
    }
}

type readAction = 'Add' | 'SetShapes';

interface SpatialReadParameters {
    dataSourceId: string;
    url: string;
    action: readAction;
    options?: any;
    padding: number;
    routeLength: number;
    routeTimestamp?: string;
}

interface SpatialReadResults {
    bbox?: atlas.data.BoundingBox;
    route?: atlas.data.Feature<atlas.data.Point, any>[];
    success: boolean;
}
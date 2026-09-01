import * as atlas from "azure-maps-control"
import * as spatial from "azure-maps-spatial-io"
import * as anims from "azure-maps-animations"
import { Factory } from "./Factory";
import { Helpers, Logger, LogLevel } from "./common/"
import { SourceHelper } from "./Sources";
import { Events, MapEvent } from "./Events";
import { Animations } from "./Animations";

export class SpatialSources {
    public static async loadGPSTrace(mapId: string, parameters: LoadGPSTraceParameters): Promise<LoadGPSTraceResults> {
        const eventName = "SpatialSources.loadGPSTrace";

        var result: LoadGPSTraceResults = { success: false };

        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return result;

        parameters = Helpers.removeNullish(parameters);

        if (Helpers.isEmptyOrNull(parameters.animationId)) {
            throw new Error(`${eventName}: missing animationId.`);
        }

        const dsRoute = SourceHelper.getDataSource(mapRef, parameters.routeSourceId);
        if (!dsRoute) {
            throw new Error(`${eventName}: DataSource not found where id = '${parameters.routeSourceId}'.`);
        }

        const dsShape = SourceHelper.getDataSource(mapRef, parameters.shapeSourceId);
        if (!dsShape) {
            throw new Error(`${eventName}: ShapeSource not found where id = '${parameters.shapeSourceId}'.`);
        }

        dsRoute.clear();
        dsShape.clear();

        let animation = mapRef.getAnimation(parameters.animationId);

        if (animation) {
            Events.animations.remove(mapRef, parameters.events);
            mapRef.removeAnimation(parameters.animationId);
            animation.dispose();
            animation = undefined;
        }

        if (Helpers.isNotEmptyOrNull(parameters.url)) {
            await this.#readUrl(mapId, parameters.url, parameters.readOptions)
                .then(r => {
                    if (r) {
                        dsRoute.add(r);

                        //If bounding box information is known for data, set the map view to it.
                        if (r.bbox) {
                            mapRef.map.setCamera({
                                bounds: r.bbox,
                                padding: parameters.padding
                            });

                            result.bbox = r.bbox;
                        }

                        const route = Animations.extractRoutePointsFromShape(r, -1, parameters.timestampProperty);

                        if (route && route.length > 0) {
                            result.route = Helpers.getFirstNItems(route, 1);

                            const pin = new atlas.Shape(route[0]);
                            dsShape.add(pin);
                            result.shapeId = pin.getId().toString();

                            const pathOptions = parameters.pathOptions ?? {};

                            if (parameters.follow) {
                                pathOptions ?? {};
                                pathOptions.map = mapRef.map as any;
                            }

                            try {
                                animation = anims.animations.moveAlongRoute(route, pin as any, pathOptions);

                                if (animation) {
                                    Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: animation was created`, animation);
                                    mapRef.setAnimation(parameters.animationId, animation);
                                    Events.animations.add(mapRef, parameters.events);
                                    Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: animation was set`, mapRef.getAnimation(parameters.animationId, true));
                                }

                                result.success = true;
                            } catch (e) {
                                Logger.logMapMessage(mapId, LogLevel.Error, "create animation failed", e);
                            }
                        }
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
        }
        else {
            Logger.logMapMessageAndThrow(mapId, `${eventName}: url is missing.`);
        }

        return result;
    }

    public static async read(mapId: string, parameters: SpatialReadParameters): Promise<SpatialReadResults> {
        const eventName = "SpatialSources.read";
        var result: SpatialReadResults = { success: false };

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
                    }
                    //If bounding box information is known for data, set the map view to it.
                    if (r.bbox) {
                        mapRef.map.setCamera({
                            bounds: r.bbox,
                            padding: parameters.padding
                        });

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

        return result;
    }

    static #readUrl(mapId: string, url: string, options?: any): Promise<spatial.SpatialDataSet | undefined> {
        const eventName = "SpatialSources.#readUrl";

        return new Promise((resolve, reject) => {
            try {
                spatial.io.read(url, options).then(r => {
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

interface LoadGPSTraceParameters {
    animationId: string;
    routeSourceId: string;
    shapeSourceId: string;
    url: string;
    timestampProperty?: string;
    readOptions: spatial.SpatialDataReadOptions;
    pathOptions: anims.RoutePathAnimationOptions;
    follow: boolean;
    padding: number;
    events?: MapEvent[];
}

interface LoadGPSTraceResults extends SpatialReadResults {
    shapeId?: string;
}
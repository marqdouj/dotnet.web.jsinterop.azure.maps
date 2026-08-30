import * as atlas from "azure-maps-control"
import * as anims from "azure-maps-animations"
import { MapFeature } from "./Features";
import { EditAction, Helpers, Logger, LogLevel } from "./common/";
import { Factory } from "./Factory";
import { SourceHelper } from "./Sources";
import { Events, MapEvent } from "./Events";

export class Animations {
    public static getEasingNames(mapId: string): string[] {
        if (Animations.#animationsNotFound(mapId, "getEasingNames"))
            return [];

        return anims.animations.getEasingNames();
    }

    public static async animateShape(mapId: string, args: AnimateShapeArgs): Promise<void> {
        const eventName = "Animations.animateShape";
        Logger.logMapMessage(mapId, LogLevel.Trace, eventName, args);

        const editAction = Helpers.switchCaseInsensitive(args.editAction, {
            replace: () => EditAction.Replace,
            update: () => EditAction.Update,
        }, () => EditAction.Update);

        switch (editAction) {
            case EditAction.Replace:
                break;
            case EditAction.Update:
                args.animationOptions = Helpers.removeNullish(args.animationOptions);
                break;
            default:
                Logger.logMapMessage(mapId, LogLevel.Warn, eventName, `Unknown editAction: ${args.editAction}. No action taken.`);
                return;
        }

        const aniAction: any = Helpers.switchCaseInsensitive(args.action, {
            setcoordinates: () => AnimateAction.SetCoordinates,
        }, () => AnimateAction.Undefined);

        switch (aniAction) {
            case AnimateAction.SetCoordinates:
                await Animations.#setCoordinates(mapId, args);
                break;
            default:
                Logger.logMapMessage(mapId, LogLevel.Error, `${eventName}: action not supported.`, args.action);
        }
    }

    static async #setCoordinates(mapId: string, options: AnimateShapeArgs): Promise<void> {
        const eventName = "Animations.setCoordinates";

        if (Animations.#animationsNotFound(mapId, eventName)) return;

        const map = Factory.getMap(mapId);
        if (!map)
            return;


        const ds = map.sources.getById(options.dataSourceId);
        if (!ds) {
            Logger.logMapMessage(mapId, LogLevel.Error, `${eventName}: DataSource not found.`, options);
            return;
        }

        const featureId = options.shape.id;

        if (SourceHelper.isDataSource(ds)) {
            let shape = ds.getShapeById(featureId);
            if (!shape) {
                Logger.logMapMessage(mapId, LogLevel.Error, `${eventName}: Shape not found where shapeId = '${featureId}'.`, options);
                return;
            }

            anims.animations.setCoordinates(shape as any, options.shape.geometry.coordinates, options.animationOptions);
            if (options.shape.properties)
                shape.addProperty("heading", options.shape.properties["heading"]);
        } else {
            Logger.logMapMessage(mapId, LogLevel.Error, `${eventName}: DataSource not found where id = '${options.dataSourceId}'.`, options);
        }
    }

    static #animationsNotFound(mapId: string, eventName: string): boolean {
        if (anims.animations) {
            return false;
        }
        else {
            Logger.logMapMessage(mapId, LogLevel.Error, `${eventName}: atlas.animations module not found.`);
            return true;
        }
    }

    public static extractRoutePoints(mapId: string, dataSourceId: string, shapeId: string, length: number, timestampProperty?: string): atlas.data.Feature<atlas.data.Point, any>[] | undefined {
        const eventName = "Animations.extractRoutePoints";

        if (Animations.#animationsNotFound(mapId, eventName))
            return;

        const map = Factory.getMap(mapId);
        if (!map) return;

        const ds = map.sources.getById(dataSourceId) as atlas.source.DataSource;
        if (!ds) {
            Logger.logMapMessage(mapId, LogLevel.Error, `${eventName}: DataSource not found where Id = '${dataSourceId}'`,);
            return;
        }

        const shape: any = ds.getShapeById(shapeId);
        return this.extractRoutePointsFromShape(shape, length, timestampProperty);
    }

    public static extractRoutePointsFromShape(shape: any, length: number, timestampProperty?: string): atlas.data.Feature<atlas.data.Point, any>[] | undefined {
        const eventName = "Animations.extractRoutePointsFromShape";
        if (!shape) {
            Logger.logMessage("Animations", LogLevel.Error, `${eventName}: shape is undefined.`);
            return;
        }

        if (length == 0 || length < -1)
            return [];

        var route = anims.animations.extractRoutePoints(shape, timestampProperty);
        return length == -1 ? route : Helpers.getFirstNItems(route, length);
    }

    public static moveAlongRoute(mapId: string, args: MoveAlongRouteArgs) {
        const eventName = "Animations.moveAlongRoute";
       
        Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: entered.`, args);
        args = Helpers.removeNullish(args);
        Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: nullish args.`, args);

        if (Animations.#animationsNotFound(mapId, eventName))
            return;

        if (Helpers.isEmptyOrNull(args.animationId)) {
            throw new Error(`${eventName}: missing animationId.`);
        }

        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        let animation = mapRef.getAnimation(args.animationId);

        if (animation) {
            Events.animations.remove(mapRef, args.events);
            mapRef.removeAnimation(args.animationId);
            animation.dispose();
        }

        const dsRoute = SourceHelper.getDataSource(mapRef, args.routeSourceId);
        if (!dsRoute) {
            throw new Error(`${eventName}: DataSource not found where id = '${args.routeSourceId}'.`);
        }

        const dsShape = SourceHelper.getDataSource(mapRef, args.shapeSourceId);
        if (!dsShape) {
            throw new Error(`${eventName}: ShapeSource not found where id = '${args.shapeSourceId}'.`);
        }

        const routeShapes = dsRoute.getShapeById(args.routeShapeId) ?? dsRoute.getShapes();
        if (!routeShapes) {
            if (Helpers.isNotEmptyOrNull(args.routeShapeId)) {
                throw new Error(`${eventName}: route shape not found where id = '${args.routeShapeId}'.`);
            }
            else {
                throw new Error(`${eventName}: route shape not found where routeSourceId = '${args.routeSourceId}'.`);
            }
        }

        const shape = dsShape.getShapeById(args.shapeId)
        if (!shape) {
            throw new Error(`${eventName}: shape not found where id = '${args.shapeId}'.`);
        }

        const route = this.extractRoutePointsFromShape(routeShapes, -1, args.timestampProperty);

        if (route) {
            Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: route was found`, route);

            if (args.follow) {
                args.options ?? {};
                args.options.map = mapRef.map as any;
            }

            try {
                Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: attempting to create animation`, route, shape, args.options);
                animation = anims.animations.moveAlongRoute(route, shape as any, args.options);
            } catch (e) {
                Logger.logMapMessage(mapId, LogLevel.Error, "create animation failed", e);
            }

            if (animation) {
                Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: animation was created`, animation);
                mapRef.setAnimation(args.animationId, animation);
                Events.animations.add(mapRef, args.events);
            }
        }
        else {
            throw new Error(`${eventName}: route shape not found where id = '${args.routeShapeId}'.`);
        }
    }
}

enum AnimateAction {
    Undefined = '',
    SetCoordinates = 'SetCoordinates',
}

interface AnimateShapeArgs {
    action: AnimateAction;
    editAction: EditAction;
    shape: MapFeature;
    dataSourceId: string;
    animationOptions: anims.PlayableAnimationOptions;
}

interface MoveAlongRouteArgs {
    animationId: string;
    routeSourceId: string;
    routeShapeId: string;
    shapeSourceId: string;
    shapeId: string;
    events?: MapEvent[];
    options: any;
    timestampProperty?: string;
    follow: boolean;
}

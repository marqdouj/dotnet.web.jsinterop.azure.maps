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
        //Logger.logMapMessage(mapId, LogLevel.Trace, eventName, args);

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

    public static updateAnimation(mapId: string, animationId: string, action: string) {
        const eventName = "Animations.updateAnimation";
        //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: entered.`, animationId, action);

        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        const animation = mapRef.getAnimation(animationId, true);

        //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: animation was retrieved`, animation);

        if (animation && animation[action]) {
            //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: animation actioned`, action);
            animation[action]();``
        }
    }

    public static setOptions(mapId: string, animationId: string, options: any) {
        const eventName = "Animations.setOptions";
        //Logger.logMapMessage(mapId, LogLevel.Trace, `${eventName}: entered.`, animationId, options);

        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        const animation = mapRef.getAnimation(animationId, true);

        if (animation) {
            options = Helpers.removeNullish(options);
            if (!options) {
                Logger.logMapMessage(mapId, LogLevel.Warn, `${eventName}: options are missing.`, options);
                return;
            }
            options.map = Helpers.isNotEmptyOrNull(options.mapId) ? mapRef.map : null;
            animation.setOptions(options);
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

import * as anims from "azure-maps-animations"
import { MapFeature } from "./Features";
import { EditAction, Helpers, Logger, LogLevel } from "./common/";
import { Factory } from "./Factory";
import { SourceHelper } from "./Sources";

export class Animations {
    static getEasingNames(mapId: string): string[] {
        if (Animations.#animationsNotFound(mapId))
            return [];

        return anims.animations.getEasingNames();
    }

    static async animateShape(mapId: string, args: AnimateShapeArgs): Promise<void> {
        Logger.logMapMessage(mapId, LogLevel.Trace, "Animations.animateShape", args);

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
                Logger.logMapMessage(mapId, LogLevel.Warn, "Animations.animateShape", `Unknown editAction: ${args.editAction}. No action taken.`);
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
                Logger.logMessage(mapId, LogLevel.Error, "Animations.animateShape: action not supported.", args.action);
        }
    }

    static async #setCoordinates(mapId: string, options: AnimateShapeArgs): Promise<void> {
        if (Animations.#animationsNotFound(mapId)) return;

        const map = Factory.getMap(mapId);
        if (!map) return;

        const eventName = "Animations.animateShape: ";

        const ds = map.sources.getById(options.dataSourceId);
        if (!ds) {
            Logger.logMessage(mapId, LogLevel.Error, `${eventName}DataSource not found.`, options);
            return;
        }

        const featureId = options.shape.id;

        if (SourceHelper.isDataSource(ds)) {
            let shape = ds.getShapeById(featureId);
            if (!shape) {
                Logger.logMessage(mapId, LogLevel.Error, `${eventName}Shape not found where shapeId = '${featureId}'.`, options);
                return;
            }

            anims.animations.setCoordinates(shape as any, options.shape.geometry.coordinates, options.animationOptions);
            if (options.shape.properties)
                shape.addProperty("heading", options.shape.properties["heading"]);
        } else {
            Logger.logMessage(mapId, LogLevel.Error, `${eventName}DataSource not found where id = '${options.dataSourceId}'.`, options);
        }
    }

    static #animationsNotFound(mapId: string): boolean {
        if (anims.animations) {
            return false;
        }
        else {
            //Logger.logMessage(mapId, LogLevel.Trace, "Animations.setCoordinates: atlas.animations module not found.");
            return true;
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


import * as atlas from "azure-maps-control"
import { Logger, LogLevel, Helpers, EditAction } from "./common/"
import { Factory } from "../AzureMaps";

export class Configuration {

    // #region MapOptions
    public static getMapOptions(mapId: string, args: GetMapOptionsArgs): any {
        const result: GetMapOptionsResult = {};

        if (args.camera) {
            result.camera = this.getCamera(mapId);
        }

        if (args.service) {
            result.service = this.getServiceOptions(mapId);
        }

        if (args.style) {
            result.style = this.getStyle(mapId);
        }

        if (args.traffic) {
            result.traffic = this.getTraffic(mapId);
        }

        if (args.userInteraction) {
            result.userInteraction = this.getUserInteraction(mapId);
        }

        //Logger.logMapMessage(mapId, LogLevel.Trace, "Configuration.getOptions", result);
        return result;
    }

    public static setMapOptions(mapId: string, args: SetMapOptionsArgs): void {
        //Logger.logMapMessage(mapId, LogLevel.Trace, "Configuration.setMapOptions", args);

        const action = Helpers.switchCaseInsensitive(args.editAction, {
            replace: () => EditAction.Replace,
            update: () => EditAction.Update,
        }, () => EditAction.Update);

        switch (action) {
            case EditAction.Replace:
            case EditAction.Update:
                break;
            default:
                Logger.logMapMessage(mapId, LogLevel.Warn, "Configuration.setMapOptions", `Unknown editAction: ${args.editAction}. No action taken.`);
                return;
        }

        if (args) {
            this.setCamera(mapId, this.#buildSetMapCameraArgs(args), action);
            this.setServiceOptions(mapId, args.service, action);
            this.setStyle(mapId, args.style, action);
            this.setTraffic(mapId, args.traffic, action);
            this.setUserInteraction(mapId, args.userInteraction, action);
        }
    }

    // #endregion

    // #region Camera
    public static getCamera(mapId: string): any {
        const map = Factory.getMap(mapId);
        if (!map) {
            return;
        }

        const camera = map.getCamera();
        //Logger.logMapMessage(mapId, LogLevel.Trace, "Configuration.getCamera", camera);

        return camera;
    }

    public static setCamera(mapId: string, options: SetMapCameraArgs | undefined, action: EditAction): void {
        if (!options) return;

        const map = Factory.getMap(mapId);
        if (!map) {
            return;
        }

        let updatedOptions = this.#buildSetCameraOptions(options);

        switch (action) {
            case EditAction.Replace:
                break;
            case EditAction.Update:
                updatedOptions = Helpers.removeNullish(updatedOptions);
                break;
        }

        //Logger.logMapMessage(mapId, LogLevel.Trace, "Configuration.setCamera", options, updatedOptions);
        map.setCamera(updatedOptions);
    }

    static #buildSetMapCameraArgs(args: SetMapOptionsArgs): SetMapCameraArgs | undefined {
        if (!args.camera && !args.cameraBounds) return undefined;

        const result: SetMapCameraArgs = {
            animation: args.animation,
            camera: args.camera,
            cameraBounds: args.cameraBounds,
        };

        //Logger.logMapMessage("", LogLevel.Trace, "Configuration.#buildMapCamera", result);
        return result;
    }

    static #buildSetCameraOptions(options: SetMapCameraArgs): SetCameraOptions {
        let cameraOptions: SetCameraOptions = {};

        if (options.camera) {
            cameraOptions = { ...options.camera };
        }
        else if (options.cameraBounds) {
            cameraOptions = { ...options.cameraBounds };
        }

        if (options.animation) {
            cameraOptions = { ...cameraOptions, ...options.animation };
        }

        //Logger.logMapMessage("", LogLevel.Trace, "Configuration.#buildSetCameraOptions", cameraOptions);
        return cameraOptions;
    }

    // #endregion

    // #region Service
    public static getServiceOptions(mapId: string): any {
        const map = Factory.getMap(mapId);
        if (!map) {
            return;
        }

        const options = map.getServiceOptions();
        //Logger.logMapMessage(mapId, LogLevel.Trace, "Configuration.getServiceOptions", options);
        return options;
    }

    public static setServiceOptions(mapId: string, options: atlas.ServiceOptions | undefined, action: EditAction): void {
        if (!options) return;

        const map = Factory.getMap(mapId);
        if (!map) {
            return;
        }

        let updatedOptions = options;

        switch (action) {
            case EditAction.Replace:
                break;
            case EditAction.Update:
                updatedOptions = Helpers.removeNullish(updatedOptions);
                break;
        }

        //Logger.logMapMessage(mapId, LogLevel.Trace, "Configuration.setServiceOptions", options, updatedOptions);
        map.setServiceOptions(updatedOptions);
    }

    // #endregion

    // #region Style
    public static getStyle(mapId: string): any {
        const map = Factory.getMap(mapId);
        if (!map) {
            return;
        }

        const options = map.getStyle();
        //Logger.logMapMessage(mapId, LogLevel.Trace, "Configuration.getStyle", options);

        return options;
    }

    public static setStyle(mapId: string, options: atlas.StyleOptions | undefined, action: EditAction): void {
        if (!options) return;

        const map = Factory.getMap(mapId);
        if (!map) {
            return;
        }

        let updatedOptions = options;

        switch (action) {
            case EditAction.Replace:
                break;
            case EditAction.Update:
                updatedOptions = Helpers.removeNullish(updatedOptions);
                break;
        }

        //Logger.logMapMessage(mapId, LogLevel.Trace, "Configuration.setStyle", options, updatedOptions);
        const diff = action === EditAction.Update;
        map.setStyle(updatedOptions, diff);
    }

    // #endregion

    // #region Traffic
    public static getTraffic(mapId: string): atlas.TrafficOptions | undefined {
        const map = Factory.getMap(mapId);
        if (!map) {
            return undefined;
        }

        const options = map.getTraffic();
        //Logger.logMapMessage(mapId, LogLevel.Trace, "Configuration.getTraffic", options);
        return options;
    }

    public static setTraffic(mapId: string, options: atlas.TrafficOptions | undefined, action: EditAction): void {
        if (!options) return;

        const map = Factory.getMap(mapId);
        if (!map) {
            return;
        }

        let updatedOptions = options;

        switch (action) {
            case EditAction.Replace:
                break;
            case EditAction.Update:
                updatedOptions = Helpers.removeNullish(updatedOptions);
                break;
        }

        //Logger.logMapMessage(mapId, LogLevel.Trace, "Configuration.setTraffic", options, updatedOptions);
        map.setTraffic(updatedOptions);
    }

    // #endregion

    // #region UserInteraction
    public static getUserInteraction(mapId: string): any {
        const map = Factory.getMap(mapId);
        if (!map) {
            return;
        }

        const options = map.getUserInteraction();
        //Logger.logMapMessage(mapId, LogLevel.Trace, "Configuration.getUserInteraction", options);

        return options;
    }

    public static setUserInteraction(mapId: string, options: atlas.UserInteractionOptions | undefined, action: EditAction): void {
        if (!options) return;

        const map = Factory.getMap(mapId);
        if (!map) {
            return;
        }

        let updatedOptions = options;

        switch (action) {
            case EditAction.Replace:
                break;
            case EditAction.Update:
                updatedOptions = Helpers.removeNullish(updatedOptions);
                break;
        }

        //Logger.logMapMessage(mapId, LogLevel.Trace, "Configuration.setUserInteraction", options, updatedOptions);
        map.setUserInteraction(updatedOptions);
    }

    public static zoomTo(mapId: string, center: atlas.data.Position, zoomLevel: number, animation?: atlas.AnimationOptions): void {
        const map = Factory.getMap(mapId);
        if (!map) {
            return;
        }

        const cameraOptions: atlas.CameraOptions = {};
        cameraOptions.center = center;

        if (zoomLevel != undefined)
            cameraOptions.zoom = zoomLevel;

        //Logger.logMapMessage(mapId, LogLevel.Trace, "Configuration.zoomTo", cameraOptions);
        this.setCamera(mapId, { camera: cameraOptions, animation: animation }, EditAction.Update);
    }

    // #endregion
}

type SetCameraOptions = (atlas.CameraOptions | (atlas.CameraBoundsOptions & { pitch?: number, bearing?: number })) & atlas.AnimationOptions;
type SetCameraBoundsOptions = atlas.CameraBoundsOptions & { pitch?: number, bearing?: number };


export interface MapOptions {
    camera?: atlas.CameraOptions;
    cameraBounds?: atlas.CameraBoundsOptions;
    service?: atlas.ServiceOptions;
    style?: atlas.StyleOptions;
    traffic?: atlas.TrafficOptions;
    userInteraction?: atlas.UserInteractionOptions;
}

interface SetMapOptionsArgs {
    editAction: EditAction;
    animation?: atlas.AnimationOptions;
    camera?: atlas.CameraOptions;
    cameraBounds?: SetCameraBoundsOptions;
    service?: atlas.ServiceOptions;
    style?: atlas.StyleOptions;
    traffic?: atlas.TrafficOptions;
    userInteraction?: atlas.UserInteractionOptions;
}

interface SetMapCameraArgs {
    animation?: atlas.AnimationOptions;
    camera?: atlas.CameraOptions;
    cameraBounds?: SetCameraBoundsOptions;
}

interface GetMapOptionsArgs {
    camera: boolean;
    service: boolean;
    style: boolean;
    userInteraction: boolean;
    traffic: boolean;
}

interface GetMapOptionsResult {
    camera?: any;
    service?: any;
    style?: any;
    traffic?: any;
    userInteraction?: any;
}
import * as atlas from "azure-maps-control"
import { EventsMap } from "./events/EventsMap"
import { Logger, LogLevel, Helpers } from "./common/"
import { MapOptions } from "./Configuration";
import { Controls, MapControl } from "./Controls"
import { MapEvent, Events, EventNotification } from "./Events"
import { EventsHelper } from "./events/EventsHelper"

export class Factory {
    static #azmaps: Map<string, MapReference> = new Map<string, MapReference>();

    public static setLogLevel(logLevel: LogLevel) {
        if (Logger.currentLevel === logLevel) return;

        const previousLevel = Logger.currentLevel;
        Logger.currentLevel = logLevel;
        Logger.logMessage("Setting LogLevel", LogLevel.Information, `LogLevel was [${LogLevel[previousLevel]}]. LogLevel set to [${LogLevel[Logger.currentLevel]}].`);
    }

    public static createMap(args: CreateMapArgs): CreateMapResult {
        this.setLogLevel(args.config.jsLogLevel);

        //Logger.logMapMessage(args.mapId, LogLevel.Trace, "Factory.createMap:args", args);

        const mapId = args.mapId;

        try {
            if (this.#azmaps.has(mapId)) {
                Logger.logMapMessage(mapId, LogLevel.Warn, `Map with id '${mapId}' already exists.`);
                return { mapId: mapId, status: "exists", message: `Map with id '${mapId}' already exists.` };
            }

            const mapOptions = Factory.#buildMapOptions(args.mapId, args.config);

            const azmap = new atlas.Map(args.mapId, mapOptions);
            const mapReference = new MapReference(args.dotNetRef, mapId, azmap);
            this.#azmaps.set(mapId, mapReference);

            Logger.logMapMessage(args.mapId, LogLevel.Debug, "Map was created");

            Controls.add(mapId, args.controls);

            if (args.events)
                Factory.#addEvents(mapReference, args.events);

            return { mapId: mapId, status: "created", message: "was created." };
        } catch (err: unknown) {
            Logger.logMapMessage(mapId, LogLevel.Error, "Error creating map.", err);

            if (err instanceof Error) {
                return { mapId: mapId, status: "failure", error: err };
            } else {
                return { mapId: mapId, status: "failure", message: `${err}` };
            }
        }
    }

    public static getMap(mapId: string): atlas.Map | undefined {
        var mapRef = this.getMapReference(mapId);
        if (!mapRef) {
            Logger.logMapMessage(mapId, LogLevel.Warn, "Factory.getMap: Map was not found.");
            return undefined;
        }
        return mapRef.map;
    }

    public static getMapReference(mapId: string): MapReference | undefined {
        const mapRef = this.#azmaps.get(mapId);

        if (!mapRef) {
            Logger.logMessage(mapId, LogLevel.Warn, "Factory.getMapReference: MapReference was not found.");
        }

        return mapRef;
    }

    public static clear() {
        const keys: string[] = [...this.#azmaps.keys()];

        keys.forEach(mapId => {
            this.removeMap(mapId);
        });
    }

    public static removeMap(mapId: string): void {
        if (this.#azmaps.has(mapId)) {
            var mapRef = this.getMapReference(mapId);
            this.#azmaps.delete(mapId);
            mapRef?.clear();
            Logger.logMapMessage(mapId, LogLevel.Debug, "was removed.");
        }
        else {
            Logger.logMapMessage(mapId, LogLevel.Warn, "Factory.removeMap: map not found.");
        }
    }

    static #buildMapOptions(mapId: string, config: MapConfiguration): TBuildMapOptions {
        let options: TBuildMapOptions = {};

        const mapOptions = Helpers.nullToUndefined(config.mapOptions);

        if (mapOptions) {
            //Camera and CameraBounds are mutually exclusive
            if (mapOptions.camera) {
                options = { ...options, ...mapOptions.camera };
            }
            else if (mapOptions.cameraBounds) {
                options = { ...options, ...mapOptions.cameraBounds };
            }

            if (mapOptions.service) {
                options = { ...options, ...mapOptions.service };
            }

            if (mapOptions.style) {
                options = { ...options, ...mapOptions.style };
            }
            if (mapOptions.userInteraction) {
                options = { ...options, ...mapOptions.userInteraction };
            }
        }

        options.authOptions = config.authOptions;
        const sasTokenUrl = (config.authOptions as any).sasTokenUrl;
        if (Helpers.isNotEmptyOrNull(sasTokenUrl)) {
            options.authOptions.getToken = function (resolve, reject, map) {
                fetch(sasTokenUrl).then(r => r.text()).then(token => resolve(token));
            }
        }
        else {
            if (globalThis.AzureMapsAuthTokenCallback && typeof globalThis.AzureMapsAuthTokenCallback === "function") {
                //Logger.logMapMessage(mapId, LogLevel.Trace, "Setting global AzureMapsAuthTokenCallback function.", globalThis.AzureMapsAuthTokenCallback);
                options.authOptions.getToken = globalThis.AzureMapsAuthTokenCallback;
            }
        }

        //Logger.logMapMessage(mapId, LogLevel.Trace, "Factory.createMap:buildMapOptions", config, options);

        return options;
    }

    static #addEvents(mapReference: MapReference, events: any[]): void {
        const dotNetRef = mapReference.dotNetRef;
        const mapId = mapReference.mapId!;
        const azmap = mapReference.map;

        if (!azmap) {
            Logger.logMapMessage(mapId!, LogLevel.Error, "Cannot build events. Map not found.");
            return;
        }

        events ??= [];

        azmap.events.addOnce(MapEventCreate.Ready, event => {
            const errorDef: MapEvent = { target: "map", type: MapEventCreate.Error };
            const readyDef: MapEvent = { target: "map", type: MapEventCreate.Ready };

            azmap.events.add(MapEventCreate.Error, event => {
                const payload = { error: { message: event.error.message, name: event.error.name, stack: event.error.stack, cause: event.error.cause } };
                const args = EventsHelper.buildMapEventArgs(mapId, errorDef, payload);

                Logger.logMessage(mapId, LogLevel.Error, 'Map error', args);
                dotNetRef.invokeMethodAsync(EventNotification.NotifyMapEventError, args);
            });

            Events.add(mapId, events);

            const args = EventsHelper.buildMapEventArgs(mapId, readyDef);
            //Logger.logMapMessage(mapId, LogLevel.Trace, "Factory.#addEvents", EventNotification.NotifyMapEventReady, args);
            dotNetRef.invokeMethodAsync(EventNotification.NotifyMapEventReady, args);
        });
    }
}

export class MapReference {
    #dotNetRef: any;
    #map: atlas.Map | undefined;
    #mapId: string | undefined;
    #eventsMap: EventsMap | undefined;
    #animations: Map<string, object> | undefined = new Map<string, object>();

    constructor(dotNetRef: any, mapId: string, azMap: atlas.Map) {
        this.#dotNetRef = dotNetRef;
        this.#mapId = mapId;
        this.#map = azMap;
        this.#eventsMap = new EventsMap(mapId);
    }

    get dotNetRef(): any { return this.#dotNetRef! }
    get eventsMap(): EventsMap { return this.#eventsMap!; }
    get mapId(): string { return this.#mapId! }
    get map(): atlas.Map { return this.#map! }

    getAnimation(id: string): any { return this.#animations?.get(id); }
    setAnimation(id: string, value: object) { this.#animations?.set(id, value); }
    removeAnimation(id: string) { this.#animations?.delete(id); }

    clear() {
        this.#dotNetRef = null;
        this.#mapId = undefined;
        this.#map?.dispose();
        this.#map = undefined;
        this.#eventsMap?.clear();
        this.#eventsMap = undefined;
        this.#animations?.clear();
        this.#animations = undefined;
    }
}

enum MapEventCreate {
    Error = 'error',
    Ready = 'ready',
}

type TBuildMapOptions = atlas.ServiceOptions & atlas.StyleOptions & atlas.UserInteractionOptions & (atlas.CameraOptions | atlas.CameraBoundsOptions);

interface MapConfiguration {
    authOptions: atlas.AuthenticationOptions;
    mapOptions: MapOptions;
    jsLogLevel: LogLevel;
}

interface CreateMapArgs {
    dotNetRef: any;
    mapId: string;
    config: MapConfiguration;
    controls?: MapControl[];
    events?: MapEvent[];
}

type CreateMapStatus = "created" | "exists" | "failure";

interface CreateMapResult {
    mapId: string;
    status: CreateMapStatus;
    message?: string;
    error?: Error;
}

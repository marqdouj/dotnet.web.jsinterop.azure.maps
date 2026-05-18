import { Logger, LogLevel } from "../common/";
import { MapEvent } from "../Events";

export class EventsMap {
    #eventsMap: Map<string, object> = new Map<string, object>();
    mapId: string;

    constructor(mapId: string) { this.mapId = mapId; }

    addCallback(eventDef: MapEvent, callback: any) {
        const eventId = this.#getCallbackId(eventDef);
        if (!this.#eventsMap.has(eventId)) {
            this.#eventsMap.set(eventId, callback);
            //Logger.logMessage(this.mapId, LogLevel.Trace, "EventsMap.addCallback:", eventId);
        }
    }

    getCallback(eventDef: MapEvent, removing: boolean) {
        const eventId = this.#getCallbackId(eventDef);
        if (this.#eventsMap.has(eventId)) {
            const callback = this.#eventsMap.get(eventId);
            if (removing) {
                const wasRemoved = this.#eventsMap.delete(eventId);
                //Logger.logMessage(this.mapId, LogLevel.Trace, "EventsMap.removeCallback:", eventId, wasRemoved);
            }
            return callback;
        }
    }

    getCallbacksByTarget(targetId: string): CallbackInfo[] {
        const callbacks: CallbackInfo[] = [];
        for (const [key, value] of this.#eventsMap.entries()) {
            if (key.startsWith(`${targetId}.`)) {
                callbacks.push(new CallbackInfo(key, value));
            }
        }
        //Logger.logMessage(this.mapId, LogLevel.Trace, "EventsMap.getCallbacksByTarget:", targetId, callbacks.size);
        return callbacks;
    }

    removeCallbacksByTarget(targetId: string) {
        const callbacks = this.getCallbacksByTarget(targetId);
        for (const callbackInfo of callbacks) {
            this.#eventsMap.delete(callbackInfo.eventId);
        }
        //Logger.logMessage(this.mapId, LogLevel.Trace, "EventsMap.removeCallbacksByTarget:", targetId, callbacks.size);
    }

    #getCallbackId(eventDef: MapEvent) {
        return `${eventDef.targetId}.${eventDef.target}.${eventDef.type}`;
    }

    clear() {
        this.#eventsMap.clear();
    }
}

export class CallbackInfo {
    eventId: string;
    targetId: string;
    target: string;
    type: string;
    callback: any;
    constructor(eventId: string, callback: any) {
        this.eventId = eventId;
        const [targetId, target, type] = eventId.split(".");
        this.targetId = targetId;
        this.target = target;
        this.type = type;
        this.callback = callback;
    }
}
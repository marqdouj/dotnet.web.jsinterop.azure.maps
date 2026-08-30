import * as anims from "azure-maps-animations"
import { Helpers } from "../common/";
import { EventsLogger } from "./EventsLogger";
import { EventsHelper } from "./EventsHelper";
import { EventNotification, MapEvent } from "../Events";
import { MapReference } from "../Factory";

export class AnimationEvents {
    add(mapRef: MapReference, events?: MapEvent[]) {
        //EventsLogger.logMessage(mapRef.mapId, LogLevel.Trace, "AnimationEvents.add", events);

        events ??= [];
        if (events.length == 0) return;

        events.forEach((value) => { value.type = value.type.toLowerCase(); });

        this.#addAnimationEvents(mapRef, this.#getEventDefs(events));
    }

    #addAnimationEvents(mapRef: MapReference, events: MapEvent[]) {
        if (events.length == 0) return;
        const eventName = "addAnimationEvents";

        Object.values(events).filter(value => Helpers.isValueInEnum(MapAnimationEvent, value.type)).forEach((value) => {
            const animation = mapRef.getAnimation(value.targetId!);

            if (!animation) {
                EventsLogger.logInvalidTargetId(mapRef.mapId, eventName, value);
                return;
            }

            let wasAdded: boolean = false;
            let callback: any;

            switch (value.type as MapAnimationEvent) {
                case MapAnimationEvent.OnComplete:
                case MapAnimationEvent.OnProgress:
                    callback = this.#getCallbackPlayableAnimation(mapRef, value, false);
                    break;
                case MapAnimationEvent.OnFrame:
                    callback = this.#getCallbackFrameBasedAnimation(mapRef, value, false);
                    break;
                default:
            }

            if (callback) {
                if (value.once) {
                    mapRef.map.events.addOnce(value.type as any, animation, callback);
                }
                else {
                    mapRef.map.events.add(value.type as any, animation, callback);
                }
                wasAdded = true;
            }

            EventsLogger.logEventAdd(mapRef.mapId, eventName, wasAdded, value);
        });
    }

    #getEventDefs(events: MapEvent[]) {
        return Object.values(events).filter(value => value.target === "animation" && Helpers.isValueInEnum(MapAnimationEvent, value.type));
    }

    #getCallbackPlayableAnimation(mapRef: MapReference, event: MapEvent, removing: boolean) {
        let callback: any = mapRef.eventsMap.getCallback(event, removing);

        if (callback) {
            return callback;
        }

        callback = (e: anims.PlayableAnimationEvent) => this.#notifyNotifyMapEventPlayableAnimation(e, mapRef, event);

        mapRef.eventsMap.addCallback(event, callback);

        return callback;
    }

    #getCallbackFrameBasedAnimation(mapRef: MapReference, event: MapEvent, removing: boolean) {
        let callback: any = mapRef.eventsMap.getCallback(event, removing);

        if (callback) {
            return callback;
        }

        callback = (e: anims.FrameBasedAnimationEvent) => this.#notifyNotifyMapEventFrameEvent(e, mapRef, event);

        mapRef.eventsMap.addCallback(event, callback);

        return callback;
    }

    #notifyNotifyMapEventPlayableAnimation = (callback: anims.PlayableAnimationEvent, mapRef: MapReference, event: MapEvent) => {
        const result = EventsHelper.buildMapEventArgs(mapRef.mapId, event, { playableEvent: { ...callback } });
        mapRef.dotNetRef.invokeMethodAsync(EventNotification.NotifyMapEvent, result);
        //EventsLogger.logNotifyFired(mapRef.mapId, EventNotification.NotifyMapEvent, event.type);
    };

    #notifyNotifyMapEventFrameEvent = (callback: anims.FrameBasedAnimationEvent, mapRef: MapReference, event: MapEvent) => {
        const result = EventsHelper.buildMapEventArgs(mapRef.mapId, event, { frameEvent: { ...callback } });
        mapRef.dotNetRef.invokeMethodAsync(EventNotification.NotifyMapEvent, result);
        //EventsLogger.logNotifyFired(mapRef.mapId, EventNotification.NotifyMapEvent, event.type);
    };

    remove(mapRef: MapReference, events?: MapEvent[]) {
        events ??= [];
        if (events.length == 0) return;

        events.forEach((value) => { value.type = value.type.toLowerCase(); });

        this.#removeEvents(mapRef, this.#getEventDefs(events));
    }

    #removeEvents(mapRef: MapReference, events: MapEvent[]) {
        if (events.length == 0) return;

        const eventName = "AnimationEvents.removeEvent";

        Object.values(events).filter(value => Helpers.isValueInEnum(MapAnimationEvent, value.type)).forEach((value) => {
            const animation = mapRef.getAnimation(value.targetId!);

            if (!animation) {
                EventsLogger.logInvalidTargetId(mapRef.mapId, eventName, value);
                return;
            }

            let wasRemoved: boolean = false;
            let callback: any;

            switch (value.type as MapAnimationEvent) {
                case MapAnimationEvent.OnComplete:
                case MapAnimationEvent.OnProgress:
                    callback = this.#getCallbackPlayableAnimation(mapRef, value, false);
                    break;
                case MapAnimationEvent.OnFrame:
                    callback = this.#getCallbackFrameBasedAnimation(mapRef, value, false);
                    break;
                default:
            }

            if (callback) {
                mapRef.map.events.remove(value.type, animation, callback);
                wasRemoved = true;
            }
            EventsLogger.logEventRemoved(mapRef.mapId, eventName, wasRemoved, value);
        });
    }
}

enum MapAnimationEvent {
    OnComplete = 'oncomplete',
    OnFrame = 'onframe',
    OnProgress = 'onprogress',
}

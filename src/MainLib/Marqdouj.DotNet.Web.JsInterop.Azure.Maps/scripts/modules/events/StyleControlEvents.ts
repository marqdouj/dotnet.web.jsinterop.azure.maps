import atlas from "azure-maps-control";
import { EventsHelper } from "./EventsHelper";
import { EventsLogger } from "./EventsLogger"
import { Helpers, Logger, LogLevel } from "../common/";
import { EventNotification, MapEvent } from "../Events";
import { Controls } from "../Controls";
import { MapReference } from "../Factory";

export class StyleControlEvents {
    add(mapRef: MapReference, events: MapEvent[]) {
        if (events.length == 0) return;

        //Logger.logMapMessage(mapRef.mapId, LogLevel.Trace, "StyleControlEvents.add", events, this.#getEventDefs(events));

        this.#addEvents(mapRef, this.#getEventDefs(events));
    }

    remove(mapRef: MapReference, events: MapEvent[]) {
        if (events.length == 0) return;

        this.#removeEvents(mapRef, this.#getEventDefs(events));
    }

    #getEventDefs(events: MapEvent[]) {
        return Object.values(events).filter(value => value.target === "stylecontrol" && Helpers.isValueInEnum(StyleControlEvent, value.type));
    }

    #addEvents(mapRef: MapReference, events: MapEvent[]) {
        if (events.length == 0) return;

        //Logger.logMapMessage(mapRef.mapId, LogLevel.Trace, "StyleControlEvents.#addEvents", events);

        const eventName = "addStyleControlEvents";

        events.forEach((value) => {
            //Logger.logMapMessage(mapRef.mapId, LogLevel.Trace, "StyleControlEvents.#addEvents - Controls.getControl", value);
            const target = Controls.getControl(mapRef.mapId, value.targetId!);

            if (target instanceof atlas.control.StyleControl) {
                let wasAdded: boolean = false;
                const callback = this.#getCallback(mapRef, value, false);

                if (callback) {
                    if (value.once) {
                        mapRef.map.events.addOnce(value.type as StyleControlEvent, target, callback);
                    }
                    else {
                        mapRef.map.events.add(value.type as StyleControlEvent, target, callback);
                    }
                    wasAdded = true;
                }
                EventsLogger.logEventAdd(mapRef.mapId, eventName, wasAdded, value);
            }
            else {
                EventsLogger.logInvalidTargetId(mapRef.mapId, eventName, value);
            }
        });
    }

    #removeEvents(mapRef: MapReference, events: MapEvent[]) {
        if (events.length == 0) return;

        const eventName = "removeStyleControlEvents";

        events.forEach((value) => {
            const target = Controls.getControl(mapRef.mapId, value.targetId!);

            if (target instanceof atlas.control.StyleControl) {
                let wasRemoved: boolean = false;
                const callback = this.#getCallback(mapRef, value, true);

                if (callback) {
                    mapRef.map.events.remove(value.type, target, callback);
                    wasRemoved = true;
                }
                EventsLogger.logEventRemoved(mapRef.mapId, eventName, wasRemoved, value);
            }
            else {
                EventsLogger.logInvalidTargetId(mapRef.mapId, eventName, value);
            }
        });
    }

    #getCallback(mapRef: MapReference, value: MapEvent, removing: boolean) {
        let callback: any = mapRef.eventsMap.getCallback(value, removing);

        if (callback) {
            return callback;
        }

        callback = (style: string) => this.#notifyStyleControlEvent(style, mapRef, value);

        mapRef.eventsMap.addCallback(value, callback);
        return callback;
    }

    #notifyStyleControlEvent = (style: string, mapRef: MapReference, event: MapEvent) => {
        let result = EventsHelper.buildMapEventArgs(mapRef.mapId, event, { styleControl: { style: style } });
        mapRef.dotNetRef.invokeMethodAsync(EventNotification.NotifyMapEvent, result);
        EventsLogger.logNotifyFired(mapRef.mapId, EventNotification.NotifyMapEvent, event.type);
    };
}

enum StyleControlEvent {
    StyleSelected = 'styleselected',
}


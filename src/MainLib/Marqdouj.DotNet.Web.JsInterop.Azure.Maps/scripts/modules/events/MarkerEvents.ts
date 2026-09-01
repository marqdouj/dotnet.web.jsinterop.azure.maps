import atlas from "azure-maps-control";
import { Helpers } from "../common/";
import { EventsLogger } from "./EventsLogger";
import { EventsHelper } from "./EventsHelper";
import { EventNotification, MapEvent } from "../Events";
import { Markers } from "../Markers";
import { MapReference } from "../Factory";
import { Logger, LogLevel } from "../common/";

export class MarkerEvents {
    add(mapRef: MapReference, events: MapEvent[]) {
        if (events.length == 0) return;

        this.#addHtmlMarkerEvents(mapRef, this.#getEventDefs(events));
    }

    remove(mapRef: MapReference, events: MapEvent[]) {
        if (events.length == 0) return;

        this.#removeHtmlMarkerEvents(mapRef, this.#getEventDefs(events));
    }

    #getEventDefs(events: MapEvent[]) {
        return Object.values(events).filter(value => value.target === "htmlmarker" && Helpers.isValueInEnum(MapHtmlMarkerEvent, value.type));
    }

    #addHtmlMarkerEvents(mapRef: MapReference, events: MapEvent[]) {
        //Logger.logMessage(mapRef.mapId, LogLevel.Trace, `MarkerEvents:addHtmlMarkerEvents ${events.length} html marker events.`, events);

        if (events.length == 0) return;

        const eventName = "addHtmlMarkerEvents";

        events.forEach((value) => {
            const target = this.#getTarget(mapRef, value);
            let wasAdded: boolean = false;

            if (target) {
                const eventType = value.type as MapHtmlMarkerEvent;
                const callback = this.#getCallback(mapRef, value, false);

                if (callback) {
                    switch (eventType) {
                        case MapHtmlMarkerEvent.KeyDown:
                        case MapHtmlMarkerEvent.KeyPress:
                        case MapHtmlMarkerEvent.KeyUp:
                            //NOTE: I've added code to create the events as an example of what should normally work,
                            //      however, the map does not pass the keyboard events to html markers.
                            const element = target.getElement();
                            if (element) {
                                element.tabIndex = 0;
                                element.addEventListener(eventType, callback);
                                wasAdded = true;
                            }
                            break;
                        default:
                            if (value.once) {
                                mapRef.map.events.addOnce(eventType, target, callback);
                            }
                            else {
                                mapRef.map.events.add(eventType, target, callback);
                            }
                            wasAdded = true;

                            break;
                    }
                }

                EventsLogger.logEventAdd(mapRef.mapId, eventName, wasAdded, value);
            }
            else {
                EventsLogger.logInvalidTargetId(mapRef.mapId, eventName, value);
            }
        });
    }

    #removeHtmlMarkerEvents(mapRef: MapReference, events: MapEvent[]) {
        if (events.length == 0) return;

        const eventName = "removeHtmlMarkerEvents";

        events.forEach((value) => {
            const target = this.#getTarget(mapRef, value);
            let wasRemoved: boolean = false;

            if (target) {

                const callback = this.#getCallback(mapRef, value, true);

                if (callback) {
                    const eventType = value.type as MapHtmlMarkerEvent;

                    switch (eventType) {
                        case MapHtmlMarkerEvent.KeyDown:
                        case MapHtmlMarkerEvent.KeyPress:
                        case MapHtmlMarkerEvent.KeyUp:
                            const element = target.getElement();
                            if (element) {
                                element.removeEventListener(eventType, callback);
                            }
                            break;
                        default:
                            mapRef.map.events.remove(value.type as MapHtmlMarkerEvent, target, callback);
                    }
                    
                    wasRemoved = true;
                }

                EventsLogger.logEventRemoved(mapRef.mapId, eventName, wasRemoved, value);
            }
            else {
                EventsLogger.logInvalidTargetId(mapRef.mapId, eventName, value);
            }
        });
    }

    #getCallback(mapRef: MapReference, event: MapEvent, removing: boolean) {
        let callback: any = mapRef.eventsMap.getCallback(event, removing);

        if (callback) {
            //Logger.logMapMessage(mapRef.mapId, LogLevel.Trace, `MarkerEvents:#getCallback: found existing callback for event '${event.type}' (removing = ${removing}).`, event);
            return callback;
        }
        
        const eventType = event.type as MapHtmlMarkerEvent;

        switch (eventType) {
            case MapHtmlMarkerEvent.KeyDown:
            case MapHtmlMarkerEvent.KeyPress:
            case MapHtmlMarkerEvent.KeyUp:
                callback = (callback: KeyboardEvent) => this.#notifyMapHtmlMarkerKeyboardEvent(callback, mapRef, event);
                break;
            default:
                callback = (callback: atlas.TargetedEvent) => this.#notifyMapHtmlMarkerEvent(callback, mapRef, event);
        }

        //Logger.logMapMessage(mapRef.mapId, LogLevel.Trace, `MarkerEvents:#getCallback: adding callback for event '${event.type}' (removing = ${removing}).`, event);
        mapRef.eventsMap.addCallback(event, callback);
        return callback;
    }

    #getTarget(mapRef: MapReference, event: MapEvent) {
        return Markers.getMarker(mapRef.mapId, event.targetId);
    }

    #notifyMapHtmlMarkerEvent = (callback: atlas.TargetedEvent, mapRef: MapReference, event: MapEvent) => {
        let result = EventsHelper.buildMapEventArgs(mapRef.mapId, event, { htmlMarker: { type: callback.type } });
        mapRef.dotNetRef.invokeMethodAsync(EventNotification.NotifyMapEvent, result);
        //EventsLogger.logNotifyFired(mapRef.mapId, EventNotification.NotifyMapEvent, event.type);
    };

    #notifyMapHtmlMarkerKeyboardEvent = (callback: KeyboardEvent, mapRef: MapReference, event: MapEvent) => {
        if (event.preventDefault) {
            callback.preventDefault();
        }
        let result = EventsHelper.buildMapEventArgs(mapRef.mapId, event, { htmlMarker: { type: callback.type, ...EventsHelper.buildKeyboardEventPayload(callback) } });
        mapRef.dotNetRef.invokeMethodAsync(EventNotification.NotifyMapEvent, result);
        //EventsLogger.logNotifyFired(mapRef.mapId, EventNotification.NotifyMapEvent, event.type);
    };
}

enum MapHtmlMarkerEvent {
    Click = 'click',
    ContextMenu = 'contextmenu',
    DblClick = 'dblclick',
    MouseDown = 'mousedown',
    MouseEnter = 'mouseenter',
    MouseLeave = 'mouseleave',
    MouseMove = 'mousemove',
    MouseOut = 'mouseout',
    MouseOver = 'mouseover',
    MouseUp = 'mouseup',

    Drag = 'drag',
    DragEnd = 'dragend',
    DragStart = 'dragstart',

    KeyDown = 'keydown',
    KeyPress = 'keypress',
    KeyUp = 'keyup',
}
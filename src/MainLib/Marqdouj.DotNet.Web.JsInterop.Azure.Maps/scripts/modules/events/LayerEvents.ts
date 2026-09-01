import * as atlas from "azure-maps-control"
import { Helpers, LogLevel } from "../common/";
import { EventsLogger } from "./EventsLogger";
import { EventsHelper } from "./EventsHelper";
import { EventNotification, MapEvent } from "../Events";
import { MapReference } from "../Factory";

export class LayerEvents {
    add(mapRef: MapReference, events: MapEvent[]) {
        //EventsLogger.logMessage(mapRef.mapId, LogLevel.Trace, "LayerEvents.add", events);

        if (events.length == 0) return;

        events.forEach((value) => { value.type = value.type.toLowerCase(); });

        this.#addLayerEvents(mapRef, this.#getEventDefs(events));
    }

    addByLayer(mapRef: MapReference, layer: atlas.layer.Layer, events: MapEvent[]) {
        events.forEach((value) => { value.type = value.type.toLowerCase(); });

        const layerId = layer.getId();
        const mappedEvents = events.map(event => ({
            ...event,
            targetId: layerId
        }));
        this.#addLayerEvents(mapRef, this.#getEventDefs(mappedEvents), layer);
    }

    remove(mapRef: MapReference, events: MapEvent[]) {
        if (events.length == 0) return;

        events.forEach((value) => { value.type = value.type.toLowerCase(); });

        this.#removeLayerEvents(mapRef, this.#getEventDefs(events));
    }

    removeByLayer(mapRef: MapReference, layerId: string) {
        const callbacks = mapRef.eventsMap?.getCallbacksByTarget(layerId);
        //EventsLogger.logMessage(mapRef.mapId, LogLevel.Trace, "LayerEvents.removeByLayer", layerId, callbacks.length);

        callbacks?.forEach((callbackInfo) => {
            const target = this.#getTarget(mapRef.map, { targetId: layerId, target: "layer", type: callbackInfo.type });
            if (target) {
                mapRef.map.events.remove(callbackInfo.type, target, callbackInfo.callback);
                //EventsLogger.logMessage(mapRef.mapId, LogLevel.Trace, "LayerEvents.removeByLayer", callbackInfo.type, layerId);
            }
        });
    }

    #getEventDefs(events: MapEvent[]) {
        return Object.values(events).filter(value => value.target === "layer" && Helpers.isValueInEnum(MapLayerEvent, value.type));
    }

    #addLayerEvents(mapRef: MapReference, events: MapEvent[], layer?: atlas.layer.Layer) {
        EventsLogger.logMessage(mapRef.mapId, LogLevel.Trace, "LayerEvents.#addLayerEvents", events);

        if (events.length == 0) return;

        const eventName = "addLayerEvents";
        const azmap = mapRef.map;

        events.forEach((value) => {
            let wasAdded: boolean = false;
            const target = layer ?? this.#getTarget(azmap!, value);

            if (!target) {
                EventsLogger.logInvalidTargetId(mapRef.mapId, eventName, value);
                return;
            }

            const callback = this.#getCallback(mapRef, value, false);

            if (callback) {
                if (target) {
                    if (value.once) {
                        azmap.events.addOnce(value.type as any, target, callback as any);
                    }
                    else {
                        azmap.events.add(value.type as any, target, callback as any);
                    }
                    wasAdded = true;
                }
            }

            EventsLogger.logEventAdd(mapRef.mapId, eventName, wasAdded, value);
        });
    }

    #removeLayerEvents(mapRef: MapReference, events: MapEvent[]) {
        if (events.length == 0) return;

        const eventName = "removeLayerEvents";
        const azmap = mapRef.map;

        events.forEach((value) => {
            let wasRemoved: boolean = false;
            const target = this.#getTarget(azmap!, value);

            if (!target) {
                EventsLogger.logInvalidTargetId(mapRef.mapId, eventName, value);
                return;
            }

            const callback = this.#getCallback(mapRef, value, true);

            if (callback) {
                if (target) {
                    azmap?.events.remove(value.type, target, callback);
                    wasRemoved = true;
                }
                else {
                    EventsLogger.logInvalidTargetId(mapRef.mapId, eventName, value);
                }
            }

            EventsLogger.logEventRemoved(mapRef.mapId, eventName, wasRemoved, value);
        });
    }

    #getTarget(azmap: atlas.Map, event: MapEvent): atlas.layer.Layer | undefined {
        if (event.target === "layer") {
            return azmap.layers.getLayerById(event.targetId!);
        }
    }

    #getCallback(mapRef: MapReference, value: MapEvent, removing: boolean) {
        let callback: any = mapRef.eventsMap.getCallback(value, removing);

        if (callback) {
            return callback;
        }

        switch (value.type as MapLayerEvent) {
            case MapLayerEvent.LayerAdded:
            case MapLayerEvent.LayerRemoved:
                callback = (callback: atlas.layer.Layer) => this.#notifyMapEventLayer(callback, mapRef, value)
                break;
            case MapLayerEvent.Click:
            case MapLayerEvent.ContextMenu:
            case MapLayerEvent.DblClick:
            case MapLayerEvent.MouseDown:
            case MapLayerEvent.MouseEnter:
            case MapLayerEvent.MouseLeave:
            case MapLayerEvent.MouseMove:
            case MapLayerEvent.MouseOut:
            case MapLayerEvent.MouseOver:
            case MapLayerEvent.MouseUp:
                callback = (callback: atlas.MapMouseEvent) => this.#notifyMapEventLayerMouse(callback, mapRef, value);
                break;
            case MapLayerEvent.TouchCancel:
            case MapLayerEvent.TouchEnd:
            case MapLayerEvent.TouchMove:
            case MapLayerEvent.TouchStart:
                callback = callback = (callback: atlas.MapTouchEvent) => this.#NotifyMapEventLayerTouch(callback, mapRef, value);
                break;
            case MapLayerEvent.Wheel:
                callback = (callback: atlas.MapMouseWheelEvent) => this.#notifyMapEventLayerWheel(callback, mapRef, value);
                break;
            default:
        }

        mapRef.eventsMap.addCallback(value, callback);

        return callback;
    }

    #notifyMapEventLayer = (callback: atlas.layer.Layer, mapRef: MapReference, event: MapEvent) => {
        let result = EventsHelper.buildMapEventArgs(mapRef.mapId, event, EventsHelper.buildLayerEventPayload(callback), callback);
        mapRef.dotNetRef.invokeMethodAsync(EventNotification.NotifyMapEvent, result);
        //EventsLogger.logNotifyFired(mapRef.mapId, EventNotification.NotifyMapEvent, event.type);
    };

    #NotifyMapEventLayerTouch = (callback: atlas.MapTouchEvent, mapRef: MapReference, event: MapEvent,) => {
        if (event.preventDefault)
            callback.preventDefault();
        let result = EventsHelper.buildMapEventArgs(mapRef.mapId, event, EventsHelper.buildTouchEventPayload(callback));
        mapRef.dotNetRef.invokeMethodAsync(EventNotification.NotifyMapEvent, result);
        //EventsLogger.logNotifyFired(mapRef.mapId, EventNotification.NotifyMapEvent, event.type);
    };

    #notifyMapEventLayerMouse = (callback: atlas.MapMouseEvent, mapRef: MapReference, event: MapEvent) => {
        if (event.preventDefault)
            callback.preventDefault();
        let result = EventsHelper.buildMapEventArgs(mapRef.mapId, event, EventsHelper.buildMouseEventPayload(callback));
        mapRef.dotNetRef.invokeMethodAsync(EventNotification.NotifyMapEvent, result);
        //EventsLogger.logNotifyFired(mapRef.mapId, EventNotification.NotifyMapEvent, event.type);
    };

    #notifyMapEventLayerWheel = (callback: atlas.MapMouseWheelEvent, mapRef: MapReference,  event: MapEvent) => {
        if (event.preventDefault)
            callback.preventDefault();
        let result = EventsHelper.buildMapEventArgs(mapRef.mapId, event, EventsHelper.buildWheelEventPayload(callback));
        mapRef.dotNetRef.invokeMethodAsync(EventNotification.NotifyMapEvent, result);
        //EventsLogger.logNotifyFired(mapRef.mapId, EventNotification.NotifyMapEvent, event.type);
    };
}

enum MapLayerEvent {
    LayerAdded = 'layeradded',
    LayerRemoved = 'layerremoved',

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

    TouchCancel = 'touchcancel',
    TouchEnd = 'touchend',
    TouchMove = 'touchmove',
    TouchStart = 'touchstart',

    Wheel = 'wheel',
}

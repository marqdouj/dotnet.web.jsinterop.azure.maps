import { JSInterop, Logger, LogLevel } from "./common/"
import { Factory } from "./Factory";
import { LayerEvents } from "./events/LayerEvents";
import { MarkerEvents } from "./events/MarkerEvents";
import { MapEvents } from "./events/MapEvents";
import { PopupEvents } from "./events/PopupEvents";
import { SourceEvents } from "./events/SourceEvents";
import { StyleControlEvents } from "./events/StyleControlEvents";
import { ShapeEvents } from "./events/ShapeEvents";

export class Events {
    static readonly maps: MapEvents = new MapEvents();
    static readonly layers: LayerEvents = new LayerEvents()
    static readonly markers: MarkerEvents = new MarkerEvents();
    static readonly popups: PopupEvents = new PopupEvents();
    static readonly shapes: ShapeEvents = new ShapeEvents();
    static readonly sources: SourceEvents = new SourceEvents();
    static readonly styleControls: StyleControlEvents = new StyleControlEvents();


    static add(mapId: string, events: MapEvent[]) {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        events ??= [];

        events.forEach((value) => { value.type = value.type.toLowerCase(); });

        Events.maps.add(mapRef, events);
        Events.layers.add(mapRef, events);
        Events.markers.add(mapRef, events);
        Events.popups.add(mapRef, events);
        Events.shapes.add(mapRef, events);
        Events.sources.add(mapRef, events);
        Events.styleControls.add(mapRef, events);
    }

    public static remove(mapId: string, events: MapEvent[]): void {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        events.forEach((value) => { value.type = value.type.toLowerCase(); });

        Events.layers.remove(mapRef, events);
        Events.maps.remove(mapRef, events);
        Events.markers.remove(mapRef, events);
        Events.popups.remove(mapRef, events);
        Events.shapes.remove(mapRef, events);
        Events.sources.remove(mapRef, events);
        Events.styleControls.remove(mapRef, events);
    }
}

type EventTarget = 'map' | 'datasource' | 'htmlmarker' | 'layer' | 'shape' | 'stylecontrol' | 'popup';

export type MapEventArgs = {
    mapId: string;
    type: string;
    target: EventTarget;
    targetId?: string;
    payload?: {
        jsInterop: JSInterop;
        error?: any;
        mouse?: any;
    };
}

export interface MapEvent {
    type: string;
    once?: boolean;
    target: EventTarget;
    targetId?: string;
    targetSourceId?: string;
    preventDefault?: boolean;
}

export enum EventNotification {
    NotifyMapEventError = 'NotifyMapEventError',
    NotifyMapEventReady = 'NotifyMapEventReady',
    NotifyMapEvent = 'NotifyMapEvent',
    NotifyGeolocationWatch = 'NotifyGeolocationWatch',
}

export enum MapEventMouse {
    Click = 'click',
    ContextMenu = 'contextmenu',
    DblClick = 'dblclick',
    MouseDown = 'mousedown',
    MouseMove = 'mousemove',
    MouseOut = 'mouseout',
    MouseOver = 'mouseover',
    MouseUp = 'mouseup',
}

export enum MapEventTouch {
    TouchCancel = 'touchcancel',
    TouchEnd = 'touchend',
    TouchMove = 'touchmove',
    TouchStart = 'touchstart'
}

export enum MapEventWheel {
    Wheel = 'wheel',
}

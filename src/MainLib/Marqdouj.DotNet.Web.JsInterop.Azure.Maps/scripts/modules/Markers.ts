import atlas from "azure-maps-control";
import { Helpers, Logger, LogLevel } from "./common/";
import { Factory, MapReference } from "./Factory";
import { Events, MapEvent } from "./Events";

export class Markers {
    public static add(mapId: string, markers: HtmlMarkerDef[], events?: MapEvent[]): void {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        markers ??= [];

        markers.forEach(markerDef => {
            let options = { ...(markerDef as any).options };
            if (options.popup) {
                options.popup = new atlas.Popup(options.popup.options)
            }
            let marker = new atlas.HtmlMarker(options);
            (marker as any).id = markerDef.id;

            mapRef.map.markers.add(marker);

            if (events) {
                events = events.map(event => ({
                    ...event,
                    targetId: markerDef.id
                }));

                Events.add(mapId, events);
            }

            if (markerDef.togglePopupOnClick) {
                mapRef.map.events.add('click', marker, () => {
                    marker.togglePopup();
                });
            }
        });
    }

    public static addEvents(mapId: string, markers: HtmlMarkerDef[], events?: MapEvent[]): void {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        if (!markers || markers.length === 0) {
            Logger.logMapMessage(mapId, LogLevel.Warn, `Markers.addEvents: no markers provided.`);
            return;
        }

        if (!events || events.length === 0) {
            Logger.logMapMessage(mapId, LogLevel.Warn, `Markers.addEvents: no events provided.`);
            return;
        }

        //Logger.logMapMessage(mapId, LogLevel.Trace, `Markers.addEvents: adding events to markers`, markers);

        markers.forEach(markerDef => {
            const marker = this.#doGetMarker(mapRef, markerDef.id);

            if (!marker)
                return; // marker not found, skip

            const mappedEvents = events!.map(event => ({
                ...event,
                targetId: markerDef.id
            }));

            //Logger.logMapMessage(mapId, LogLevel.Trace, `Markers.addEvents: adding events to marker`, markerDef, events);
            Events.add(mapId, mappedEvents);

            if (markerDef.togglePopupOnClick) {
                mapRef.map.events.add('click', marker, () => {
                    marker.togglePopup();
                });
            }
        });
    }

    public static remove(mapId: string, markers: HtmlMarkerDef[]): void {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        markers.forEach(markerDef => {
            let marker = Markers.#doGetMarker(mapRef, markerDef.id);
            if (marker) {
                mapRef.map.markers.remove(marker);
            }
        });
    }

    public static removeEvents(mapId: string, markers: HtmlMarkerDef[], events?: MapEvent[]): void {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        if (!markers || markers.length === 0) {
            Logger.logMessage(mapId, LogLevel.Warn, `Markers.removeEvents: no markers provided for mapId = '${mapId}'`);
            return;
        }

        if (!events || events.length === 0) {
            Logger.logMessage(mapId, LogLevel.Warn, `Markers.removeEvents: no events provided for mapId = '${mapId}'`);
            return;
        }

        markers.forEach(markerDef => {
            const marker = this.#doGetMarker(mapRef, markerDef.id);

            if (!marker)
                return; // marker not found, skip

            const mappedEvents = events!.map(event => ({
                ...event,
                targetId: markerDef.id
            }));

            Events.remove(mapId, mappedEvents);

            if (markerDef.togglePopupOnClick) {
                mapRef.map.events.remove('click', marker, () => {
                    marker.togglePopup();
                });
            }
        });
    }

    static getMarker(mapId: string, id: string | undefined): atlas.HtmlMarker | undefined {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        return Markers.#doGetMarker(mapRef, id);
    }

    static #doGetMarker(mapRef: MapReference, id: string | undefined): atlas.HtmlMarker | undefined {
        if (!id)
            return;

        const markers = mapRef.map.markers.getMarkers();
        const marker = markers.findLast(value => Markers.#hasId(value, id));

        if (!marker) {
            Logger.logMessage(mapRef.mapId, LogLevel.Debug, `getMarker: marker not found where id = '${id}'`);
        }

        return marker;
    }

    static #hasId(obj: any, id: string): obj is atlas.HtmlMarker {
        return obj instanceof atlas.HtmlMarker && (obj as any).id === id;
    }
}

interface HtmlMarkerDef {
    options: atlas.HtmlMarkerOptions;
    togglePopupOnClick: boolean;
    id: string;
}

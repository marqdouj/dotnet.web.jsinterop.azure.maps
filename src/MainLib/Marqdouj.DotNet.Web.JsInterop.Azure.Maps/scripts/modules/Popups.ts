import atlas from "azure-maps-control";
import { Logger, LogLevel } from "./common/";
import { Factory, MapReference } from "./Factory";

export class Popups {
    public static add(mapId: string, popups: PopupDef[]): void {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        popups ??= [];

        popups.forEach(popupDef => {
            let popup = new atlas.Popup(popupDef.options);
            (popup as any).id = popupDef.id

            mapRef.map.popups.add(popup);

            if (popupDef.show)
                popup.open();
        });
    }

    public static remove(mapId: string, popups: PopupDef[]): void {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        popups.forEach(popupDef => {
            let popup = Popups.#doGetPopup(mapRef, popupDef.id);
            if (popup) {
                mapRef.map.popups.remove(popup);
            }
        });
    }

    static show(mapId: string, popups: PopupDef[]) {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        popups ??= [];

        popups.forEach(popupDef => {
            const popup = this.#doGetPopup(mapRef, popupDef.id);
            if (!popup)
                return;

            if (popupDef.show)
                popup.open();
            else
                popup.close();
        });
    }

    static getPopup(mapRef: MapReference, id: string | undefined): atlas.Popup | undefined {
        return Popups.#doGetPopup(mapRef, id);
    }

    static #doGetPopup(mapRef: MapReference, id: string | undefined): atlas.Popup | undefined {
        if (!id)
            return;

        const popups = mapRef.map.popups.getPopups();
        const popup = popups.findLast(value => Popups.#hasId(value, id));

        if (!popup) {
            Logger.logMessage(mapRef.mapId, LogLevel.Warn, `popup not found where id = '${id}'`);
        }

        return popup;
    }

    static #hasId(obj: any, id?: string): obj is atlas.Popup {
        return obj instanceof atlas.Popup && (obj as any).id === id;
    }
}

export interface PopupDef {
    id: string;
    options: atlas.PopupOptions;
    show?: boolean;
}

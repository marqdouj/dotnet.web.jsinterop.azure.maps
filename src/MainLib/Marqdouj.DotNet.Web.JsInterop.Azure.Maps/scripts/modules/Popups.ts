import atlas from "azure-maps-control";
import { Logger, LogLevel } from "./common/";
import { Factory, MapReference } from "./Factory";

export class Popups {
    public static add(mapId: string, popups: IPopupDef[]): void {
        const mapRef = Factory.getMapReference(mapId);
        if (!mapRef)
            return;

        popups ??= [];

        popups.forEach(popupDef => {
            let popup = new atlas.Popup(popupDef.options);
            (popup as any).id = popupDef.id

            mapRef.map.popups.add(popup);
        });
    }

    public static remove(mapId: string, popups: IPopupDef[]): void {
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

    static getPopup(mapRef: MapReference, id: string | undefined): atlas.Popup | undefined {
        return Popups.#doGetPopup(mapRef, id);
    }

    static #doGetPopup(mapRef: MapReference, id: string | undefined): atlas.Popup | undefined {
        if (!id)
            return;

        const popups = mapRef.map.popups.getPopups();
        const popup = popups.findLast(value => Popups.#hasId(value, id));

        if (!popup) {
            Logger.logMessage(mapRef.mapId, LogLevel.Debug, `getPopup: popup not found where id = '${id}'`);
        }

        return popup;
    }

    static #hasId(obj: any, id?: string): obj is atlas.Popup {
        return obj instanceof atlas.Popup && (obj as any).id === id;
    }
}

interface IPopupDef {
    id: string;
    options: atlas.PopupOptions;
}

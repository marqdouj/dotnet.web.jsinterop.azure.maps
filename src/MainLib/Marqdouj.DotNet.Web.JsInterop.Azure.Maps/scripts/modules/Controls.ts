import * as atlas from "azure-maps-control"
import { Helpers, Logger, LogLevel } from "./common/"
import { Factory } from "./Factory";

export class Controls {
    public static add(mapId: string, mapControls: MapControl[] | undefined): void {
        if (!mapControls) {
            //Logger.logMapMessage(mapId, LogLevel.Trace, "Controls.add was called with empty mapControls.");
            return;
        }

        const map = Factory.getMap(mapId);
        if (!map) return;

        const controls = map.controls.getControls();

        mapControls.forEach(mapControl => {
            //Logger.logMapMessage(mapId, LogLevel.Trace, "processing map control", mapControl);

            const id = mapControl.id;

            if (Helpers.isEmptyOrNull(id)) {
                Logger.logMapMessage(mapId, LogLevel.Error, "Controls.add was called with missing id.", mapControl);
                return; //skip to next iteration
            }

            if (this.#doGetControl(controls, mapId, id, false)) {
                Logger.logMapMessage(mapId, LogLevel.Warn, `map control [Type: ${mapControl.type}] already exists where id = '${id}'`);
                return;
            }

            const control = Helpers.switchCaseInsensitive<atlas.Control | undefined>(mapControl.type, {
                compass: () => new atlas.control.CompassControl(mapControl.options as any),
                fullscreen: () => new atlas.control.FullscreenControl(mapControl.options as any),
                pitch: () => new atlas.control.PitchControl(mapControl.options as any),
                scale: () => new atlas.control.ScaleControl(mapControl.options as any),
                style: () => new atlas.control.StyleControl(mapControl.options as any),
                traffic: () => new atlas.control.TrafficControl(mapControl.options as any),
                trafficlegend: () => new atlas.control.TrafficLegendControl(),
                zoom: () => new atlas.control.ZoomControl(mapControl.options as any),
            }, () => undefined);

            if (control) {
                (control as any).id = id;
                map.controls.add(control, mapControl.controlOptions);
                //Logger.logMapMessage(mapId, LogLevel.Trace, "Adding map control", mapControl, control);
            }
            else {
                Logger.logMapMessage(mapId, LogLevel.Warn, `Map control type '${mapControl.type}' is not supported.`);
            }
        });
    }

    public static remove(mapId: string, mapControls: MapControl[]): void {
        if (!mapControls) {
            //Logger.logMapMessage(mapId, LogLevel.Trace, "Controls.remove was called with empty mapControls.");
            return;
        }

        const map = Factory.getMap(mapId);
        if (!map) return;

        const controls = map.controls.getControls();
        mapControls.forEach(item => {
            let control = this.#doGetControl(controls, mapId, item.id);
            if (control) {
                map.controls.remove(control);
            }
        });
    }

    static getControl(mapId: string, id: string): atlas.Control | undefined {
        const map = Factory.getMap(mapId);
        if (!map) {
            return undefined;
        }

        const controls = map.controls.getControls();
        return this.#doGetControl(controls, mapId, id);
    }

    static #doGetControl(controls: atlas.Control[], mapId: string, id: string | undefined, log: boolean = true): atlas.Control | undefined {
        const control = controls.findLast(value => this.#hasId(value, id));

        if (log && !control) {
            Logger.logMapMessage(mapId, LogLevel.Debug, `map control not found where id = '${id}'`);
        }

        return control;
    }

    static #hasId(obj: any, id?: string): obj is atlas.Control {
        return obj && (obj as any).id === id;
    }
}

type MapControlType = "Compass" | "Fullscreen" | "Pitch" | "Scale" | "Style" | "Traffic" | "TrafficLegend" | "Zoom";

export interface MapControl {
    type: MapControlType;
    position: atlas.ControlPosition;
    controlOptions?: atlas.ControlOptions;
    options?: atlas.CompassControlOptions
    | atlas.FullscreenControlOptions
    | atlas.PitchControlOptions
    | atlas.ScaleControlOptions
    | atlas.StyleControlOptions
    | atlas.ZoomControlOptions;
    id?: string;
}

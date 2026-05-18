import * as atlas from "azure-maps-control";
import { Helpers, Logger, LogLevel } from "../common/";
import { MapEvent, MapEventArgs } from "../Events";

export class EventsHelper {
    static buildKeyboardEventPayload(callback: KeyboardEvent) {
        const payload = {
            key: callback.key,
            code: callback.code,
            location: callback.location,
            repeat: callback.repeat,
            altKey: callback.altKey,
            ctrlKey: callback.ctrlKey,
            shiftKey: callback.shiftKey,
            metaKey: callback.metaKey
        };

        return { keyboard: payload };
    }

    static buildMapEventArgs(mapId: string, event: MapEvent, payload?: any, source?: any): MapEventArgs {
        //Logger.logMapMessage(mapId, LogLevel.Trace, "EventsHelper.buildMapEventArgs", event, payload, source);

        const args: MapEventArgs =
        {
            mapId: mapId,
            type: event.type,
            target: event.target,
            targetId: event?.targetId,
            payload: { id: source?.id ,...payload }
        };

        return args;
    }

    static buildLayerEventPayload(layer: atlas.layer.Layer) {
        return { layer: { id: layer.getId() } };
    }

    static buildShapeResults(shapes: (atlas.data.Feature<atlas.data.Geometry, any> | atlas.Shape)[] | undefined): object[] {
        const results: object[] = [];

        if (!shapes)
            return results;

        shapes.filter(feature => Helpers.isFeature(feature)).forEach(feature => {
            results.push(Helpers.getFeatureResult(feature));
        });
        shapes.filter(shape => Helpers.isShape(shape)).forEach(shape => {
            results.push(Helpers.getShapeResult(shape));
        });

        return results;
    }

    static buildMouseEventPayload(mouseEvent: atlas.MapMouseEvent) {
        const shapes = mouseEvent.shapes;

        const mouse = {
            layerId: mouseEvent.layerId,
            pixel: mouseEvent.pixel,
            position: mouseEvent.position,
            shapes: this.buildShapeResults(mouseEvent.shapes)
        };

        return { mouse: mouse };
    }

    static buildTouchEventPayload(touchEvent: atlas.MapTouchEvent) {
        const payload = {
            pixel: touchEvent.pixel,
            pixels: touchEvent.pixels,
            position: touchEvent.position,
            positions: touchEvent.positions,
            layerId: touchEvent.layerId,
            shapes: this.buildShapeResults(touchEvent.shapes)
        };

        return { touch: payload };
    }

    static buildWheelEventPayload(wheelEvent: atlas.MapMouseWheelEvent) {
        const payload = {
            type: wheelEvent.type,
        };

        return { wheel: payload };
    }
}

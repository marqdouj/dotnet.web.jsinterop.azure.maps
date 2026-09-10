import * as atlas from "azure-maps-control"

export class BoundingBox {
    public static fromData(data: any) {
        const bbox = atlas.data.BoundingBox.fromData(data);
        return bbox;
    }
}

export function addControls(azmap) {
    azmap.controls.add([
        new atlas.control.FullscreenControl(),
        new atlas.control.ZoomControl(),
        new atlas.control.PitchControl(),
        new atlas.control.StyleControl(),
        new atlas.control.CompassControl(),
        new atlas.control.TrafficControl(),
        new atlas.control.TrafficLegendControl(),
        new atlas.control.ScaleControl(),
    ], {
        position: atlas.ControlPosition.TopRight,
    });

    const msg = `Controls were added via custom interop!`;
    console.debug(msg);
    alert(msg);
}

export function removeControls(azmap) {
    var controls = azmap.controls.getControls();
    azmap.controls.remove(controls);
    const msg = `Controls were removed via custom interop!`;
    console.debug(msg);
    alert(msg);
}

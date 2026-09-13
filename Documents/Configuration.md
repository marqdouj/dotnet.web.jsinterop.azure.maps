## Configuration

### [<- Go Back](../README.md)

### Sandbox.
- See the demo app for how to configure and use this library.

### [App.Razor](../src/MainLib/Sandbox/Components/App.razor)
- Add the Azure Maps SDK scripts to the `head`.
```html
    @* Azure Maps SDK *@
    <link rel="stylesheet" href="https://atlas.microsoft.com/sdk/javascript/mapcontrol/3/atlas.min.css" type="text/css">
    <script src="https://atlas.microsoft.com/sdk/javascript/mapcontrol/3/atlas.min.js"></script>
```
- Add the Azure Maps SDK optional scripts to the `head` (if required, i.e. spatial, animations, etc.).
```html
    <!-- Add reference to the Azure Maps Spatial IO module. -->
    <script src="https://atlas.microsoft.com/sdk/javascript/spatial/0.1/atlas-spatial.min.js"></script>

    @* Azure Maps SDK Optional Downloadable Scripts you added to wwwroot *@
    @* https://github.com/Azure-Samples/AzureMapsCodeSamples/tree/main/Static/lib/azure-maps *@
    <script src="/lib/azuremaps/azure-maps-animations.min.js"></script>
```

### [MapSetup.cs](../src/MainLib/Sandbox/MapsSetup.cs)
`MapSetup.cs` contains examples of all the supported authentication methods.

### [Program.cs](../src/MainLib/Sandbox/Program.cs)
This is where you configure the authentication and global map settings.
```csharp
builder.Services.ConfigureMarqdoujAzureMaps(builder.Configuration, builder.Environment.IsDevelopment());
```

### Documentation
- [Azure Maps Documentation](https://docs.microsoft.com/en-us/azure/azure-maps/)

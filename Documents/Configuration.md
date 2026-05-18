## Configuration

### [<- Go Back](../README.md)

### [App.Razor](../src/MainLib/Sandbox/Components/App.razor)
- Add the Azure Maps SDK scripts to the `head`.
- Add the Azure Maps SDK optional scripts to the `head` (i.e. animations).
- After the `"_framework/blazor.web.js"` script:
  - If required, add the anonymous authentication script.
  - If required, add the SasToken authentication script.
	- NOTE: you can provide a SasTokenUrl in the map options instead.

### [MapSetup.cs](../src/MainLib/Sandbox/MapsSetup.cs)
`MapSetup.cs` contains examples of all the supported authentication methods.

### [Program.cs](../src/MainLib/Sandbox/Program.cs)
This is where you configure the authentication and global map settings.
```csharp
builder.Services.ConfigureMarqdoujAzureMaps(builder.Configuration, builder.Environment.IsDevelopment());
```

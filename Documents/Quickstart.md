## Quickstart

### [<- Go Back](../README.md)

- Once the Azure Maps SDK has been [configured](Configuration.md):
  - Add a `MapProvider` component to the page and configure it's events 
  (See the [Basic Map](../src/MainLib/Sandbox/Components/Pages/AzureMaps/Basic/BasicMap.razor) page as an example).
```html
<MapProvider OnMapProviderInitialized="@OnMapProviderInitialized"
             OnMapEventError="@OnMapEventError"
             OnMapEventReady="@OnMapEventReady" />
```

```csharp
    private IAzureMapsInterop? maps;
    private bool mapReady;

    private async Task OnMapProviderInitialized(MapProviderArgs args)
    {
            maps = args.MapsInterop;
            if (maps != null)
                var result = await maps.CreateMap(mapId);
    }

    private async Task OnMapEventError(MapEventArgs args)
    {
        //TODO: handle event
    }

    private async Task OnMapEventReady(MapEventArgs args)
    {
        await Task.CompletedTask;
        mapReady = args.Payload?.Error != null;
    }
```

using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers;
using Marqdouj.DotNet.Web.JsInterop.GeoJson;
using Sandbox.Services;

namespace Sandbox.Components.Pages.AzureMaps.Common
{
    internal static class LayerExtensions
    {
        public static async Task<MapLayerViewModels> GetViewModels(this IMapDataService dataService)
        {
            return new MapLayerViewModels()
            {
                Bubble = new((BubbleLayer)await GetDefaultLayer(LayerType.Bubble, dataService)),
                HeatMap = new((HeatMapLayer)await GetDefaultLayer(LayerType.HeatMap, dataService)),
                Image = new((ImageLayer)await GetDefaultLayer(LayerType.Image, dataService)),
                Line = new((LineLayer)await GetDefaultLayer(LayerType.Line, dataService)),
                Polygon = new((PolygonLayer)await GetDefaultLayer(LayerType.Polygon, dataService)),
                PolygonExtrusion = new((PolygonExtrusionLayer)await GetDefaultLayer(LayerType.PolygonExtrusion, dataService)),
                Symbol = new((SymbolLayer)await GetDefaultLayer(LayerType.Symbol, dataService)),
                Tile = new((TileLayer)await GetDefaultLayer(LayerType.Tile, dataService)),
            };
        }

        public static ILayer GetDefaultLayer(this LayerType layerType)
        {
            return layerType switch
            {
                LayerType.Bubble => new BubbleLayer(),
                LayerType.Line => new LineLayer()
                {
                    Before = "labels",
                    Options = new()
                    {
                        StrokeColor = "Blue",
                        StrokeWidth = 4,
                    }
                },
                LayerType.Polygon => new PolygonLayer()
                {
                    Options = new()
                    {
                        FillColor = "Red",
                        FillOpacity = 0.7,
                    }
                },
                LayerType.PolygonExtrusion => new PolygonExtrusionLayer()
                {
                    Options = new()
                    {
                        FillColor = "Red",
                        FillOpacity = 0.7,
                        Height = 500,
                    }
                },
                LayerType.Symbol => new SymbolLayer() { Options = new() { IconOptions = new() { Image = SymbolIconImage.Pin_Red } } },
                _ => throw new ArgumentOutOfRangeException(nameof(layerType)),
            };
        }

        public static async Task<ILayer> GetDefaultLayer(this LayerType layerType, IMapDataService dataService)
        {
            return layerType switch
            {
                LayerType.HeatMap => await GetDefaultHeatLayer(dataService),
                LayerType.Image => await GetDefaultImageLayerDef(dataService),
                LayerType.Tile => new TileLayer()
                {
                    Options = new()
                    {
                        Opacity = 0.8,
                        TileSize = 256,
                        MinSourceZoom = 7,
                        MaxSourceZoom = 17,
                        TileUrl = await dataService.GetTileLayerUrl(),
                    },
                },
                _ => layerType.GetDefaultLayer(),
            };
        }

        private static async Task<HeatMapLayer> GetDefaultHeatLayer(IMapDataService dataService)
        {
            var layerDef = new HeatMapLayer();
            layerDef.DataSource.Url = await dataService.GetHeatMapLayerUrl();
            return layerDef;
        }

        private static async Task<ImageLayer> GetDefaultImageLayerDef(IMapDataService dataService)
        {
            var layerDef = new ImageLayer();

            var data = await dataService.GetImageLayerData();
            layerDef.Options = new ImageLayerOptions
            {
                Url = data.Url,
                Coordinates = data.Coordinates
            };

            return layerDef;
        }

        public static async Task AddBasicMapLayer(this IAzureMapsInterop mapsInterop, string mapId, IMapDataService dataService, IMapLayerViewModel vm)
        {
            switch (vm.Source.Type)
            {
                case LayerType.Bubble:
                    await AddBubbleLayer(mapId, mapsInterop, dataService, vm);
                    break;
                case LayerType.HeatMap:
                    await AddHeatMapLayer(mapId, mapsInterop, vm);
                    break;
                case LayerType.Image:
                    await AddImageLayer(mapId, mapsInterop, vm);
                    break;
                case LayerType.Line:
                    await AddLineLayer(mapId, mapsInterop, dataService, vm);
                    break;
                case LayerType.Polygon:
                    await AddPolygonLayer(mapId, mapsInterop, dataService, vm);
                    break;
                case LayerType.PolygonExtrusion:
                    await AddPolygonExtLayer(mapId, mapsInterop, dataService, vm);
                    break;
                case LayerType.Symbol:
                    await AddSymbolLayer(mapId, mapsInterop, dataService, vm);
                    break;
                case LayerType.Tile:
                    await AddTileLayer(mapId, mapsInterop, vm);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(vm));
            }
        }

        private static async Task AddBubbleLayer(string mapId, IAzureMapsInterop mapsInterop, IMapDataService dataService, IMapLayerViewModel vm)
        {
            if (vm.Source is not BubbleLayer)
                throw new ArgumentException($"Expected {nameof(vm.Source)} to be of type {nameof(BubbleLayer)}", nameof(vm));

            if (vm.IsLoaded)
                return;

            await mapsInterop.Layers.AddGroup(mapId, vm.ToLayerGroup());
            vm.IsLoaded = true;

            var data = await dataService.GetBubbleLayerData();
            MapFeature featureDef = new(new MultiPoint(data))
            {
                Properties = new Properties
                    {
                        { "title", "my bubble layer" },
                        { "demo", true },
                    }
            };

            var layer = (BubbleLayer)vm.Source;
            await mapsInterop.Features.Add(mapId, featureDef, layer.DataSource.Id!);

            vm.Camera ??= new CameraOptions
            {
                Center = data[0],
                Zoom = 11,
                Pitch = 0,
            };

            await mapsInterop.ZoomToLayer(mapId, vm);
        }

        private static async Task AddHeatMapLayer(string mapId, IAzureMapsInterop mapsInterop, IMapLayerViewModel vm)
        {
            if (vm.Source is not HeatMapLayer)
                throw new ArgumentException($"Expected {nameof(vm.Source)} to be of type {nameof(HeatMapLayer)}", nameof(vm));

            if (vm.IsLoaded)
                return;

            await mapsInterop.Layers.AddGroup(mapId, vm.ToLayerGroup());
            vm.IsLoaded = true;

            vm.Camera ??= new CameraOptions
            {
                Center = new Position(-122.33, 47.6),
                Zoom = 1,
                Pitch = 0,
            };

            await mapsInterop.ZoomToLayer(mapId, vm);
        }

        private static async Task AddImageLayer(string mapId, IAzureMapsInterop mapsInterop, IMapLayerViewModel vm)
        {
            if (vm.Source is not ImageLayer)
                throw new ArgumentException($"Expected {nameof(vm.Source)} to be of type {nameof(ImageLayer)}", nameof(vm));

            if (vm.IsLoaded)
                return;

            await mapsInterop.Layers.AddGroup(mapId, vm.ToLayerGroup());
            vm.IsLoaded = true;

            vm.Camera ??= new CameraOptions
            {
                Center = new Position(-74.172363, 40.735657),
                Zoom = 11,
                Pitch = 0,
            };

            await mapsInterop.ZoomToLayer(mapId, vm);
        }

        private static async Task AddLineLayer(string mapId, IAzureMapsInterop mapsInterop, IMapDataService dataService, IMapLayerViewModel vm)
        {
            if (vm.Source is not LineLayer)
                throw new ArgumentException($"Expected {nameof(vm.Source)} to be of type {nameof(LineLayer)}", nameof(vm));

            if (vm.IsLoaded)
                return;

            await mapsInterop.Layers.AddGroup(mapId, vm.ToLayerGroup());

            var data = await dataService.GetLineLayerData();
            var feature = data.GetLineLayerFeatureDef();
            var layer = (LineLayer)vm.Source;

            await mapsInterop.Features.Add(mapId, feature, layer.DataSource.Id!);
            vm.IsLoaded = true;

            vm.Camera ??= new CameraOptions
            {
                Center = data[8],
                Zoom = 11,
                Pitch = 0,
            };

            await mapsInterop.ZoomToLayer(mapId, vm);
        }

        public static MapFeature<LineString> GetLineLayerFeatureDef(this List<Position> data)
        {
            return new MapFeature<LineString>(new LineString(data))
            {
                Properties = new Properties
                {
                    { "title", "my line" },
                    { "demo", true },
                }
            };
        }

        private static async Task AddPolygonLayer(string mapId, IAzureMapsInterop mapsInterop, IMapDataService dataService, IMapLayerViewModel vm)
        {
            if (vm.Source is not PolygonLayer)
                throw new ArgumentException($"Expected {nameof(vm.Source)} to be of type {nameof(PolygonLayer)}", nameof(vm));

            if (vm.IsLoaded)
                return;

            await mapsInterop.Layers.AddGroup(mapId, vm.ToLayerGroup());
            vm.IsLoaded = true;

            var data = await dataService.GetPolygonLayerData();
            var feature = new MapFeature(new Polygon(data))
            {
                Properties = new Properties
                {
                    { "title", "my Polygon layer" },
                    { "demo", true },
                },
                AsShape = true
            };

            var layer = (PolygonLayer)vm.Source;
            await mapsInterop.Features.Add(mapId, feature, layer.DataSource.Id!);

            vm.Camera ??= new CameraOptions
            {
                Center = data[0][0],
                Zoom = 11,
                Pitch = 0,
            };

            await mapsInterop.ZoomToLayer(mapId, vm);
        }

        private static async Task AddPolygonExtLayer(string mapId, IAzureMapsInterop mapsInterop, IMapDataService dataService, IMapLayerViewModel vm)
        {
            if (vm.Source is not PolygonExtrusionLayer)
                throw new ArgumentException($"Expected {nameof(vm.Source)} to be of type {nameof(PolygonExtrusionLayer)}", nameof(vm));

            if (vm.IsLoaded)
                return;

            await mapsInterop.Layers.AddGroup(mapId, vm.ToLayerGroup());
            vm.IsLoaded = true;

            var data = await dataService.GetPolygonExtLayerData();
            var feature = new MapFeature(new Polygon(data))
            {
                Properties = new Properties
                {
                    { "title", "my PolygonExt layer" },
                    { "demo", true },
                },
                AsShape = true
            };

            var layer = (PolygonExtrusionLayer)vm.Source;
            await mapsInterop.Features.Add(mapId, feature, layer.DataSource.Id!);

            vm.Camera ??= new CameraOptions
            {
                Center = data[0][0],
                Zoom = 11,
                Pitch = 60,
            };

            await mapsInterop.ZoomToLayer(mapId, vm);
        }

        private static async Task AddSymbolLayer(string mapId, IAzureMapsInterop mapsInterop, IMapDataService dataService, IMapLayerViewModel vm)
        {
            if (vm.Source is not SymbolLayer)
                throw new ArgumentException($"Expected {nameof(vm.Source)} to be of type {nameof(SymbolLayer)}", nameof(vm));

            if (vm.IsLoaded)
                return;

            await mapsInterop.Layers.AddGroup(mapId, vm.ToLayerGroup());
            vm.IsLoaded = true;

            var data = await dataService.GetSymbolLayerData();

            foreach (var position in data)
            {
                var feature = new MapFeature(new Point(position))
                {
                    Properties = new Properties
                    {
                        { "title", "my symbol" },
                        { "description", "my symbol description" },
                        { "demo", true },
                    }
                };

                var layer = (SymbolLayer)vm.Source;
                await mapsInterop.Features.Add(mapId, feature, layer.DataSource.Id!);
            }

            vm.Camera ??= new CameraOptions
            {
                Center = data[8],
                Zoom = 11,
                Pitch = 0,
            };

            await mapsInterop.ZoomToLayer(mapId, vm);
        }

        public static List<MapFeature> GetDefaultSymbolLayerFeatures(this List<Position> data)
        {
            var results = new List<MapFeature<Point>>();
            var counter = 0;

            foreach (var position in data)
            {
                counter++;

                var feature = new MapFeature<Point>(new Point(position))
                {
                    Properties = new Properties
                    {
                        { "title", $"my symbol #{counter}" },
                        { "description", $"my symbol #{counter} description" },
                        { "demo", true },
                    },
                    Id = $"demoSymbol-{counter}"
                };

                results.Add(feature);
            }

            return [.. results.Cast<MapFeature>()];
        }

        private static async Task AddTileLayer(string mapId, IAzureMapsInterop mapsInterop, IMapLayerViewModel vm)
        {
            if (vm.Source is not TileLayer)
                throw new ArgumentException($"Expected {nameof(vm.Source)} to be of type {nameof(TileLayer)}", nameof(vm));

            if (vm.IsLoaded)
                return;

            await mapsInterop.Layers.AddGroup(mapId, vm.ToLayerGroup());
            vm.IsLoaded = true;

            vm.Camera ??= new CameraOptions
            {
                Center = new Position(-122.426181, 47.608070),
                Zoom = 10.75,
                Pitch = 0,
            };

            await mapsInterop.ZoomToLayer(mapId, vm);
        }

        public static async Task ZoomToLayer(this IAzureMapsInterop mapsInterop, string mapId, IMapLayerViewModel vm)
        {
            if (vm.Camera is null || !vm.IsLoaded || !vm.IsVisible)
                return;
            await mapsInterop.Configuration.SetMapOptions(mapId, new MapOptionsEdit { Camera = vm.Camera });
        }

        public static async Task ShowLayer(this IAzureMapsInterop mapsInterop, string mapId, IMapLayerViewModel vm, bool isVisible, bool zoomToIfVisible = true)
        {
            if (!vm.IsLoaded)
                return;

            await mapsInterop.Layers.ShowLayer(mapId, vm.Source, isVisible);
            vm.IsVisible = isVisible;

            if (isVisible && zoomToIfVisible)
                await mapsInterop.ZoomToLayer(mapId, vm);
        }
    }
}


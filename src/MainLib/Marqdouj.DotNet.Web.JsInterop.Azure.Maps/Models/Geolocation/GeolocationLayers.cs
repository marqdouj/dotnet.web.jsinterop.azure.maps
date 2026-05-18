using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers;
using Marqdouj.DotNet.Web.JsInterop.GeoJson;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Geolocation
{
    /// <summary>
    /// Manages the layers required to display the Geolocation on a map.
    /// </summary>
    public class GeolocationLayers
    {
        private readonly SymbolLayer positionLayer;
        private readonly PolygonLayer accuracyLayer;
        private readonly DataSource dataSourceDef = new();
        private readonly LayerGroup positionGroup;
        private readonly LayerGroup accuracyGroup;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="positionEvents"></param>
        /// <param name="accuracyEvents"></param>
        public GeolocationLayers(string mapId, IEnumerable<MapEvent>? positionEvents = null, IEnumerable<MapEvent>? accuracyEvents = null)
        {
            MapId = mapId;
            positionLayer = new SymbolLayer() { DataSource = dataSourceDef };
            accuracyLayer = new PolygonLayer() { DataSource = dataSourceDef };

            //Render point or MultiPoints in this layer.
            positionLayer.Options ??= new();
            positionLayer.Options.Filter = new List<object>
                {
                    "any",
                    new List<object> { "==", new List<string> { "geometry-type" }, "Point" },
                    new List<object> { "==", new List<string> { "geometry-type" }, "MultiPoint" }
                };

            accuracyLayer.Options ??= new();
            accuracyLayer.Options.FillColor = "rgba(0, 153, 255, 0.5)";

            positionGroup = new LayerGroup(positionLayer, positionEvents);
            accuracyGroup = new LayerGroup(accuracyLayer, accuracyEvents);
        }

        /// <summary>
        /// Options for the Accuracy layer. Any changes must bed made before adding the layers to the map.
        /// </summary>
        public PolygonLayerOptions AccuracyOptions => accuracyLayer.Options!;

        /// <summary>
        /// Options for the Position layer. Any changes must bed made before adding the layers to the map.
        /// </summary>
        public SymbolLayerOptions PositionOptions => positionLayer.Options!;

        /// <summary>
        /// Indicates if the layers have been added to the map.
        /// </summary>
        public bool LayersAdded { get; private set; }

        /// <summary>
        /// Id for the map container.
        /// </summary>
        public string MapId { get; }

        /// <summary>
        /// Adds the layers to the map.
        /// </summary>
        /// <param name="mapInterop"></param>
        public async Task AddLayers(IAzureMapsInterop mapInterop)
        {
            if (LayersAdded) return;
            await mapInterop.Layers.AddGroup(MapId, positionGroup);
            await mapInterop.Layers.AddGroup(MapId, accuracyGroup);
            LayersAdded = true;
        }

        /// <summary>
        /// Removes the layers from the map.
        /// </summary>
        /// <param name="mapInterop"></param>
        public async Task RemoveLayers(IAzureMapsInterop mapInterop)
        {
            if (!LayersAdded) return;
            await mapInterop.Layers.Remove(MapId, positionGroup.Layer, false);
            await mapInterop.Layers.Remove(MapId, accuracyGroup.Layer);
            LayersAdded = false;
        }

        /// <summary>
        /// Adds a map feature representing the specified geographic position to the map and optionally includes
        /// an accuracy indicator for the position.
        /// </summary>
        /// <remarks>If showAccuracy is set to true and a position includes accuracy information, an
        /// additional feature representing the accuracy (such as a circle) is added for that position. The returned
        /// list includes both the position features and any associated accuracy features.</remarks>
        /// <param name="mapInterop">An object that provides interop functionality for interacting with Azure Maps.</param>
        /// <param name="position">A geographic position to add as feature on the map.</param>
        /// <param name="showAccuracy">true to add accuracy indicators (such as circles) for positions that include accuracy information;
        /// otherwise, false. The default is true.</param>
        /// <returns>A MapFeatureDef object representing the added position and, if applicable, it's accuracy
        /// indicator.</returns>
        public async Task<MapFeature> AddPosition(IAzureMapsInterop mapInterop, GeolocationPosition position, bool showAccuracy = true)
            => (await AddPositions(mapInterop, [position], showAccuracy)).First();

        /// <summary>
        /// Adds map features representing the specified geographic positions to the map and optionally includes
        /// accuracy indicators for each position.
        /// </summary>
        /// <remarks>If showAccuracy is set to true and a position includes accuracy information, an
        /// additional feature representing the accuracy (such as a circle) is added for that position. The returned
        /// list includes both the position features and any associated accuracy features.</remarks>
        /// <param name="mapInterop">An object that provides interop functionality for interacting with Azure Maps.</param>
        /// <param name="positions">A collection of geographic positions to add as features on the map.</param>
        /// <param name="showAccuracy">true to add accuracy indicators (such as circles) for positions that include accuracy information;
        /// otherwise, false. The default is true.</param>
        /// <returns>A list of MapFeatureDef objects representing the added positions and, if applicable, their accuracy
        /// indicators.</returns>
        public async Task<List<MapFeature>> AddPositions(IAzureMapsInterop mapInterop, IEnumerable<GeolocationPosition> positions, bool showAccuracy = true)
        {
            var features = new List<MapFeature>();

            foreach (var position in positions)
            {
                var point = new Point(new Position(position.Coords!.Longitude, position.Coords!.Latitude));
                var pointDef = new MapFeature(point) { AsShape = true };
                pointDef.Properties ??= [];
                pointDef.Properties.Add("geolocationType", "position");

                features.Add(pointDef);

                if (showAccuracy)
                {
                    var accuracyDef = new MapFeature(point);
                    accuracyDef.Properties ??= [];
                    accuracyDef.Properties.Add("geolocationType", "accuracy");
                    accuracyDef.Properties.Add("subType", "Circle");
                    accuracyDef.Properties.Add("radius", position.Coords.Accuracy);
                    features.Add(accuracyDef);
                }
            }

            await mapInterop.Features.Add(MapId, features, dataSourceDef.Id, true);

            return features;
        }

        /// <summary>
        /// Clears the datasource for the Geolocation layers.
        /// </summary>
        /// <param name="mapInterop"></param>
        /// <returns></returns>
        public async Task Clear(IAzureMapsInterop mapInterop)
        {
            if (LayersAdded)
                await mapInterop.Sources.Clear(MapId, dataSourceDef);
        }
    }
}

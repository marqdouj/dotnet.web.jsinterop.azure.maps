using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Spatial;
using Marqdouj.DotNet.Web.JsInterop.GeoJson;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Modules
{
    /// <summary>
    /// Action to perform with the read results on the datasource.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<SpatialReadAction>))]
    public enum SpatialReadAction
    {
        /// <summary>
        /// datasource.Add
        /// </summary>
        Add,

        /// <summary>
        /// datasource.setShapes
        /// </summary>
        SetShapes,
    }

    /// <summary>
    /// Interface for Azure Maps spatial source interactions.
    /// </summary>
    public interface IAzureMapsSpatialSources
    {
        /// <summary>
        /// Read an XML file from a URL or pass in a raw XML string.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="parameters"></param>
        /// <returns><see cref="BoundingBox"/> if one was available for the data.</returns>
        ValueTask<SpatialReadResults?> Read(string mapId, SpatialReadParameters parameters);
    }

    internal class AzSpatialSources(Lazy<Task<IJSObjectReference>> moduleTask) : IAzureMapsSpatialSources
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask = moduleTask;

        public async ValueTask<SpatialReadResults?> Read(string mapId, SpatialReadParameters parameters)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<SpatialReadResults?>(GetJsInteropMethod(), mapId, parameters);
        }

        private static string GetJsInteropMethod([CallerMemberName] string name = "")
            => JsModule.SpatialSources.GetJsModuleMethod(name);
    }

    /// <summary>
    /// Parameters for Spatial.Read method.
    /// </summary>
    /// <param name="dataSourceId"></param>
    /// <param name="url"><see cref="Url"/></param>
    /// <param name="action"><see cref="Action"/></param>
    /// <param name="options"><see cref="Options"/></param>
    /// <param name="padding"><see cref="Padding"/></param>
    public class SpatialReadParameters(string dataSourceId, string url, SpatialReadAction action, SpatialDataReadOptions? options = null, double padding = 50)
    {
        /// <summary>
        /// DataSource to assign the read data to.
        /// </summary>
        public string DataSourceId { get; } = dataSourceId;

        /// <summary>
        /// A spatial data string or a URL to a file or zipped file and parses the spatial data into GeoJSON objects.
        /// Supported spatial data formats: KML, KMZ, GPX, GeoRSS, GML, spatial delimited files (CSV), GeoJSON.
        /// </summary>
        public string Url { get; } = url;

        /// <summary>
        /// <inheritdoc cref="SpatialReadAction"/>
        /// </summary>
        public SpatialReadAction Action { get; } = action;

        /// <summary>
        /// <inheritdoc cref="SpatialDataReadOptions"/>
        /// </summary>
        public SpatialDataReadOptions? Options { get; } = options;

        /// <summary>
        /// If the bounding box information is known for the data, the map view will be updated to fit it, with the padding.
        /// </summary>
        public double Padding { get; } = padding;

        /// <summary>
        /// <see cref="IAzureMapsAnimations.ExtractRoutePoints(string, string, int, string?)"/> length.
        /// </summary>
        public int RouteLength { get; set; }

        /// <summary>
        /// <see cref="IAzureMapsAnimations.ExtractRoutePoints(string, string, int, string?)"/> timestampProperty.
        /// </summary>
        public string? RouteTimestamp { get; set; }
    }

    /// <summary>
    /// Results from a Spatial read operation.
    /// </summary>
    public class SpatialReadResults
    {
        /// <summary>
        /// <inheritdoc cref="BoundingBox"/>
        /// </summary>
        [JsonInclude]
        public BoundingBox? Bbox { get; internal set; }

        /// <summary>
        /// Point features for the time based route.
        /// </summary>
        [JsonInclude]
        public List<Feature<Point, GeoJsonProperties?>>? Route { get; internal set; }

        /// <summary>
        /// Flag to indicate the read was a success.
        /// </summary>
        [JsonInclude]
        public bool Success { get; internal set; }
    }
}

using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;
using Marqdouj.DotNet.Web.JsInterop.GeoJson;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events
{
    /// <summary>
    /// Payload for mouse events on the map, including information about the layer, pixel coordinates, geographical position, and shapes involved in the event.
    /// </summary>
    public class MapEventMousePayload
    {
        /// <summary>
        /// The id of the layer the event is attached to.
        /// </summary>
        [JsonInclude] public string? LayerId { get; internal set; }

        /// <summary>
        /// The pixel coordinate where the event occurred [x, y].
        /// </summary>
        [JsonInclude] public Pixel? Pixel { get; internal set; }

        /// <summary>
        /// The geographical location of all touch points on the map.
        /// </summary>
        [JsonInclude] public Position? Position { get; internal set; }

        /// <summary>
        /// An array of shape and Feature objects that the mouse event occurred on.
        /// </summary>
        [JsonInclude] public List<MapEventShape>? Shapes { get; internal set; }
    }

    /// <summary>
    /// Specifies the source type for a map event shape, indicating whether the shape is derived from a GeoJSON feature
    /// or from a GeoJSON feature wrapped in a map shape.
    /// </summary>
    /// <remarks>Use this enumeration to distinguish between raw GeoJSON features and features that are
    /// encapsulated within a map-specific shape object. This distinction may affect how event data is processed or
    /// rendered in mapping applications.</remarks>
    [JsonConverter(typeof(JsonStringEnumConverter<MapEventShapeSource>))]
    public enum MapEventShapeSource
    {
        /// <summary>
        /// source is a GeoJSON Feature
        /// </summary>
        Feature,

        /// <summary>
        /// source is a GeoJSON Feature wrapped in a map shape
        /// </summary>
        Shape,
    }

    /// <summary>
    /// Represents a shape associated with a map event, including its geometry type, source, bounding box, and
    /// properties.
    /// </summary>
    /// <remarks>Use this class to access information about a shape involved in a map event, such as its
    /// identifier, geometry type, and associated properties. The shape may originate from different sources, such as a
    /// GeoJSON Feature or an Azure map shape, as indicated by the source property.</remarks>
    public class MapEventShape()
    {
        /// <summary>
        /// The id of the shape.
        /// </summary>
        [JsonInclude]
        public string? Id { get; internal set; }

        /// <summary>
        /// The type of geometry this shape contains.
        /// </summary>
        [JsonInclude]
        public GeometryType? Type { get; internal set; }

        /// <summary>
        /// As shape can be added to the map as a GeoJSON Feature or an Azure map shape.
        /// Denotes which of these the shape represents.
        /// </summary>
        [JsonInclude]
        public MapEventShapeSource? Source { get; internal set; }

        /// <summary>
        /// The bounding box of the shape
        /// </summary>
        [JsonInclude]
        public BoundingBox? Bbox { get; internal set; }

        /// <summary>
        /// The properties of the shape.
        /// </summary>
        [JsonInclude]
        public Properties? Properties { get; internal set; }
    }
}

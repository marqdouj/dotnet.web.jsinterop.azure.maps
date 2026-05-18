using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    [JsonConverter(typeof(JsonStringEnumConverter<MapEventDataPayloadDataType>))]
    public enum MapEventDataPayloadDataType
    {
        [Display(Name = "Style")] 
        style,

        [Display(Name = "Source")] 
        source
    }

    [JsonConverter(typeof(JsonStringEnumConverter<MapEventDataPayloadSourceDataType>))]
    public enum MapEventDataPayloadSourceDataType
    {
        [Display(Name = "Metadata")] 
        metadata,

        [Display(Name = "Content")] 
        content
    }

    public class MapEventDataPayload
    {
        /// <summary>
        /// <inheritdoc cref="MapEventDataPayloadDataType"/>
        /// </summary>
        public MapEventDataPayloadDataType? DataType { get; set; }

        public bool? IsSourceLoaded { get; set; }

        public string? Source { get; set; }

        /// <summary>
        /// <inheritdoc cref="MapEventDataPayloadSourceDataType"/>
        /// </summary>
        public MapEventDataPayloadSourceDataType? SourceDataType { get; set; }

        /// <summary>
        /// <inheritdoc cref="Layers.Tile"/>
        /// </summary>
        public Tile? Tile { get; set; }
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

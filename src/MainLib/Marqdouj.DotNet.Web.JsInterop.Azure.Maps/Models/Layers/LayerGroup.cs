using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Events;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers
{
    /// <summary>
    /// layer to be added to the map, along with optional map event definitions associated with the layer.
    /// </summary>
    /// <param name="layer">The layer to be added to the map. Cannot be null.</param>
    /// <param name="events">Optional collection of map event definitions associated with the layer.</param>
    public class LayerGroup(ILayer layer, IEnumerable<MapEvent>? events = null)
    {
        /// <summary>
        /// <inheritdoc cref="ILayer"/>
        /// </summary>
        [JsonIgnore] 
        public ILayer Layer { get; } = layer;

        /// <summary>
        /// <inheritdoc cref="MapEvent"/> to be associated with the layer.
        /// </summary>
        [JsonIgnore] 
        public IEnumerable<MapEvent>? Events { get; } = events;

        [JsonPropertyName("layer")]
        [JsonInclude] 
        internal object? JsInteropLayer => Layer;

        [JsonPropertyName("events")]
        [JsonInclude] 
        internal object? JSinteropEvents => Events?.Cast<object>().ToList();
    }
}

using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers
{
    /// <summary>
    /// The state of the tile.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<TileState>))]
    public enum TileState
    {
        /// <summary>
        /// Tile data is in the process of loading.
        /// </summary>
        Loading,

        /// <summary>
        /// Tile data has been loaded.
        /// </summary>
        Loaded,

        /// <summary>
        /// Tile data has been loaded and is being updated.
        /// </summary>
        Reloading,

        /// <summary>
        /// The data has been deleted.
        /// </summary>
        Unloaded,

        /// <summary>
        /// Tile data was not loaded because of an error.
        /// </summary>
        Errored,

        /// <summary>
        ///Tile data was previously loaded, but has expired per its HTTP headers and is in the process of refreshing.
        /// </summary>
        Expired
    }

    /// <summary>
    /// The id for a Tile.
    /// </summary>
    public class TileId
    {
        /// <summary>
        /// The x coordinate of the tile.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// The y coordinate of the tile.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// The z coordinate of the tile.
        /// </summary>
        public double Z { get; set; }
    }

    /// <summary>
    /// Tile object returned by the map when a source data event occurs.
    /// </summary>
    public class Tile
    {
        /// <summary>
        /// The id of the tile.
        /// </summary>
        public TileId? Id { get; set; }

        /// <summary>
        /// The size of the tile.
        /// </summary>
        public double? Size { get; set; }

        /// <summary>
        /// The state of the tile.
        /// </summary>
        public TileState? State {  get; set; }
    }
}

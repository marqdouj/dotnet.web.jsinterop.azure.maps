using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Converters;
using Marqdouj.DotNet.Web.JsInterop.GeoJson;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// An enumeration that defines the position of a marker relative to its anchor point.
    /// </summary>
    [JsonConverter(typeof(MapEnumJsonConverter<HtmlMarkerAnchor>))]
    public enum HtmlMarkerAnchor
    {
        Center,
        Top,
        Bottom,
        Left,
        Right,
        [Display(Name = "Top Left")]
        Top_Left,
        [Display(Name = "Top Right")]
        Top_Right,
        [Display(Name = "Bottom Left")]
        Bottom_Left,
        [Display(Name = "Bottom Right")]
        Bottom_Right,
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Defines the properties of an HTML marker that can be added to a map. 
    /// The HTML marker is a custom marker that allows you to use HTML content as the marker's visual representation. 
    /// It provides flexibility in designing markers with various styles and interactivity.
    /// </summary>
    public class HtmlMarker : JsInteropBase, ICloneable
    {
        /// <summary>
        /// <inheritdoc cref="HtmlMarkerOptions"/>
        /// </summary>
        public HtmlMarkerOptions Options { get; set { ArgumentNullException.ThrowIfNull(field, nameof(Options)); field = value; } } = new();

        /// <summary>
        /// If true, a click event will be added to toggle the popup.
        /// </summary>
        public bool TogglePopupOnClick { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var clone = (HtmlMarker)MemberwiseClone();
            clone.Options = (HtmlMarkerOptions)Options.Clone();

            return clone;
        }
    }

    /// <summary>
    /// Options for configuring an HTML marker on a map. 
    /// This class allows you to specify various properties such as the marker's position, appearance, interactivity, and associated popup. 
    /// It provides flexibility in customizing the marker's behavior and visual representation.
    /// </summary>
    public class HtmlMarkerOptions : ICloneable
    {
        /// <summary>
        /// Indicates the marker's location relative to its position on the map.
        /// Default "bottom"
        /// </summary>
        public HtmlMarkerAnchor? Anchor { get; set; }

        /// <summary>
        /// A color value that replaces any {color} placeholder property that has been included in a string htmlContent.
        /// default "#1A73AA"
        /// </summary>
        public string? Color { get; set; }

        /// <summary>
        /// Indicates if the user can drag the position of the marker using the mouse or touch controls.
        /// default false
        /// </summary>
        public bool? Draggable { get; set; }

        /// <summary>
        /// The HTML content of the marker. Can be a string or an HTMLElement equivalent.
        /// Add {text} and {color} to HTML strings as placeholders to make it easy to update
        /// these values in your marker by using the setOptions function of the htmlmarker class.
        /// This allows you to create a single HTML marker string that can be used as a template for multiple markers.
        /// </summary>
        public string? HtmlContent { get; set; }

        /// <summary>
        /// An offset in pixels to move the popup relative to the markers center.
        /// Negatives indicate left and up.
        /// default [0, 0]
        /// </summary>
        public Pixel? PixelOffset { get; set; }

        /// <summary>
        /// The position of the marker.
        /// default [0, 0]
        /// </summary>
        public Position? Position { get; set; }

        /// <summary>
        /// A popup that is attached to the marker.
        /// </summary>
        public Popup? Popup { get; set; }

        /// <summary>
        /// A color value that replaces any {secondaryColor} placeholder property that has been included in a string htmlContent.
        /// default "white"
        /// </summary>
        public string? SecondaryColor { get; set; }

        /// <summary>
        /// A string of text that replaces any {text} placeholder property that has been included in a string htmlContent.
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// Specifies if the marker is visible or not.
        /// default true
        /// </summary>
        public bool? Visible { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var clone = (HtmlMarkerOptions)MemberwiseClone();
            clone.PixelOffset = PixelOffset?.Clone() as Pixel;
            clone.Position = Position?.Clone() as Position;
            clone.Popup = Popup?.Clone() as Popup;

            return clone;
        }
    }
}

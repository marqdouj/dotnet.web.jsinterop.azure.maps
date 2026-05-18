using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Controls
{
    /// <summary>
    /// Base class that all map controls inherit from.
    /// </summary>
    public abstract class ControlBase : JsInteropBase, ICloneable
    {
        /// <summary>
        /// <see cref="MapControlType"/>
        /// </summary>
        public abstract MapControlType Type { get; }

        /// <summary>
        /// <see cref="Controls.ControlOptions"/>
        /// </summary>
        public ControlOptions? ControlOptions { get; set; }

        /// <summary>
        /// Get the instance of the options for the control. may be null.
        /// </summary>
        /// <returns></returns>
        public abstract OptionsBase? GetOptions();

        /// <summary>
        /// Creates an instance of the options type that the control uses, but does not update the existing options with that instance.
        /// </summary>
        /// <returns></returns>
        public abstract OptionsBase CreateOptions();

        /// <summary>
        /// Assigns the options to the control. Must of of the expected type of options.
        /// </summary>
        /// <param name="options"></param>
        public abstract void SetOptions(OptionsBase? options);

        /// <summary>
        /// Used for sorting or placement position on the map
        /// </summary>
        [JsonIgnore]
        public int SortOrder { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public abstract object Clone();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Type} : {Id}";
        }
    }

    /// <summary>
    /// Position where the control is to be placed on the map.
    /// </summary>
    [JsonConverter(typeof(MapEnumJsonConverter<MapControlPosition>))]
    public enum MapControlPosition
    {
        /// <summary>
        ///The control will place itself in its default location.
        ///Literal value 'non-fixed'
        /// </summary>
        Non_Fixed,

        /// <summary>
        ///Places the control in the top left of the map.
        ///Literal value 'top-left'
        /// </summary>
        Top_Left,

        /// <summary>
        ///Places the control in the top right of the map.
        ///Literal value 'top-right'
        /// </summary>
        Top_Right,

        /// <summary>
        ///Places the control in the bottom left of the map.
        ///Literal value 'bottom-left'
        /// </summary>
        Bottom_Left,

        /// <summary>
        ///Places the control in the bottom right of the map.
        ///Literal value 'bottom-right'
        /// </summary>
        Bottom_Right,
    }

    /// <summary>
    /// style for a map control.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<MapControlStyle>))]
    public enum MapControlStyle
    {
        /// <summary>
        /// The control will be in the light style.
        /// Literal value 'light'
        /// </summary>
        [Display(Name = "Light")]
        light,

        /// <summary>
        /// The control will be in the dark style.
        /// Literal value 'dark'
        /// </summary>
        [Display(Name = "Dark")]
        dark,

        /// <summary>
        /// The control will automatically switch styles based on the style of the map.
        /// If a control doesn't support automatic styling the light style will be used by default.
        /// Literal value 'auto'
        /// </summary>
        [Display(Name = "auto")]
        auto
    }

    /// <summary>
    /// Type of map control.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<MapControlType>))]
    public enum MapControlType
    {
        /// <summary>
        /// A control for changing the rotation of the map.
        /// </summary>
        Compass,

        /// <summary>
        /// A control to make the map or a specified element full screen.
        /// </summary>
        Fullscreen,

        /// <summary>
        /// A control for changing the pitch of the map.
        /// </summary>
        Pitch,

        /// <summary>
        /// A control to display a scale bar on the map.
        /// </summary>
        Scale,

        /// <summary>
        /// A control for changing the style of the map.
        /// </summary>
        Style,

        /// <summary>
        /// A control for displaying traffic on the map.
        /// </summary>
        Traffic,

        /// <summary>
        /// A control for displaying traffic legend on the map.
        /// </summary>
        [Display(Name = "Traffic Legend")]
        TrafficLegend,

        /// <summary>
        /// A control for changing the zoom of the map.
        /// </summary>
        Zoom,
    }
}

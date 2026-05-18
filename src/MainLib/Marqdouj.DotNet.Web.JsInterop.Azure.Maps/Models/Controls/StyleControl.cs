using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Controls
{
    /// <summary>
    /// <see cref="MapControlType.Style"/>
    /// </summary>
    [Display(Name = "style")]
    public class StyleControl : MapControl<StyleControlOptions>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"><see cref="MapControlPosition"/></param>
        /// <param name="options"><see cref="StyleControlOptions"/></param>
        public StyleControl(MapControlPosition? position = MapControlPosition.Top_Right, StyleControlOptions? options = null)
        {
            if (position != null)
            {
                ControlOptions ??= new ControlOptions();
                ControlOptions.Position = position;
            }
            Options = options;
            SortOrder = 4;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override MapControlType Type => MapControlType.Style;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override StyleControlOptions? Options { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override OptionsBase? GetOptions() => Options;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override OptionsBase CreateOptions() => new StyleControlOptions();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override void SetOptions(OptionsBase? options) => Options = (StyleControlOptions?)options;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return Copy();
        }

        /// <summary>
        /// Makes a copy of this control
        /// </summary>
        /// <param name="fullCopy">if true, copies the internal settings</param>
        /// <returns></returns>
        public StyleControl Copy(bool fullCopy = true)
        {
            var control = new StyleControl
            {
                ControlOptions = (ControlOptions?)ControlOptions?.Clone(),
                Options = (StyleControlOptions?)Options?.Clone(),
                SortOrder = SortOrder
            };

            if (fullCopy)
            {
                control.Id = Id;
            }

            return control;
        }
    }

    /// <summary>
    /// The layout to display the styles in.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<StyleControlLayout>))]
    public enum StyleControlLayout
    {
        /// <summary>
        /// A row of clickable icons for each style.
        /// </summary>
        [Display(Name = "Icons")] 
        icons,

        /// <summary>
        /// A scrollable list with the icons and names for each style.
        /// </summary>
        [Display(Name = "List")] 
        list,
    }

    /// <summary>
    /// The options for a stylecontrol object.
    /// </summary>
    public class StyleControlOptions : OptionsBase
    {
        /// <summary>
        /// The layout to display the styles in.
        /// Default 'icons'
        /// </summary>
        public StyleControlLayout? Layout { get; set; }

        /// <summary>
        /// The map styles to show in the control.
        /// Default = road, Grayscale (light), Grayscale (dark)", night, Terra
        /// </summary>
        [Display(Name = "map Styles")]
        public List<MapStyle>? MapStyles { get; set => field = value is null || value.Count == 0 ? null : value; }

        /// <summary>
        /// The style of the control.
        /// Default 'light'.
        /// </summary>
        public MapControlStyle? Style { get; set; }

        /// <summary>
        /// Whether to let style control automatically set the style, once user select a map style.
        /// If set to 'false', then clicking on style will not set the set the style automatically.
        /// Default 'true'
        /// </summary>
        [Display(Name = "auto Selection Mode")]
        public bool? AutoSelectionMode { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var clone = (StyleControlOptions)MemberwiseClone();
            clone.MapStyles = MapStyles?.ToList();
            return clone;
        }
    }
}

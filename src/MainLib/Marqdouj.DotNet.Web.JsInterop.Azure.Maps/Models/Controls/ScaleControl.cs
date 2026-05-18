using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Controls
{
    /// <summary>
    /// <see cref="MapControlType.Scale"/>
    /// </summary>
    [Display(Name = "Scale")]
    public class ScaleControl : MapControl<ScaleControlOptions>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"><see cref="MapControlPosition"/></param>
        /// <param name="options"><see cref="ScaleControlOptions"/></param>
        public ScaleControl(MapControlPosition? position = MapControlPosition.Bottom_Right, ScaleControlOptions? options = null)
        {
            if (position != null)
            {
                ControlOptions ??= new ControlOptions();
                ControlOptions.Position = position;
            }
            Options = options;
            SortOrder = 5;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override MapControlType Type => MapControlType.Scale;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override ScaleControlOptions? Options { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override OptionsBase? GetOptions() => Options;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override OptionsBase CreateOptions() => new ScaleControlOptions();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override void SetOptions(OptionsBase? options) => Options = (ScaleControlOptions?)options;

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
        public ScaleControl Copy(bool fullCopy = true)
        {
            var control = new ScaleControl
            {
                ControlOptions = (ControlOptions?)ControlOptions?.Clone(),
                Options = (ScaleControlOptions?)Options?.Clone(),
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
    /// Unit of the distance.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<ScaleControlUnit>))]
    public enum ScaleControlUnit
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Metric")]
        metric,

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Imperial")]
        imperial,

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Nautical")]
        nautical,
    }

    /// <summary>
    /// The options for a ScaleControl object.
    /// </summary>
    public class ScaleControlOptions : OptionsBase
    {
        /// <summary>
        /// The maximum length of the scale control in pixels.
        /// Default '100'
        /// </summary>
        [Display(Name = "Max Width")]
        public double? MaxWidth { get; set; }

        /// <summary>
        /// Unit of the distance.
        /// Default 'metric'.
        /// </summary>
        public ScaleControlUnit? Unit {  get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return MemberwiseClone();
        }
    }
}

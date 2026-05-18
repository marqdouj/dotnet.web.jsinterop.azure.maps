using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Controls
{
    /// <summary>
    /// <see cref="MapControlType.Pitch"/>
    /// </summary>
    [Display(Name = "Pitch")]
    public class PitchControl : MapControl<PitchControlOptions>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"><see cref="MapControlPosition"/></param>
        /// <param name="options"><see cref="PitchControlOptions"/></param>
        public PitchControl(MapControlPosition? position = MapControlPosition.Top_Right, PitchControlOptions? options = null)
        {
            if (position != null)
            {
                ControlOptions ??= new ControlOptions();
                ControlOptions.Position = position;
            }
            Options = options;
            SortOrder = 2;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override MapControlType Type => MapControlType.Pitch;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override PitchControlOptions? Options { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override OptionsBase? GetOptions() => Options;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override OptionsBase CreateOptions() => new PitchControlOptions();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override void SetOptions(OptionsBase? options) => Options = (PitchControlOptions?)options;

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
        public PitchControl Copy(bool fullCopy = true)
        {
            var control = new PitchControl
            {
                ControlOptions = (ControlOptions?)ControlOptions?.Clone(),
                Options = (PitchControlOptions?)Options?.Clone(),
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
    /// The options for a PitchControl object.
    /// </summary>
    public class PitchControlOptions : OptionsBase
    {
        /// <summary>
        /// The angle that the map will tilt with each click of the control.
        /// Default '10'.
        /// </summary>
        [Display(Name = "Pitch Degrees Delta")]
        public double PitchDegreesDelta { get; set; } = 10;

        /// <summary>
        /// The style of the control.
        /// Default 'light'.
        /// </summary>
        public MapControlStyle? Style { get; set; }

        /// <summary>
        /// Inverts the direction of map pitch controls.
        /// Default 'false'.
        /// </summary>
        public bool? Inverted { get; set; }

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

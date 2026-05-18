using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Controls
{
    /// <summary>
    /// <see cref="MapControlType.Compass"/>
    /// </summary>
    [Display(Name = "Compass")]
    public class CompassControl : MapControl<CompassControlOptions>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"><see cref="MapControlPosition"/></param>
        /// <param name="options"><see cref="CompassControlOptions"/></param>
        public CompassControl(MapControlPosition? position = MapControlPosition.Top_Right, CompassControlOptions? options = null)
        {
            if (position != null)
            {
                ControlOptions ??= new ControlOptions();
                ControlOptions.Position = position;
            }
            Options = options;
            SortOrder = 3;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override MapControlType Type => MapControlType.Compass;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override CompassControlOptions? Options { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override OptionsBase? GetOptions() => Options;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override OptionsBase CreateOptions() => new CompassControlOptions();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override void SetOptions(OptionsBase? options) => Options = (CompassControlOptions?)options;

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
        public CompassControl Copy(bool fullCopy = true)
        {
            var control = new CompassControl
            {
                ControlOptions = (ControlOptions?)ControlOptions?.Clone(),
                Options = (CompassControlOptions?)Options?.Clone(),
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
    /// The options for a CompassControl object.
    /// </summary>
    public class CompassControlOptions : OptionsBase
    {
        /// <summary>
        /// The angle that the map will rotate with each click of the control.
        /// Default '15'.
        /// </summary>
        [Display(Name = "Rotation Degrees Delta")]
        public double RotationDegreesDelta { get; set; } = 15;

        /// <summary>
        /// The style of the control.
        /// Default 'light'.
        /// </summary>
        public MapControlStyle? Style { get; set; }

        /// <summary>
        /// Inverts the direction of map rotation controls.
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

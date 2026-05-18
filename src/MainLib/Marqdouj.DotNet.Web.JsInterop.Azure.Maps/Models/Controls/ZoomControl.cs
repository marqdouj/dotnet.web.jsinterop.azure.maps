using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Controls
{
    /// <summary>
    /// <see cref="MapControlType.Zoom"/>
    /// </summary>
    [Display(Name = "Zoom")]
    public class ZoomControl : MapControl<ZoomControlOptions>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"><see cref="MapControlPosition"/></param>
        /// <param name="options"><see cref="ZoomControlOptions"/></param>
        public ZoomControl(MapControlPosition? position = MapControlPosition.Top_Right, ZoomControlOptions? options = null)
        {
            if (position != null)
            {
                ControlOptions ??= new ControlOptions();
                ControlOptions.Position = position;
            }
            Options = options;
            SortOrder = 1;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override MapControlType Type => MapControlType.Zoom;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override ZoomControlOptions? Options { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override OptionsBase? GetOptions() => Options;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override OptionsBase CreateOptions() => new ZoomControlOptions();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override void SetOptions(OptionsBase? options) => Options = (ZoomControlOptions?)options;

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
        public ZoomControl Copy(bool fullCopy = true)
        {
            var control = new ZoomControl
            {
                ControlOptions = (ControlOptions?)ControlOptions?.Clone(),
                Options = (ZoomControlOptions?)Options?.Clone(),
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
    /// The options for a ZoomControl object.
    /// </summary>
    public class ZoomControlOptions : OptionsBase
    {
        /// <summary>
        /// The extent to which the map will zoom with each click of the control.
        /// Default '1'.
        /// </summary>
        [Display(Name = "Zoom Delta")]
        public double ZoomDelta { get; set; } = 1;

        /// <summary>
        /// The style of the control.
        /// Default 'light'.
        /// </summary>
        public MapControlStyle? Style { get; set; }

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

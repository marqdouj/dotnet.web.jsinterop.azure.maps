using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Controls
{
    /// <summary>
    /// <see cref="MapControlType.TrafficLegend"/>
    /// </summary>
    [Display(Name = "Traffic Legend")]
    public class TrafficLegendControl : MapControl<TrafficLegendControlOptions>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"><see cref="MapControlPosition"/></param>
        /// <param name="options"><see cref="TrafficLegendControlOptions"/></param>
        public TrafficLegendControl(MapControlPosition? position = MapControlPosition.Top_Right, TrafficLegendControlOptions? options = null)
        {
            if (position != null)
            {
                ControlOptions ??= new ControlOptions();
                ControlOptions.Position = position;
            }
            Options = options;
            SortOrder = 0;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override MapControlType Type => MapControlType.TrafficLegend;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override TrafficLegendControlOptions? Options { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override OptionsBase? GetOptions() => Options;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override OptionsBase CreateOptions() => new TrafficLegendControlOptions();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override void SetOptions(OptionsBase? options) => Options = (TrafficLegendControlOptions?)options;

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
        public TrafficLegendControl Copy(bool fullCopy = true)
        {
            var control = new TrafficLegendControl
            {
                ControlOptions = (ControlOptions?)ControlOptions?.Clone(),
                Options = (TrafficLegendControlOptions?)Options?.Clone(),
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
    /// The options for a TrafficLegendControl object.
    /// </summary>
    public class TrafficLegendControlOptions : OptionsBase
    {
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

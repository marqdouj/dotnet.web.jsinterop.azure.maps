using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Controls
{
    /// <summary>
    /// <see cref="MapControlType.Fullscreen"/>
    /// </summary>
    [Display(Name = "Fullscreen")]
    public class FullscreenControl : MapControl<FullscreenControlOptions>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"><see cref="MapControlPosition"/></param>
        /// <param name="options"><see cref="FullscreenControlOptions"/></param>
        public FullscreenControl(MapControlPosition? position = MapControlPosition.Top_Right, FullscreenControlOptions? options = null)
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
        public override MapControlType Type => MapControlType.Fullscreen;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override FullscreenControlOptions? Options { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override OptionsBase? GetOptions() => Options;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override OptionsBase CreateOptions() => new FullscreenControlOptions();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override void SetOptions(OptionsBase? options) => Options = (FullscreenControlOptions?)options;

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
        public FullscreenControl Copy(bool fullCopy = true)
        {
            var control = new FullscreenControl
            {
                ControlOptions = (ControlOptions?)ControlOptions?.Clone(),
                Options = (FullscreenControlOptions?)Options?.Clone(),
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
    /// The options for a FullscreenControl object.
    /// </summary>
    public class FullscreenControlOptions : OptionsBase
    {
        /// <summary>
        /// The style of the control.
        /// Default 'light'.
        /// </summary>
        public MapControlStyle? Style { get; set; }

        /// <summary>
        /// Id of the HTML element which should be made full screen.
        /// If not specified, the map container element will be used.
        /// </summary>
        [Display(Name = "Container Id")]
        public string? ContainerId { get; set; }

        /// <summary>
        /// Indicates if the control should be hidden if the browser does not support full screen mode.
        /// Default 'false'
        /// </summary>
        [Display(Name = "Hide if Unsupported")]
        public bool? HideIfUnsupported { get; set; }

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

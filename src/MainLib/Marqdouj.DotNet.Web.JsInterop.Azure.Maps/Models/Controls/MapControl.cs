using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Controls
{
    /// <summary>
    /// <see cref="ControlBase"/>
    /// </summary>
    /// <typeparam name="TOptions"></typeparam>
    public abstract class MapControl<TOptions> : ControlBase where TOptions : OptionsBase
    {
        /// <summary>
        /// Gets or sets the options used to configure the behavior of the control.
        /// </summary>
        public abstract TOptions? Options { get; set; }

        ///// <summary>
        ///// <inheritdoc/>
        ///// </summary>
        //internal override object? OptionsJson => Options;
    }
}

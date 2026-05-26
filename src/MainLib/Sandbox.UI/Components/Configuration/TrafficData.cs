using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;

namespace Sandbox.UI.Components.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"><see cref="MapOptions"/></param>
    public class TrafficData(MapOptions? options)
    {
        /// <summary>
        /// <inheritdoc cref="TrafficOptions"/>
        /// </summary>
        public TrafficOptions Options { get; set; } = options?.Traffic?.Clone() as TrafficOptions ?? new();

        internal void Reset()
        {
            Options = new();
        }

        /// <summary>
        /// Updates the given MapOptionsEdit instance to represent the current edit settings.
        /// </summary>
        internal void UpdateMapOptionsEdit(MapOptionsEdit options)
        {
            options.Traffic = Options;
        }
    }
}

using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;

namespace Sandbox.UI.Components.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"><see cref="MapOptions"/></param>
    public class ServiceData(MapOptions? options)
    {
        /// <summary>
        /// <inheritdoc cref="ServiceOptions"/>
        /// </summary>
        public ServiceOptions Options { get; set; } = options?.Service?.Clone() as ServiceOptions ?? new();

        internal void Reset()
        {
            Options = new();
        }

        /// <summary>
        /// Updates the given MapOptionsEdit instance to represent the current edit settings.
        /// </summary>
        internal void UpdateMapOptionsEdit(MapOptionsEdit options)
        {
            options.Service = Options;
        }
    }

}

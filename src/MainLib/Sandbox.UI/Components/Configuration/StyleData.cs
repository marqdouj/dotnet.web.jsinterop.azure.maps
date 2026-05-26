using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;

namespace Sandbox.UI.Components.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"><see cref="MapOptions"/></param>
    public class StyleData(MapOptions? options)
    {
        /// <summary>
        /// <inheritdoc cref="StyleOptions"/>
        /// </summary>
        public StyleOptions Options { get; set; } = options?.Style?.Clone() as StyleOptions ?? new();

        internal void Reset()
        {
            Options = new();
        }

        /// <summary>
        /// Updates the given MapOptionsEdit instance to represent the current edit settings.
        /// </summary>
        internal void UpdateMapOptionsEdit(MapOptionsEdit options)
        {
            options.Style = Options;
        }
    }

}

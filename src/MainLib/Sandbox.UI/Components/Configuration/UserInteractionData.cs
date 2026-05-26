using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;

namespace Sandbox.UI.Components.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"><see cref="MapOptions"/></param>
    public class UserInteractionData(MapOptions? options)
    {
        /// <summary>
        /// <inheritdoc cref="UserInteractionOptions"/>
        /// </summary>
        public UserInteractionOptions Options { get; set; } = options?.UserInteraction?.Clone() as UserInteractionOptions ?? new();

        internal void Reset()
        {
            Options = new();
        }

        /// <summary>
        /// Updates the given MapOptionsEdit instance to represent the current edit settings.
        /// </summary>
        internal void UpdateMapOptionsEdit(MapOptionsEdit options)
        {
            options.UserInteraction = Options;
        }
    }
}

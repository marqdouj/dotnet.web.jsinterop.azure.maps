using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Controls
{
    /// <summary>
    /// The options for adding a control to the map.
    /// </summary>
    public class ControlOptions : OptionsBase
    {
        /// <summary>
        /// The position the control will be placed on the map. 
        /// </summary>
        public MapControlPosition? Position { get; set; }

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

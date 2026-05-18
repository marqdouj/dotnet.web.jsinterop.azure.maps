using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration
{
    /// <summary>
    /// The options for the map's lighting.
    /// </summary>
    [Display(Name = "Lighting")]
    public class LightOptions : OptionsBase
    {
        /// <summary>
        /// Specifies whether extruded geometries are lit relative to the map or viewport.
        /// Supported values:
        /// "map": The position of the light source is aligned to the rotation of the map.
        /// "viewport": The position fo the light source is aligned to the rotation of the viewport.
        /// Default: 'map'.
        /// </summary>
        public LightAnchorType? Anchor { get; set; }

        /// <summary>
        /// Color tint for lighting extruded geometries.
        /// Default: '#FFFFFF'.
        /// </summary>
        public string? Color { get; set; }

        /// <summary>
        /// Intensity of lighting (on a scale from 0 to 1).
        /// Higher numbers will present as more extreme contrast.
        /// Default '0.5'.
        /// </summary>
        public double? Intensity { get; set; }

        /// <summary>
        /// <inheritdoc cref="LightPosition"/>
        /// </summary>
        public LightPosition? Position { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var clone = (LightOptions)MemberwiseClone();
            clone.Position = (LightPosition?)Position?.Clone();

            return clone;
        }
    }
}

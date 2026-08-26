using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common;
using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Converters;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers.Images
{
    /// <summary>
    /// Image templates available within the Azure Maps Web SDK.
    /// </summary>
    [JsonConverter(typeof(MapEnumJsonConverter<ImageTemplateName>))]
    public enum ImageTemplateName
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        marker,
        marker_thick,
        marker_circle,
        pin,
        pin_round,
        marker_flat,
        marker_arrow,
        marker_ball_pin,
        marker_square,
        marker_square_cluster,
        marker_square_rounded,
        marker_square_rounded_cluster,
        flag,
        flag_triangle,
        rounded_square,
        rounded_square_thick,
        triangle,
        triangle_thick,
        hexagon,
        hexagon_thick,
        hexagon_rounded,
        hexagon_rounded_thick,
        triangle_arrow_up,
        triangle_arrow_left,
        arrow_up,
        arrow_up_thin,
        car,
        checker,
        checker_rotated,
        zig_zag,
        zig_zag_vertical,
        circles_spaced,
        circles,
        diagonal_lines_up,
        diagonal_lines_down,
        diagonal_stripes_up,
        diagonal_stripes_down,
        grid_lines,
        rotated_grid_lines,
        rotated_grid_stripes,
        x_fill,
        dots
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }

    /// <summary>
    /// Represents the definition of an image template, including its name, identifier, and optional customization
    /// properties such as color and scale.
    /// </summary>
    /// <remarks>Use this class to specify the configuration for an image template that can be applied to map
    /// elements or other visual components. The template name must correspond to a supported template. The identifier
    /// can be provided or automatically generated to ensure uniqueness within CSS contexts. Properties such as Color,
    /// SecondaryColor, and Scale allow further customization of the template's appearance.</remarks>
    public class ImageTemplate : JsInteropBase, ICloneable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The image's id. If the specified id matches the id of a previously added image the new image will be ignored.</param>
        /// <param name="templateName"><see cref="TemplateName"/></param>
        public ImageTemplate(string id, string templateName)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(id);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(templateName);
            Id = id;
            TemplateName = templateName;
        }

        /// <summary>
        /// <inheritdoc cref="ImageTemplate(string, string)"/>
        /// </summary>
        /// <param name="id">The image's id. If the specified id matches the id of a previously added image the new image will be ignored.</param>
        /// <param name="templateName"><see cref="TemplateName"/></param>
        public ImageTemplate(string id, ImageTemplateName templateName)
            : this(id, templateName.ToString().Replace("_", "-")) { }

        /// <summary>
        /// Specifies which image template to use.
        /// </summary>
        public string TemplateName { get; }

        /// <summary>
        /// The primary color. Default: #1A73AA
        /// </summary>
        public string? Color { get; set; }

        /// <summary>
        /// The secondary color. Default: white
        /// </summary>
        public string? SecondaryColor { get; set; }

        /// <summary>
        /// Specifies how much to scale the template. 
        /// For best results, scale the icon to the maximum size you want to display it on the map, 
        /// then use the symbol layers icon size option to scale down if needed. 
        /// This will reduce blurriness due to scaling. Default: 1
        /// </summary>
        public double? Scale { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common
{
    /// <summary>
	/// Format option for hyperlink strings.
	/// </summary>
    public class HyperLinkFormatOptions : ICloneable
    {
        /// <summary>
        /// Specifies the text that should be displayed to the user.
        /// If not specified, the hyperlink will be displayed.
        /// If the hyperlink is an image, this will be set as the "alt" property of the img tag.
        /// </summary>
        public string? Label { get; set; }

        /// <summary>
        /// Specifies if the hyperlink is for an image.
        /// If set to true, the hyperlink will be loaded into an img tag and when clicked,
        /// will open the hyperlink to the image.
        /// </summary>
        public bool? IsImage { get; set; }

        /// <summary>
        /// Specifies the where the hyperlink should open.
        /// "_blank" | "_self" | "_parent" | "_top"
        /// Default: `"_blank"`
        /// </summary>
        public string? Target { get; set; }

        /// <summary>
        /// Specifies a scheme to prepend to a hyperlink such as 'mailto:' or 'tel:'.
        /// </summary>
        public string? Scheme { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

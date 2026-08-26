using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Intl;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common
{
    /// <summary>
    /// Represents a template for a popup that can be displayed on the map.
    /// </summary>
    public class PopupTemplate : ICloneable
    {
        /// <summary>
		/// The background color of the popup template.
		/// </summary>
        public string? FillColor { get; set; }

        /// <summary>
        /// The default text color of the popup template.
        /// </summary>
        public string? TextColor { get; set; }

        /// <summary>
        /// A HTML string for the title of the popup that contains placeholders for properties of the feature it is being displayed for.
        /// Placeholders can be in the format "{propertyName}" or "{propertyName/subPropertyName}".
        /// </summary>
        public string? Title { get; set; }
		
        /// <summary>
        /// If a description is available, it will be written as the content rather than as a table of properties.
        /// Default: `true`
        /// @default true
        /// </summary>
        public bool? SingleDescription { get; set; }

        /// <summary>
        /// A HTML string for the main content of the popup that contains placeholders for properties of the feature it is being displayed for.
        /// Placeholders can be in the format "{propertyName}" or "{propertyName/subPropertyName}".
        /// Can be string | PropertyInfo[] | Array{string | PropertyInfo[]}
        /// </summary>
        public object? Content { get; set; }

        /// <summary>
        /// Specifies if content should be wrapped with a sandboxed iframe.
        /// Unless explicitly set to false, the content will be sandboxed within an iframe by default.
        /// When enabled, all content will be wrapped in a sandboxed iframe with scripts, forms, pointer lock and top navigation disabled.
        /// Popups will be allowed so that links can be opened in a new page or tab.
        /// Older browsers that don't support the srcdoc parameter on iframes will be limited to rendering a small amount of content.
        /// </summary>
        public bool? SandboxContent { get; set; }

        /// <summary>
        /// If the property is a date object, these options specify how it should be formatted when displayed.
        /// Uses [Date.toLocaleString](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Date/toLocaleString).
        /// If not specified, dates will be converted to strings using
        /// [Date.toISOString](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Date/toISOString)
        /// </summary>
        public DateTimeFormatOptions? DateFormat { get; set; }

        /// <summary>
        /// If the property is a number, these options specify how it should be formatted when displayed.
        /// Uses [Number.toLocaleString](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Number/toLocaleString).
        /// </summary>
        public NumberFormatOptions? NumberFormat { get; set; }
		
        /// <summary>Format options for hyperlink strings.
        /// </summary>
        public HyperLinkFormatOptions? HyperlinkFormat { get; set; }

        /// <summary>
        /// Specifies if hyperlinks and email addresses should automatically be detected and rendered as clickable links.
        /// Default: `true`
        /// </summary>
        public bool? DetectHyperlinks { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public object Clone()
        {
            var clone = (PopupTemplate)MemberwiseClone();
            clone.DateFormat = DateFormat?.Clone() as DateTimeFormatOptions;
            clone.NumberFormat = NumberFormat?.Clone() as NumberFormatOptions;
            clone.HyperlinkFormat = HyperlinkFormat?.Clone() as HyperLinkFormatOptions;
            return clone;
        }
    }
}

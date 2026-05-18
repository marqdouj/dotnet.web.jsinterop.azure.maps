using System.ComponentModel.DataAnnotations;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration
{
    /// <summary>
    /// The style of the bordered map element.
    /// </summary>
    public class BorderedMapElementStyles : ICloneable
    {
        /// <summary>
        /// Specifies the visibility of the border.​
        /// </summary>
        [Display(Name = "Border Visible")]
        public bool? BorderVisible { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            return $"{BorderVisible}";
        }
    }

}

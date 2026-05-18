namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration
{
    /// <summary>
    /// The style of the map element.​
    /// </summary>
    public class MapElementStyles : ICloneable
    {
        /// <summary>
        /// Specifies the visibility of the element.​
        /// </summary>
        public bool? Visible { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            return $"{Visible}";
        }

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

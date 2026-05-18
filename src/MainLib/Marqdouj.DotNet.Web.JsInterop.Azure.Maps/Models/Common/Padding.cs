namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Common
{
    /// <summary>
    /// Represent the amount of padding in pixels to add to the side of a BoundingBox when setting the camera of a map.
    /// </summary>
    public class Padding : ICloneable
    {
        /// <summary>
        /// Amount of padding in pixels to add to the bottom.
        /// </summary>
        public int Bottom { get; set; }

        /// <summary>
        /// Amount of padding in pixels to add to the left.
        /// </summary>
        public int Left { get; set; }

        /// <summary>
        /// Amount of padding in pixels to add to the right.
        /// </summary>
        public int Right { get; set; }

        /// <summary>
        /// Amount of padding in pixels to add to the top.
        /// </summary>
        public int Top { get; set; }

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
        public override string ToString() => IsOneValue() ? $"{Top}" : $"{Top} {Right} {Bottom} {Left}";

        private bool IsOneValue() => Top == Right && Right == Bottom && Bottom == Left;
    }
}

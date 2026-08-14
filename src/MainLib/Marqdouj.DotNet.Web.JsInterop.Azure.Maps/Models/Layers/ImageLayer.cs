using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Sources;
using Marqdouj.DotNet.Web.JsInterop.GeoJson;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers
{
    /// <summary>
    /// <inheritdoc cref="LayerType.Image"/>
    /// </summary>
    public class ImageLayer : LayerBase<ImageLayerOptions, DataSource>
    {
        /// <summary>
        /// <inheritdoc cref="LayerType"/>
        /// </summary>
        public override LayerType Type => LayerType.Image;

        /// <summary>
        /// <inheritdoc cref="ImageLayerOptions"/>
        /// </summary>
        public override ImageLayerOptions? Options { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var clone = (ImageLayer)MemberwiseClone();
            clone.Options = (ImageLayerOptions?)Options?.Clone();
            return clone;
        }
    }

    /// <summary>
    /// An array of positions for the corners of the image listed in clockwise order: [top left, top right, bottom right, bottom left].
    /// </summary>
    public class ImageCoordinates : List<Position>, ICloneable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="topleft"><see cref="TopLeft"/></param>
        /// <param name="topRight"><see cref="TopRight"/></param>
        /// <param name="bottomRight"><see cref="BottomRight"/></param>
        /// <param name="bottomLeft"><see cref="BottomRight"/></param>
        public ImageCoordinates(Position topleft, Position topRight, Position bottomRight, Position bottomLeft)
        {
            Add(topleft);
            Add(topRight);
            Add(bottomRight);
            Add(bottomLeft);
        }

        /// <summary>
        /// Top left corner of the image.
        /// </summary>
        [JsonIgnore]
        public Position TopLeft
        {
            get { Verify(); return this[0]; }
            set { Verify(); this[0] = value; }
        }

        /// <summary>
        /// Top right corner of the image.
        /// </summary>
        [JsonIgnore]
        public Position TopRight
        {
            get { Verify(); return this[1]; }
            set { Verify(); this[1] = value; }
        }

        /// <summary>
        /// Bottom right corner of the image.
        /// </summary>
        [JsonIgnore]
        public Position BottomRight
        {
            get { Verify(); return this[2]; }
            set { Verify(); this[2] = value; }
        }

        /// <summary>
        /// Bottom left corner of the image.
        /// </summary>
        [JsonIgnore]
        public Position BottomLeft
        {
            get { Verify(); return this[3]; }
            set { Verify(); this[3] = value; }
        }

        /// <summary>
        /// Checks if list has the minimum required elements; if not adds them
        /// </summary>
        internal void Verify()
        {
            this.EnsureCount(4, 4);
        }

        /// <summary>
        /// <see cref="object.ToString()"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => "[" + string.Join(", ", this) + "]";

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    /// <summary>
    /// Options used when rendering point objects in a ImageLayer.
    /// </summary>
    public class ImageLayerOptions : MediaLayerOptions
    {
        /// <summary>
        /// An array of positions for the corners of the image listed in clockwise order: 
        /// [top left, top right, bottom right, bottom left].
        /// </summary>
        public ImageCoordinates? Coordinates { get; set; }

        /// <summary>
        /// URL to an image to overlay. Images hosted on other domains must have CORs enabled.
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var clone = (ImageLayerOptions)MemberwiseClone();
            clone.Coordinates = (ImageCoordinates?)Coordinates?.Clone();

            return clone;
        }
    }
}

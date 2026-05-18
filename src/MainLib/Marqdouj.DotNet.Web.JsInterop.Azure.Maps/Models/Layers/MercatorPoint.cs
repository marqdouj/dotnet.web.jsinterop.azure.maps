using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Layers
{
    /// <summary>
    /// A `MercatorPoint` object represents a projected three dimensional position.
    ///
    /// `MercatorPoint` uses the web mercator projection ([EPSG:3857](https://epsg.io/3857)) with slightly different units:
    /// - the size of 1 unit is the width of the projected world instead of the "mercator meter"
    /// - the origin of the coordinate space is at the north-west corner instead of the middle.
    ///
    /// For example, `MercatorPoint(0, 0, 0)` is the north-west corner of the mercator world and
    /// `MercatorPoint(1, 1, 0)` is the south-east corner. If you are familiar with
    /// [vector tiles](https://github.com/mapbox/vector-tile-spec) it may be helpful to think
    /// of the coordinate space as the `0/0/0` tile with an extent of `1`.
    ///
    /// The `z` dimension of `MercatorPoint` is conformal. A cube in the mercator coordinate space would be rendered as a cube.
    /// </summary>
    public class MercatorPoint : List<double>, ICloneable
    {
        /// <summary>
        /// Constructor for deserialization purposes.
        /// </summary>
        [JsonConstructor]
        public MercatorPoint() { }

        /// <summary>
        /// Initializes a new instance of the MercatorPoint class with the specified X, Y and optional Z coordinates.
        /// </summary>
        /// <param name="x">The X coordinate of the point in Mercator projection units.</param>
        /// <param name="y">The Y coordinate of the point in Mercator projection units.</param>
        /// <param name="z">The Z coordinate of the point in Mercator projection units (optional).</param>
        public MercatorPoint(double x, double y, double? z = null)
        {
            Add(x);
            Add(y); 
            if (z != null)
                Z = z;
        }

        //Not part of the specification, but useful for convenience.
        #region X,Y,Z

        /// <summary>
        /// X coordinate of the point in Mercator projection units.
        /// </summary>
        [JsonIgnore]
        public double X
        {
            get { Verify(); return this[0]; }
            set { Verify(); this[0] = value; }
        }

        /// <summary>
        /// Y coordinate of the point in Mercator projection units.
        /// </summary>
        [JsonIgnore]
        public double Y
        {
            get { Verify(); return this[1]; }
            set { Verify(); this[1] = value; }
        }

        /// <summary>
        /// Z coordinate of the point in Mercator projection units. This is optional and may be null.
        /// </summary>
        [JsonIgnore]
        public double? Z
        {
            get => Count > 2 ? this[2] : null;
            set
            {
                if (value == null)
                {
                    this.EnsureCount(2, 2);
                    return;
                }

                this.EnsureCount(3, 3);

                this[2] = value.Value;
            }
        }

        #endregion

        /// <summary>
        /// Checks if list has the minimum required elements (X,Y); if not adds them.
        /// </summary>
        internal void Verify()
        {
            this.EnsureCount(2);
        }

        /// <summary>
        /// Has X and Y coordinates, but no Z coordinate.
        /// </summary>
        [JsonIgnore] public bool Is2D => Count == 2;

        /// <summary>
        /// Has X, Y and Z coordinates.
        /// </summary>
        [JsonIgnore] public bool Is3D => Count == 3;

        /// <summary>
        /// Position is either 2D or 3D. <see cref="Is2D"/> <see cref="Is3D"/>
        /// </summary>
        [JsonIgnore] public bool IsValid => Is2D || Is3D;

        /// <summary>
        /// Returns a string representation of the MercatorPoint with the specified format.
        /// </summary>
        /// <param name="format">The format string for the coordinates.</param>
        /// <returns>A string representation of the MercatorPoint.</returns>
        public string ToString(string format)
        {
            if (string.IsNullOrWhiteSpace(format))
                return ToString();

            return Is3D
                ? $"[{X.ToString(format)}, {Y.ToString(format)}, {Z!.Value.ToString(format)}]"
                : $"[{X.ToString(format)}, {Y.ToString(format)}]";
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns>A string representation of the MercatorPoint.</returns>
        public override string ToString()
        {
            return Is3D
                ? $"[{X}, {Y}, {Z!.Value}]"
                : $"[{X}, {Y}]";
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var clone = new MercatorPoint();
            clone.AddRange(this);

            return clone;
        }
    }
}

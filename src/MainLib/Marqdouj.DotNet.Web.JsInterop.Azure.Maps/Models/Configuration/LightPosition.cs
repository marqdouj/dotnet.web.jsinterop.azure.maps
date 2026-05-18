using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration
{
    /// <summary>
    /// Position of the light source relative to lit (extruded) geometries,
    /// in [r radial coordinate, a azimuthal angle, p polar angle]
    /// where r indicates the distance from the center of the base of an object to its light,
    /// a indicates the position of the light relative to 0°
    /// (0° when "anchor" is set to viewport corresponds to the top of the viewport,
    /// or 0° when "anchor" is set to map corresponds to due north, and degrees proceed clockwise),
    /// and p indicates the height of the light (from 0°, directly above, to 180°, directly below).
    /// </summary>
    [Display(Name = "light Position")]
    public class LightPosition : List<double>, ICloneable
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonConstructor]
        public LightPosition() {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"><see cref="R"/></param>
        /// <param name="a"><see cref="A"/></param>
        /// <param name="p"><see cref="P"/></param>
        public LightPosition(double r, double a, double p)
        {
            Add(r);
            Add(a);
            Add(p);
        }

        /// <summary>
        /// Radial coordinate
        /// </summary>
        [JsonIgnore]
        public double R
        {
            get { Verify(); return this[0]; }
            set { Verify(); this[0] = value; }
        }

        /// <summary>
        /// Azimuthal angle
        /// </summary>
        [JsonIgnore]
        public double A
        {
            get { Verify(); return this[1]; }
            set { Verify(); this[1] = value; }
        }

        /// <summary>
        /// Polar angle
        /// </summary>
        [JsonIgnore]
        public double P
        {
            get { Verify(); return this[2]; }
            set { Verify(); this[2] = value; }
        }

        /// <summary>
        /// Checks if list has the minimum required elements (R, A, P); if not adds them.
        /// </summary>
        internal void Verify()
        {
            this.EnsureCount(3, 3);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var clone = new LightPosition();
            clone.AddRange(this);

            return clone;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[{R}, {A}, {P}]";
        }
    }
}

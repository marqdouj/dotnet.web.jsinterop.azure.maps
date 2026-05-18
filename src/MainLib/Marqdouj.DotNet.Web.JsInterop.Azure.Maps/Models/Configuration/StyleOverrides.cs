using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Configuration
{
    /// <summary>
    /// Override the default styles for the map elements.​
    /// </summary>
    [Display(Name = "style Overrides")]
    public class StyleOverrides : OptionsBase
    {
        /// <summary>
        /// Country or regions.
        /// </summary>
        [Display(Name = "Country/Region")]
        public BorderedMapElementStyles? CountryRegion { get; set; }

        /// <summary>
        /// First administrative level within the country/region level, such as a state or a province.
        /// </summary>
        [Display(Name = "Admin District")]
        public BorderedMapElementStyles? AdminDistrict { get; set; }

        /// <summary>
        /// Second administrative level within the country/region level, such as a county.​
        /// </summary>
        [Display(Name = "Admin District 2")]
        public BorderedMapElementStyles? AdminDistrict2 { get; set; }

        /// <summary>
        /// Building footprints along with their address numbers.​
        /// </summary>
        [Display(Name = "Building Footprint")]
        public MapElementStyles? BuildingFootprint { get; set; } = null;

        /// <summary>
        /// Street blocks in the populated places​.
        /// </summary>
        [Display(Name = "road Details")]
        public MapElementStyles? RoadDetails { get; set; } = null;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var clone = new StyleOverrides
            {
                CountryRegion = (BorderedMapElementStyles?)CountryRegion?.Clone(),
                AdminDistrict = (BorderedMapElementStyles?)AdminDistrict?.Clone(),
                AdminDistrict2 = (BorderedMapElementStyles?)AdminDistrict2?.Clone(),
                BuildingFootprint = (MapElementStyles?)BuildingFootprint?.Clone(),
                RoadDetails = (MapElementStyles?)RoadDetails?.Clone()
            };

            return clone;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}

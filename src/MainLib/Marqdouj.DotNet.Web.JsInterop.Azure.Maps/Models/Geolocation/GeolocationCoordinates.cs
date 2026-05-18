using Marqdouj.DotNet.Web.JsInterop.GeoJson;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Geolocation
{
    /// <summary>
    /// Geolocation Coordinates, based on <see href="https://developer.mozilla.org/en-US/docs/Web/API/GeolocationCoordinates"/>.
    /// </summary>
    public class GeolocationCoordinates()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="altitude"></param>
        public GeolocationCoordinates(double latitude, double longitude, double? altitude = null): this()
        {
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        public GeolocationCoordinates(Position position) : this(position.Longitude, position.Latitude, position.Elevation)
        {
            
        }

        /// <summary>
        /// Latitude in decimal degrees.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude in decimal degrees.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Altitude in meters, relative to sea level.
        /// </summary>
        public double? Altitude { get; set; }

        /// <summary>
        /// Accuracy of the latitude and longitude properties, in meters.
        /// </summary>
        public double Accuracy { get; set; }

        /// <summary>
        /// Accuracy of the altitude, in meters.
        /// </summary>
        public double? AltitudeAccuracy { get; set; }

        /// <summary>
        /// The direction the device is travelling, in degrees clockwise from true north.
        /// </summary>
        public double? Heading { get; set; }

        /// <summary>
        /// The velocity of the device, in meters per second.
        /// </summary>
        public double? Speed { get; set; }

        /// <summary>
        /// <see cref="Object.ToString"/> using a format specifier.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format)
        {
            if (string.IsNullOrWhiteSpace(format))
                return ToString();

            return Altitude.HasValue
                ? $"[{Longitude.ToString(format)}, {Latitude.ToString(format)}, {Altitude.Value.ToString(format)}]"
                : $"[{Longitude.ToString(format)}, {Latitude.ToString(format)}]";
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Altitude.HasValue
                ? $"[{Longitude}, {Latitude}, {Altitude.Value}]"
                : $"[{Longitude}, {Latitude}]";
        }
    }
}

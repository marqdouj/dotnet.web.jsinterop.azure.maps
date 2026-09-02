using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Interop.Models.Atlas
{
    /// <summary>
    /// Units of measurement for areas.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<AreaUnits>))]
    public enum AreaUnits
    {
        /// <summary>
        /// Represents areas in square meters (m^2).
        /// Literal value "squareMeters"
        /// </summary>
        SquareMeters,

        /// <summary>
        /// Represents areas in acres (ac).
        /// Literal value "acres"
        /// </summary>
        Acres,

        /// <summary>
        /// Represents areas in hectares (ha).
        /// Literal value "hectares"
        /// </summary>
        Hectares,

        /// <summary>
        /// Represents areas in square feet (ft^2).
        /// Literal value "squareFeet"
        /// </summary>
        SquareFeet,

        /// <summary>
        /// Represents areas in square kilometers (km^2).
        /// Literal value "squareKilometers"
        /// </summary>
        SquareKilometers,

        /// <summary>
        /// Represents areas in square miles (mi^2).
        /// Literal value "squareMiles"
        /// </summary>
        SquareMiles,

        /// <summary>
        /// Represents areas in square yards (yds^2).
        /// Literal value "squareYards"
        /// </summary>
        SquareYards
    }

    /// <summary>
    /// Units of measurement for distances.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<DistanceUnits>))]
    public enum DistanceUnits
    {
        /// <summary>
        /// Represents a distance in meters (m).
        /// Literal value "meters"
        /// </summary>
        Meters,

        /// <summary>
        /// Represents a distance in kilometers (km).
        /// Literal value "kilometers"
        /// </summary>
        Kilometers,

        /// <summary>
        /// Represents a distance in feet (ft).
        /// Literal value "feet"
        /// </summary>
        Feet,

        /// <summary>
        /// Represents a distance in miles (mi).
        /// Literal value "miles"
        /// </summary>
        Miles,

        /// <summary>
        /// Represents a distance in nautical miles.
        /// Literal value "nauticalMiles"
        /// </summary>
        NauticalMiles,

        /// <summary>
        /// Represents a distance in yards (yds).
        /// Literal value "yards"
        /// </summary>
        Yards
    }

    /// <summary>
    /// Units of measurement for time.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<TimeUnits>))]
    public enum TimeUnits
    {
        /// <summary>
        /// Represents a time in seconds (s).
        /// Literal value "seconds"
        /// </summary>
        Seconds,

        /// <summary>
        /// Represents a time in hours (hr).
        /// Literal value "hours"
        /// </summary>
        Hours,

        /// <summary>
        /// Represents a time in milliseconds (ms).
        /// Literal value "ms"
        /// </summary>
        Milliseconds,

        /// <summary>
        /// Represents a time in minutes (min).
        /// Literal value "minutes"
        /// </summary>
        Minutes,

        /// <summary>
        /// Represents a time in days (d).
        /// Literal value "days"
        /// </summary>
        Days
    }

    /// <summary>
    /// Units of measurement for speed.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<SpeedUnits>))]
    public enum SpeedUnits
    {
        /// <summary>
        /// Represents a speed in meters per second (m/s).
        /// Literal value "metersPerSecond"
        /// </summary>
        MetersPerSecond,

        /// <summary>
        /// Represents a speed in kilometers per hour (km/h).
        /// Literal value "kilometersPerHour"
        /// </summary>
        KilometersPerHour,

        /// <summary>
        /// Represents a speed in feet per second (ft/s).
        /// Literal value "feetPerSecond"
        /// </summary>
        FeetPerSecond,

        /// <summary>
        /// Represents a speed in miles per hour (mph).
        /// Literal value "milesPerHour"
        /// </summary>
        MilesPerHour,

        /// <summary>
        /// Represents a speed in knots (knts).
        /// Literal value "knots"
        /// </summary>
        Knots,

        /// <summary>
        /// Represents a speed in mach.
        /// Literal value "mach"
        /// </summary>
        Mach
    }

    /// <summary>
    /// Units of measurement for acceleration.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<AccelerationUnits>))]
    public enum AccelerationUnits
    {
        /// <summary>
        /// Represents an acceleration in miles per second squared (mi/s^2).
        /// Literal value "milesPerSecondSquared"
        /// </summary>
        MilesPerSecondSquared,

        /// <summary>
        /// Represents an acceleration in kilometers per second squared (km/s^2).
        /// Literal value "kilometersPerSecondSquared"
        /// </summary>
        KilometersPerSecondSquared,

        /// <summary>
        /// Represents an acceleration in knots per second (knts/s).
        /// Literal value "knotsPerSecond"
        /// </summary>
        KnotsPerSecond,

        /// <summary>
        /// Represents an acceleration in standard gravity units (g).
        /// Literal value "standardGravity"
        /// </summary>
        StandardGravity,

        /// <summary>
        /// Represents an acceleration in feet per second squared (ft/s^2).
        /// Literal value "feetPerSecondSquared"
        /// </summary>
        FeetPerSecondSquared,

        /// <summary>
        /// Represents an acceleration in yards per second squared (yds/s^2).
        /// Literal value "yardsPerSecondSquared"
        /// </summary>
        YardsPerSecondSquared,

        /// <summary>
        /// Represents an acceleration in miles per hour second (mi/h/s).
        /// Literal value "milesPerHourSecond"
        /// </summary>
        MilesPerHourSecond,

        /// <summary>
        /// Represents an acceleration in kilometers per hour second (km/h/s).
        /// Literal value "kilometersPerHourSecond"
        /// </summary>
        KilometersPerHourSecond,

        /// <summary>
        /// Represents an acceleration in meters per second squared (m/s^2).
        /// Literal value "metersPerSecondSquared"
        /// </summary>
        MetersPerSecondSquared
    }
}

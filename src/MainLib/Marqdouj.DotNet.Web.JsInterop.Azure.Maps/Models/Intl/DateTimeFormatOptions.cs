namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Intl
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    /// <summary>
    /// Represents the options for formatting a date/time value, analogous to JavaScript's Intl.DateTimeFormatOptions.
    /// </summary>
    public class DateTimeFormatOptions : ICloneable
    {
        public string? LocaleMatcher { get; set; }
        public string? Weekday { get; set; }
        public string? Era { get; set; }
        public string? Year { get; set; }
        public string? Month { get; set; }
        public string? Day { get; set; }
        public string? Hour { get; set; }
        public string? Minute { get; set; }
        public string? Second { get; set; }
        public string? TimeZoneName { get; set; }
        public string? FormatMatcher { get; set; }
        public bool? Hour12 { get; set; }
        public string? TimeZone { get; set; }
        public string? Calendar { get; set; }
        public string? DayPeriod { get; set; }
        public string? NumberingSystem { get; set; }
        public string? DateStyle { get; set; }
        public string? TimeStyle { get; set; }
        public string? HourCycle { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public object Clone()
        {
            var clone = (DateTimeFormatOptions)MemberwiseClone();
            return clone;
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }

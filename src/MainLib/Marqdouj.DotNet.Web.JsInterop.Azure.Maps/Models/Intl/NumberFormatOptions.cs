using Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Converters;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.Web.JsInterop.Azure.Maps.Models.Intl
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    /// <summary>
    /// Represents the possible values for sign display in number formatting.
    /// </summary>
    [JsonConverter(typeof(MapEnumJsonConverter<NumberFormatOptionsSignDisplay>))]
    public enum NumberFormatOptionsSignDisplay
    {
        Auto,
        Never,
        Always,
        ExceptZero
    }

    /// <summary>
    /// Represents the possible values for compact display.
    /// </summary>
    [JsonConverter(typeof(MapEnumJsonConverter<CompactDisplay>))]
    public enum CompactDisplay
    {
        Short,
        Long
    }

    /// <summary>
    /// Represents the possible values for notation.
    /// </summary>
    [JsonConverter(typeof(MapEnumJsonConverter<Notation>))]
    public enum Notation
    {
        Standard,
        Scientific,
        Engineering,
        Compact
    }

    /// <summary>
    /// Represents the possible values for unit display.
    /// </summary>
    [JsonConverter(typeof(MapEnumJsonConverter<UnitDisplay>))]
    public enum UnitDisplay
    {
        Short,
        Long,
        Narrow
    }

    /// <summary>
    /// Represents the possible values for currency sign.
    /// </summary>
    [JsonConverter(typeof(MapEnumJsonConverter<CurrencySign>))]
    public enum CurrencySign
    {
        Standard,
        Accounting
    }

    /// <summary>
    /// Represents the options for formatting a number, analogous to JavaScript's Intl.NumberFormatOptions.
    /// </summary>
    public class NumberFormatOptions : ICloneable
    {
        public string? LocaleMatcher { get; set; }
        public string? Style { get; set; }
        public string? Currency { get; set; }
        public string? CurrencyDisplay { get; set; }
        public bool? UseGrouping { get; set; }
        public int? MinimumIntegerDigits { get; set; }
        public int? MinimumFractionDigits { get; set; }
        public int? MaximumFractionDigits { get; set; }
        public int? MinimumSignificantDigits { get; set; }
        public int? MaximumSignificantDigits { get; set; }
        public string? RoundingPriority { get; set; }
        public string? RoundingIncrement { get; set; }
        public string? RoundingMode { get; set; }
        public string? TrailingZeroDisplay { get; set; }
        public string? NumberingSystem { get; set; }
        public CompactDisplay? CompactDisplay { get; set; }
        public Notation? Notation { get; set; }
        public NumberFormatOptionsSignDisplay? SignDisplay { get; set; }
        public string? Unit { get; set; }
        public UnitDisplay? UnitDisplay { get; set; }
        public CurrencySign? CurrencySign { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

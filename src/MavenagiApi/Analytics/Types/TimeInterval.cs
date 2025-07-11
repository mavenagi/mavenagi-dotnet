using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<TimeInterval>))]
[Serializable]
public readonly record struct TimeInterval : IStringEnum
{
    public static readonly TimeInterval Hour = new(Values.Hour);

    public static readonly TimeInterval Day = new(Values.Day);

    public static readonly TimeInterval Week = new(Values.Week);

    public static readonly TimeInterval Month = new(Values.Month);

    public static readonly TimeInterval Year = new(Values.Year);

    public TimeInterval(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static TimeInterval FromCustom(string value)
    {
        return new TimeInterval(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(TimeInterval value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TimeInterval value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TimeInterval value) => value.Value;

    public static explicit operator TimeInterval(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Hour = "HOUR";

        public const string Day = "DAY";

        public const string Week = "WEEK";

        public const string Month = "MONTH";

        public const string Year = "YEAR";
    }
}

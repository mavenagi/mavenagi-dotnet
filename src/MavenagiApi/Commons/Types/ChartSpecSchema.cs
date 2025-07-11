using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<ChartSpecSchema>))]
[Serializable]
public readonly record struct ChartSpecSchema : IStringEnum
{
    public static readonly ChartSpecSchema HighchartsTs = new(Values.HighchartsTs);

    public ChartSpecSchema(string value)
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
    public static ChartSpecSchema FromCustom(string value)
    {
        return new ChartSpecSchema(value);
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

    public static bool operator ==(ChartSpecSchema value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ChartSpecSchema value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ChartSpecSchema value) => value.Value;

    public static explicit operator ChartSpecSchema(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string HighchartsTs = "HIGHCHARTS_TS";
    }
}

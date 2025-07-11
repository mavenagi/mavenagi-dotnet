using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<Capability>))]
[Serializable]
public readonly record struct Capability : IStringEnum
{
    public static readonly Capability Markdown = new(Values.Markdown);

    public static readonly Capability Forms = new(Values.Forms);

    public static readonly Capability Images = new(Values.Images);

    public static readonly Capability ChartsHighchartsTs = new(Values.ChartsHighchartsTs);

    public Capability(string value)
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
    public static Capability FromCustom(string value)
    {
        return new Capability(value);
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

    public static bool operator ==(Capability value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Capability value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(Capability value) => value.Value;

    public static explicit operator Capability(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Markdown = "MARKDOWN";

        public const string Forms = "FORMS";

        public const string Images = "IMAGES";

        public const string ChartsHighchartsTs = "CHARTS_HIGHCHARTS_TS";
    }
}

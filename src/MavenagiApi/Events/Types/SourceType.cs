using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<SourceType>))]
[Serializable]
public readonly record struct SourceType : IStringEnum
{
    public static readonly SourceType Web = new(Values.Web);

    public static readonly SourceType Api = new(Values.Api);

    public static readonly SourceType System = new(Values.System);

    public SourceType(string value)
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
    public static SourceType FromCustom(string value)
    {
        return new SourceType(value);
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

    public static bool operator ==(SourceType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(SourceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SourceType value) => value.Value;

    public static explicit operator SourceType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Web = "WEB";

        public const string Api = "API";

        public const string System = "SYSTEM";
    }
}

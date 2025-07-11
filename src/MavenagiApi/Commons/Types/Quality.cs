using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<Quality>))]
[Serializable]
public readonly record struct Quality : IStringEnum
{
    public static readonly Quality Good = new(Values.Good);

    public static readonly Quality NeedsImprovement = new(Values.NeedsImprovement);

    public static readonly Quality Unknown = new(Values.Unknown);

    public Quality(string value)
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
    public static Quality FromCustom(string value)
    {
        return new Quality(value);
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

    public static bool operator ==(Quality value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Quality value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Quality value) => value.Value;

    public static explicit operator Quality(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Good = "GOOD";

        public const string NeedsImprovement = "NEEDS_IMPROVEMENT";

        public const string Unknown = "UNKNOWN";
    }
}

using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<Sentiment>))]
[Serializable]
public readonly record struct Sentiment : IStringEnum
{
    public static readonly Sentiment Positive = new(Values.Positive);

    public static readonly Sentiment Negative = new(Values.Negative);

    public static readonly Sentiment Neutral = new(Values.Neutral);

    public static readonly Sentiment Mixed = new(Values.Mixed);

    public static readonly Sentiment Unknown = new(Values.Unknown);

    public Sentiment(string value)
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
    public static Sentiment FromCustom(string value)
    {
        return new Sentiment(value);
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

    public static bool operator ==(Sentiment value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Sentiment value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Sentiment value) => value.Value;

    public static explicit operator Sentiment(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Positive = "POSITIVE";

        public const string Negative = "NEGATIVE";

        public const string Neutral = "NEUTRAL";

        public const string Mixed = "MIXED";

        public const string Unknown = "UNKNOWN";
    }
}

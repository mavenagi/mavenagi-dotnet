using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<FeedbackType>))]
[Serializable]
public readonly record struct FeedbackType : IStringEnum
{
    public static readonly FeedbackType ThumbsUp = new(Values.ThumbsUp);

    public static readonly FeedbackType ThumbsDown = new(Values.ThumbsDown);

    public static readonly FeedbackType Insert = new(Values.Insert);

    public static readonly FeedbackType Handoff = new(Values.Handoff);

    public FeedbackType(string value)
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
    public static FeedbackType FromCustom(string value)
    {
        return new FeedbackType(value);
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

    public static bool operator ==(FeedbackType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FeedbackType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FeedbackType value) => value.Value;

    public static explicit operator FeedbackType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string ThumbsUp = "THUMBS_UP";

        public const string ThumbsDown = "THUMBS_DOWN";

        public const string Insert = "INSERT";

        public const string Handoff = "HANDOFF";
    }
}

using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<FeedbackField>))]
[Serializable]
public readonly record struct FeedbackField : IStringEnum
{
    public static readonly FeedbackField Type = new(Values.Type);

    public static readonly FeedbackField CreatedBy = new(Values.CreatedBy);

    public static readonly FeedbackField CreatedAt = new(Values.CreatedAt);

    public static readonly FeedbackField App = new(Values.App);

    public FeedbackField(string value)
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
    public static FeedbackField FromCustom(string value)
    {
        return new FeedbackField(value);
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

    public static bool operator ==(FeedbackField value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FeedbackField value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FeedbackField value) => value.Value;

    public static explicit operator FeedbackField(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Type = "Type";

        public const string CreatedBy = "CreatedBy";

        public const string CreatedAt = "CreatedAt";

        public const string App = "App";
    }
}

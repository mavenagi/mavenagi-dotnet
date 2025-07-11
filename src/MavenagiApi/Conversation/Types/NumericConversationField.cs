using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<NumericConversationField>))]
[Serializable]
public readonly record struct NumericConversationField : IStringEnum
{
    public static readonly NumericConversationField ThumbsUpCount = new(Values.ThumbsUpCount);

    public static readonly NumericConversationField ThumbsDownCount = new(Values.ThumbsDownCount);

    public static readonly NumericConversationField InsertCount = new(Values.InsertCount);

    public static readonly NumericConversationField UserMessageCount = new(Values.UserMessageCount);

    public static readonly NumericConversationField HandleTime = new(Values.HandleTime);

    public static readonly NumericConversationField FirstResponseTime = new(
        Values.FirstResponseTime
    );

    public NumericConversationField(string value)
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
    public static NumericConversationField FromCustom(string value)
    {
        return new NumericConversationField(value);
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

    public static bool operator ==(NumericConversationField value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(NumericConversationField value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(NumericConversationField value) => value.Value;

    public static explicit operator NumericConversationField(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string ThumbsUpCount = "ThumbsUpCount";

        public const string ThumbsDownCount = "ThumbsDownCount";

        public const string InsertCount = "InsertCount";

        public const string UserMessageCount = "UserMessageCount";

        public const string HandleTime = "HandleTime";

        public const string FirstResponseTime = "FirstResponseTime";
    }
}

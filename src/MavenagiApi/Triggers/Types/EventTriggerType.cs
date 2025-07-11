using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<EventTriggerType>))]
[Serializable]
public readonly record struct EventTriggerType : IStringEnum
{
    public static readonly EventTriggerType ConversationCreated = new(Values.ConversationCreated);

    public static readonly EventTriggerType FeedbackCreated = new(Values.FeedbackCreated);

    public static readonly EventTriggerType InboxItemCreated = new(Values.InboxItemCreated);

    public EventTriggerType(string value)
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
    public static EventTriggerType FromCustom(string value)
    {
        return new EventTriggerType(value);
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

    public static bool operator ==(EventTriggerType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EventTriggerType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EventTriggerType value) => value.Value;

    public static explicit operator EventTriggerType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string ConversationCreated = "CONVERSATION_CREATED";

        public const string FeedbackCreated = "FEEDBACK_CREATED";

        public const string InboxItemCreated = "INBOX_ITEM_CREATED";
    }
}

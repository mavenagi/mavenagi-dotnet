using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<EntityType>))]
[Serializable]
public readonly record struct EntityType : IStringEnum
{
    public static readonly EntityType Agent = new(Values.Agent);

    public static readonly EntityType Conversation = new(Values.Conversation);

    public static readonly EntityType ConversationMessage = new(Values.ConversationMessage);

    public static readonly EntityType KnowledgeBase = new(Values.KnowledgeBase);

    public static readonly EntityType KnowledgeBaseVersion = new(Values.KnowledgeBaseVersion);

    public static readonly EntityType KnowledgeDocument = new(Values.KnowledgeDocument);

    public static readonly EntityType Action = new(Values.Action);

    public static readonly EntityType User = new(Values.User);

    public static readonly EntityType Event = new(Values.Event);

    public static readonly EntityType EventTrigger = new(Values.EventTrigger);

    public static readonly EntityType UserProfile = new(Values.UserProfile);

    public static readonly EntityType Feedback = new(Values.Feedback);

    public static readonly EntityType InboxItem = new(Values.InboxItem);

    public static readonly EntityType InboxItemFix = new(Values.InboxItemFix);

    public EntityType(string value)
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
    public static EntityType FromCustom(string value)
    {
        return new EntityType(value);
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

    public static bool operator ==(EntityType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(EntityType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EntityType value) => value.Value;

    public static explicit operator EntityType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Agent = "AGENT";

        public const string Conversation = "CONVERSATION";

        public const string ConversationMessage = "CONVERSATION_MESSAGE";

        public const string KnowledgeBase = "KNOWLEDGE_BASE";

        public const string KnowledgeBaseVersion = "KNOWLEDGE_BASE_VERSION";

        public const string KnowledgeDocument = "KNOWLEDGE_DOCUMENT";

        public const string Action = "ACTION";

        public const string User = "USER";

        public const string Event = "EVENT";

        public const string EventTrigger = "EVENT_TRIGGER";

        public const string UserProfile = "USER_PROFILE";

        public const string Feedback = "FEEDBACK";

        public const string InboxItem = "INBOX_ITEM";

        public const string InboxItemFix = "INBOX_ITEM_FIX";
    }
}

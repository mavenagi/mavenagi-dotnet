using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<EntityType>))]
public enum EntityType
{
    [EnumMember(Value = "CONVERSATION")]
    Conversation,

    [EnumMember(Value = "CONVERSATION_MESSAGE")]
    ConversationMessage,

    [EnumMember(Value = "KNOWLEDGE_BASE")]
    KnowledgeBase,

    [EnumMember(Value = "KNOWLEDGE_BASE_VERSION")]
    KnowledgeBaseVersion,

    [EnumMember(Value = "KNOWLEDGE_DOCUMENT")]
    KnowledgeDocument,

    [EnumMember(Value = "ACTION")]
    Action,

    [EnumMember(Value = "USER")]
    User,

    [EnumMember(Value = "EVENT")]
    Event,

    [EnumMember(Value = "EVENT_TRIGGER")]
    EventTrigger,

    [EnumMember(Value = "USER_PROFILE")]
    UserProfile,

    [EnumMember(Value = "FEEDBACK")]
    Feedback,

    [EnumMember(Value = "INBOX_ITEM")]
    InboxItem,

    [EnumMember(Value = "INBOX_ITEM_FIX")]
    InboxItemFix,
}

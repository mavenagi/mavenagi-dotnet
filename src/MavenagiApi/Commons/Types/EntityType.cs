using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

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

    [EnumMember(Value = "KNOWLEDGE_DOCUMENT")]
    KnowledgeDocument,

    [EnumMember(Value = "ACTION")]
    Action,

    [EnumMember(Value = "USER")]
    User,

    [EnumMember(Value = "USER_EVENT")]
    UserEvent,

    [EnumMember(Value = "EVENT_TRIGGER")]
    EventTrigger,

    [EnumMember(Value = "USER_PROFILE")]
    UserProfile,

    [EnumMember(Value = "FEEDBACK")]
    Feedback,
}

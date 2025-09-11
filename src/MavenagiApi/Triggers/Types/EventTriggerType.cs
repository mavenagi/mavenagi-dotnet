using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<EventTriggerType>))]
public enum EventTriggerType
{
    [EnumMember(Value = "CONVERSATION_CREATED")]
    ConversationCreated,

    [EnumMember(Value = "FEEDBACK_CREATED")]
    FeedbackCreated,

    [EnumMember(Value = "INBOX_ITEM_CREATED")]
    InboxItemCreated,

    [EnumMember(Value = "EVENT_CREATED")]
    EventCreated,
}

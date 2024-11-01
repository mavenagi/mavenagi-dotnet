using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<EventTriggerType>))]
public enum EventTriggerType
{
    [EnumMember(Value = "CONVERSATION_CREATED")]
    ConversationCreated,

    [EnumMember(Value = "FEEDBACK_CREATED")]
    FeedbackCreated,
}

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<UserConversationMessageType>))]
public enum UserConversationMessageType
{
    [EnumMember(Value = "USER")]
    User,

    [EnumMember(Value = "HUMAN_AGENT")]
    HumanAgent,

    [EnumMember(Value = "EXTERNAL_SYSTEM")]
    ExternalSystem,
}

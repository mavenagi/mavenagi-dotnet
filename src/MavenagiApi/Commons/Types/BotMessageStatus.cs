using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<BotMessageStatus>))]
public enum BotMessageStatus
{
    [EnumMember(Value = "SENDING")]
    Sending,

    [EnumMember(Value = "SENT")]
    Sent,

    [EnumMember(Value = "REJECTED")]
    Rejected,

    [EnumMember(Value = "CANCELED")]
    Canceled,

    [EnumMember(Value = "FAILED")]
    Failed,

    [EnumMember(Value = "UNKNOWN")]
    Unknown,
}

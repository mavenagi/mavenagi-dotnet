using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<InboxItemStatus>))]
public enum InboxItemStatus
{
    [EnumMember(Value = "OPEN")]
    Open,

    [EnumMember(Value = "USER_RESOLVED")]
    UserResolved,

    [EnumMember(Value = "SYSTEM_RESOLVED")]
    SystemResolved,

    [EnumMember(Value = "REGRESSED")]
    Regressed,

    [EnumMember(Value = "IGNORED")]
    Ignored,
}

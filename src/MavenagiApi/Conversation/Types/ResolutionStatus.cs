using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<ResolutionStatus>))]
public enum ResolutionStatus
{
    [EnumMember(Value = "RESOLVED")]
    Resolved,

    [EnumMember(Value = "ESCALATED")]
    Escalated,

    [EnumMember(Value = "IN_PROGRESS")]
    InProgress,
}

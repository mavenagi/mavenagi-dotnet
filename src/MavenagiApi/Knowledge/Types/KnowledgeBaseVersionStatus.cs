using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<KnowledgeBaseVersionStatus>))]
public enum KnowledgeBaseVersionStatus
{
    [EnumMember(Value = "SUCCEEDED")]
    Succeeded,

    [EnumMember(Value = "FAILED")]
    Failed,

    [EnumMember(Value = "IN_PROGRESS")]
    InProgress,
}

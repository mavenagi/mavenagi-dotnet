using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<KnowledgeBaseVersionFinalizeStatus>))]
public enum KnowledgeBaseVersionFinalizeStatus
{
    [EnumMember(Value = "SUCCEEDED")]
    Succeeded,

    [EnumMember(Value = "FAILED")]
    Failed,
}

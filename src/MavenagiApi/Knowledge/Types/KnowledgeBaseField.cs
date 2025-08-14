using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<KnowledgeBaseField>))]
public enum KnowledgeBaseField
{
    [EnumMember(Value = "Title")]
    Title,

    [EnumMember(Value = "UpdatedAt")]
    UpdatedAt,
}

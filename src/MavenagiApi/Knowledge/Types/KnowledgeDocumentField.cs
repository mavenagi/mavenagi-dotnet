using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<KnowledgeDocumentField>))]
public enum KnowledgeDocumentField
{
    [EnumMember(Value = "Title")]
    Title,

    [EnumMember(Value = "CreatedAt")]
    CreatedAt,

    [EnumMember(Value = "UpdatedAt")]
    UpdatedAt,

    [EnumMember(Value = "Language")]
    Language,
}

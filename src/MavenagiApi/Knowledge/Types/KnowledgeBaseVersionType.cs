using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<KnowledgeBaseVersionType>))]
public enum KnowledgeBaseVersionType
{
    [EnumMember(Value = "FULL")]
    Full,

    [EnumMember(Value = "PARTIAL")]
    Partial,
}

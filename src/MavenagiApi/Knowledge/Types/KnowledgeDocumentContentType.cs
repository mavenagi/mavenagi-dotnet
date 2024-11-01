using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<KnowledgeDocumentContentType>))]
public enum KnowledgeDocumentContentType
{
    [EnumMember(Value = "HTML")]
    Html,

    [EnumMember(Value = "MARKDOWN")]
    Markdown,
}

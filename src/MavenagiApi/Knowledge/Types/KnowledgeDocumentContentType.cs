using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<KnowledgeDocumentContentType>))]
public enum KnowledgeDocumentContentType
{
    [EnumMember(Value = "HTML")]
    Html,

    [EnumMember(Value = "MARKDOWN")]
    Markdown,
}

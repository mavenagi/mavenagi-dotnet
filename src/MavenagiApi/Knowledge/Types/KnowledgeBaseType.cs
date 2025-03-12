using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<KnowledgeBaseType>))]
public enum KnowledgeBaseType
{
    [EnumMember(Value = "API")]
    Api,

    [EnumMember(Value = "URL")]
    Url,

    [EnumMember(Value = "RSS")]
    Rss,
}

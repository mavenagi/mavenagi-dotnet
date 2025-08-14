using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<KnowledgeBaseRefreshFrequency>))]
public enum KnowledgeBaseRefreshFrequency
{
    [EnumMember(Value = "NONE")]
    None,

    [EnumMember(Value = "DAILY")]
    Daily,

    [EnumMember(Value = "WEEKLY")]
    Weekly,

    [EnumMember(Value = "MONTHLY")]
    Monthly,
}

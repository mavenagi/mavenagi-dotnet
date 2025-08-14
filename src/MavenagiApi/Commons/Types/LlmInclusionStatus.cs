using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<LlmInclusionStatus>))]
public enum LlmInclusionStatus
{
    [EnumMember(Value = "ALWAYS")]
    Always,

    [EnumMember(Value = "WHEN_RELEVANT")]
    WhenRelevant,

    [EnumMember(Value = "NEVER")]
    Never,
}

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<UserMessageResponseState>))]
public enum UserMessageResponseState
{
    [EnumMember(Value = "NOT_ASKED")]
    NotAsked,

    [EnumMember(Value = "LLM_ENABLED")]
    LlmEnabled,

    [EnumMember(Value = "LLM_DISABLED")]
    LlmDisabled,
}

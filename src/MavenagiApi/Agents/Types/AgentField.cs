using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<AgentField>))]
public enum AgentField
{
    [EnumMember(Value = "CREATED_AT")]
    CreatedAt,

    [EnumMember(Value = "ENVIRONMENT")]
    Environment,
}

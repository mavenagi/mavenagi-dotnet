using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<AgentUserField>))]
public enum AgentUserField
{
    [EnumMember(Value = "CreatedAt")]
    CreatedAt,

    [EnumMember(Value = "UpdatedAt")]
    UpdatedAt,
}

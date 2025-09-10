using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<AgentCapabilityField>))]
public enum AgentCapabilityField
{
    [EnumMember(Value = "CreatedAt")]
    CreatedAt,

    [EnumMember(Value = "Enabled")]
    Enabled,

    [EnumMember(Value = "Name")]
    Name,

    [EnumMember(Value = "Type")]
    Type,

    [EnumMember(Value = "UserInteractionRequired")]
    UserInteractionRequired,
}

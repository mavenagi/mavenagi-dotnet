using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<AgentCapabilityType>))]
public enum AgentCapabilityType
{
    [EnumMember(Value = "ACTION")]
    Action,

    [EnumMember(Value = "TRIGGER")]
    Trigger,
}

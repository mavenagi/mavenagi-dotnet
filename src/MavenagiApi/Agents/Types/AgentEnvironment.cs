using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<AgentEnvironment>))]
public enum AgentEnvironment
{
    [EnumMember(Value = "DEMO")]
    Demo,

    [EnumMember(Value = "STAGING")]
    Staging,

    [EnumMember(Value = "PRODUCTION")]
    Production,
}

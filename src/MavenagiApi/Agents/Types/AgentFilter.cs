using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record AgentFilter
{
    /// <summary>
    /// The environment of the agent.
    /// </summary>
    [JsonPropertyName("environment")]
    public AgentEnvironment? Environment { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

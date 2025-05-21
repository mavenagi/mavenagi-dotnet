using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record Agent
{
    /// <summary>
    /// ID that uniquely identifies this action
    /// </summary>
    [JsonPropertyName("agentId")]
    public required EntityId AgentId { get; set; }

    /// <summary>
    /// The name of the agent.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// When the agent was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The environment of the agent. Default is `DEMO`.
    /// </summary>
    [JsonPropertyName("environment")]
    public required AgentEnvironment Environment { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

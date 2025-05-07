using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record AppSettings
{
    /// <summary>
    /// The ID of an organization.
    /// </summary>
    [JsonPropertyName("organizationId")]
    public required string OrganizationId { get; set; }

    /// <summary>
    /// The ID of an agent.
    /// </summary>
    [JsonPropertyName("agentId")]
    public required string AgentId { get; set; }

    /// <summary>
    /// The settings that were set during installation.
    /// </summary>
    [JsonPropertyName("settings")]
    public object Settings { get; set; } = new Dictionary<string, object?>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record EntityId
{
    /// <summary>
    /// The object type
    /// </summary>
    [JsonPropertyName("type")]
    public required EntityType Type { get; set; }

    /// <summary>
    /// The ID of the application that created this object
    /// </summary>
    [JsonPropertyName("appId")]
    public required string AppId { get; set; }

    /// <summary>
    /// The ID of the organization that this object belongs too
    /// </summary>
    [JsonPropertyName("organizationId")]
    public required string OrganizationId { get; set; }

    /// <summary>
    /// The ID of the agent that this object belongs too
    /// </summary>
    [JsonPropertyName("agentId")]
    public required string AgentId { get; set; }

    /// <summary>
    /// Externally supplied ID to uniquely identify this object. Is globally unique when combined with all other entityId fields (type, appId, organizationId, agentId)
    /// </summary>
    [JsonPropertyName("referenceId")]
    public required string ReferenceId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

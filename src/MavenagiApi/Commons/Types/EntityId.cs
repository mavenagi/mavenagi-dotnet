using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

/// <summary>
/// A fully specified object ID, unique across the entire system.
/// </summary>
[Serializable]
public record EntityId : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the organization that this object belongs to
    /// </summary>
    [JsonPropertyName("organizationId")]
    public required string OrganizationId { get; set; }

    /// <summary>
    /// The ID of the agent that this object belongs to
    /// </summary>
    [JsonPropertyName("agentId")]
    public required string AgentId { get; set; }

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
    /// Externally supplied ID to uniquely identify this object. Is globally unique when combined with all other entityId fields (type, appId, organizationId, agentId)
    /// </summary>
    [JsonPropertyName("referenceId")]
    public required string ReferenceId { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record TriggerCapability
{
    [JsonPropertyName("triggerType")]
    public required TriggerType TriggerType { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Timestamp when the capability was created
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Whether this capability will be called by Maven.
    /// </summary>
    [JsonPropertyName("enabled")]
    public required bool Enabled { get; set; }

    [JsonPropertyName("version")]
    public required int Version { get; set; }

    /// <summary>
    /// ID that uniquely identifies this capability
    /// </summary>
    [JsonPropertyName("capabilityId")]
    public required EntityId CapabilityId { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

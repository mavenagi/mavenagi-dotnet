using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

/// <summary>
/// The organizationId and agentId are inferred from the context.
/// </summary>
[Serializable]
public record EntityIdWithoutAgent
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
    /// Externally supplied ID to uniquely identify this object. Is globally unique when combined with all other entityId fields (type, appId, organizationId, agentId)
    /// </summary>
    [JsonPropertyName("referenceId")]
    public required string ReferenceId { get; set; }

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

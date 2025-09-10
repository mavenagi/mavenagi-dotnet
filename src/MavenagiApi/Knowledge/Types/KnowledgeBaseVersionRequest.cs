using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record KnowledgeBaseVersionRequest
{
    /// <summary>
    /// Indicates whether the completed version constitutes a full or partial refresh of the knowledge base. Deleting and updating documents is only supported for partial refreshes.
    /// </summary>
    [JsonPropertyName("type")]
    public required KnowledgeBaseVersionType Type { get; set; }

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

using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record KnowledgeBaseRequest
{
    /// <summary>
    /// ID that uniquely identifies this knowledge base
    /// </summary>
    [JsonPropertyName("knowledgeBaseId")]
    public required EntityIdBase KnowledgeBaseId { get; set; }

    /// <summary>
    /// Metadata for the knowledge base.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }

    /// <summary>
    /// The name of the knowledge base
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The preconditions that must be met for knowledge base be relevant to a conversation. Can be used to restrict knowledge bases to certain types of users.
    /// </summary>
    [JsonPropertyName("precondition")]
    public object? Precondition { get; set; }

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

using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record KnowledgeBaseResponse
{
    /// <summary>
    /// ID that uniquely identifies this knowledge base
    /// </summary>
    [JsonPropertyName("knowledgeBaseId")]
    public required EntityId KnowledgeBaseId { get; set; }

    /// <summary>
    /// ID of the knowledge base version that is currently active. Documents can be fetched using this version ID.
    /// </summary>
    [JsonPropertyName("activeVersionId")]
    public EntityId? ActiveVersionId { get; set; }

    /// <summary>
    /// The type of the knowledge base. Can not be changed once created.
    /// </summary>
    [JsonPropertyName("type")]
    public required KnowledgeBaseType Type { get; set; }

    /// <summary>
    /// Metadata for the knowledge base.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();

    /// <summary>
    /// The tags of the knowledge base.
    /// </summary>
    [JsonPropertyName("tags")]
    public HashSet<string> Tags { get; set; } = new HashSet<string>();

    /// <summary>
    /// Determines whether documents in the knowledge base are sent to the LLM as part of a conversation.
    /// </summary>
    [JsonPropertyName("llmInclusionStatus")]
    public LlmInclusionStatus? LlmInclusionStatus { get; set; }

    /// <summary>
    /// How often the knowledge base should be refreshed.
    /// </summary>
    [JsonPropertyName("refreshFrequency")]
    public required KnowledgeBaseRefreshFrequency RefreshFrequency { get; set; }

    /// <summary>
    /// The IDs of the segment that must be matched for the knowledge base to be relevant to a conversation.
    /// Segments are replacing inline preconditions - a Knowledge Base may not have both an inline precondition and a segment.
    /// Inline precondition support will be removed in a future release.
    /// </summary>
    [JsonPropertyName("segmentId")]
    public EntityId? SegmentId { get; set; }

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

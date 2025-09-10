using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record KnowledgeBasePatchRequest
{
    /// <summary>
    /// The App ID of the knowledge base to patch. If not provided the ID of the calling app will be used.
    /// </summary>
    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    /// <summary>
    /// The name of the knowledge base.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The tags of the knowledge base.
    /// </summary>
    [JsonPropertyName("tags")]
    public HashSet<string>? Tags { get; set; }

    /// <summary>
    /// Determines whether documents in the knowledge base are sent to the LLM as part of a conversation. Note that at this time knowledge bases can not be set to `ALWAYS`.
    /// </summary>
    [JsonPropertyName("llmInclusionStatus")]
    public LlmInclusionStatus? LlmInclusionStatus { get; set; }

    /// <summary>
    /// The preconditions that must be met for a knowledge base to be relevant to a conversation. Can be used to restrict knowledge bases to certain types of users. A null value will remove the precondition from the knowledge base, it will be available on all conversations.
    /// </summary>
    [JsonPropertyName("precondition")]
    public object? Precondition { get; set; }

    /// <summary>
    /// The ID of the segment that must be matched for the knowledge base to be relevant to a conversation.
    /// A null value will remove the segment from the knowledge base, it will be available on all conversations.
    ///
    /// Segments are replacing inline preconditions - a knowledge base may not have both an inline precondition and a segment.
    /// Inline precondition support will be removed in a future release.
    /// </summary>
    [JsonPropertyName("segmentId")]
    public EntityId? SegmentId { get; set; }

    /// <summary>
    /// How often the knowledge base should be refreshed.
    /// </summary>
    [JsonPropertyName("refreshFrequency")]
    public KnowledgeBaseRefreshFrequency? RefreshFrequency { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ActionPatchRequest
{
    /// <summary>
    /// The App ID of the action to patch. If not provided the ID of the calling app will be used.
    /// </summary>
    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    /// <summary>
    /// The instructions given to the LLM when determining whether to execute the action.
    /// </summary>
    [JsonPropertyName("instructions")]
    public string? Instructions { get; set; }

    /// <summary>
    /// Determines whether the action is sent to the LLM as part of a conversation.
    /// </summary>
    [JsonPropertyName("llmInclusionStatus")]
    public LlmInclusionStatus? LlmInclusionStatus { get; set; }

    /// <summary>
    /// The ID of the segment that must be matched for the action to be relevant to a conversation.
    /// A null value will remove the segment from the action, it will be available on all conversations.
    ///
    /// Segments are replacing inline preconditions - an action may not have both an inline precondition and a segment.
    /// Inline precondition support will be removed in a future release.
    /// </summary>
    [JsonPropertyName("segmentId")]
    public EntityId? SegmentId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

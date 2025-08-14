using System.Text.Json;
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
    /// How often the knowledge base should be refreshed.
    /// </summary>
    [JsonPropertyName("refreshFrequency")]
    public KnowledgeBaseRefreshFrequency? RefreshFrequency { get; set; }

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

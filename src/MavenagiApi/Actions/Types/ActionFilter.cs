using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ActionFilter
{
    /// <summary>
    /// Filter by instructions
    /// </summary>
    [JsonPropertyName("instructions")]
    public string? Instructions { get; set; }

    /// <summary>
    /// Filter by LLM inclusion status
    /// </summary>
    [JsonPropertyName("llmInclusionStatuses")]
    public IEnumerable<LlmInclusionStatus>? LlmInclusionStatuses { get; set; }

    /// <summary>
    /// Filter by app IDs
    /// </summary>
    [JsonPropertyName("appIds")]
    public IEnumerable<string>? AppIds { get; set; }

    /// <summary>
    /// Filter by user interaction required
    /// </summary>
    [JsonPropertyName("userInteractionRequired")]
    public bool? UserInteractionRequired { get; set; }

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

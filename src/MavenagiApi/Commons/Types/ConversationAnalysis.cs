using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ConversationAnalysis : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Generated user request summary of the conversation
    /// </summary>
    [JsonPropertyName("userRequest")]
    public string? UserRequest { get; set; }

    /// <summary>
    /// Generated agent response summary of the conversation
    /// </summary>
    [JsonPropertyName("agentResponse")]
    public string? AgentResponse { get; set; }

    /// <summary>
    /// Generated resolution status of the conversation
    /// </summary>
    [JsonPropertyName("resolutionStatus")]
    public string? ResolutionStatus { get; set; }

    /// <summary>
    /// Generated category of the conversation
    /// </summary>
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    /// <summary>
    /// Generated sentiment of the conversation
    /// </summary>
    [JsonPropertyName("sentiment")]
    public Sentiment? Sentiment { get; set; }

    /// <summary>
    /// Generated quality of the conversation
    /// </summary>
    [JsonPropertyName("quality")]
    public Quality? Quality { get; set; }

    /// <summary>
    /// If the quality of the conversation is `UNKNOWN` or `NEEDS_IMPROVEMENT` then a reason for the quality will be provided when possible.
    /// </summary>
    [JsonPropertyName("qualityReason")]
    public QualityReason? QualityReason { get; set; }

    /// <summary>
    /// Whether the conversation was resolved by Maven
    /// </summary>
    [JsonPropertyName("resolvedByMaven")]
    public bool? ResolvedByMaven { get; set; }

    /// <summary>
    /// Primary language of the conversation in ISO 639-1 code format
    /// </summary>
    [JsonPropertyName("primaryLanguage")]
    public string? PrimaryLanguage { get; set; }

    /// <summary>
    /// The predicted NPS of the conversation.
    /// </summary>
    [JsonPropertyName("predictedNps")]
    public double? PredictedNps { get; set; }

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

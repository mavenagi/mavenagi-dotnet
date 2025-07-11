using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ConversationFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Full-text search query for matching conversations by content. When you search with this parameter, you're performing a full-text search across all textual content in the conversations, including both the user's messages and the AI's responses.
    /// </summary>
    [JsonPropertyName("search")]
    public string? Search { get; set; }

    /// <summary>
    /// Filter conversations created on or after this timestamp
    /// </summary>
    [JsonPropertyName("createdAfter")]
    public DateTime? CreatedAfter { get; set; }

    /// <summary>
    /// Filter conversations created on or before this timestamp
    /// </summary>
    [JsonPropertyName("createdBefore")]
    public DateTime? CreatedBefore { get; set; }

    /// <summary>
    /// Filter by app IDs
    /// </summary>
    [JsonPropertyName("apps")]
    public IEnumerable<string>? Apps { get; set; }

    /// <summary>
    /// Filter by conversation categories
    /// </summary>
    [JsonPropertyName("categories")]
    public IEnumerable<string>? Categories { get; set; }

    /// <summary>
    /// Filter by actions that were executed in the conversation
    /// </summary>
    [JsonPropertyName("actions")]
    public IEnumerable<EntityIdFilter>? Actions { get; set; }

    /// <summary>
    /// Filter by actions that were suggested but not completed by the AI agent
    /// </summary>
    [JsonPropertyName("incompleteActions")]
    public IEnumerable<EntityIdFilter>? IncompleteActions { get; set; }

    /// <summary>
    /// Filter by user feedback types received in the conversation
    /// </summary>
    [JsonPropertyName("feedback")]
    public IEnumerable<FeedbackType>? Feedback { get; set; }

    /// <summary>
    /// Filter by human agents who participated in the conversation
    /// </summary>
    [JsonPropertyName("humanAgents")]
    public IEnumerable<string>? HumanAgents { get; set; }

    /// <summary>
    /// Filter by human agents who inserted a maven AI generated suggestion in the conversation
    /// </summary>
    [JsonPropertyName("humanAgentsWithInserts")]
    public IEnumerable<string>? HumanAgentsWithInserts { get; set; }

    /// <summary>
    /// Filter by conversation languages
    /// </summary>
    [JsonPropertyName("languages")]
    public IEnumerable<string>? Languages { get; set; }

    /// <summary>
    /// Filter by AI assessed conversation quality classification
    /// </summary>
    [JsonPropertyName("quality")]
    public IEnumerable<Quality>? Quality { get; set; }

    /// <summary>
    /// Filter by AI assessed quality reason classification
    /// </summary>
    [JsonPropertyName("qualityReason")]
    public IEnumerable<QualityReason>? QualityReason { get; set; }

    /// <summary>
    /// Filter by AI response length classification
    /// </summary>
    [JsonPropertyName("responseLength")]
    public IEnumerable<ResponseLength>? ResponseLength { get; set; }

    /// <summary>
    /// Filter by AI assessed sentiment analysis
    /// </summary>
    [JsonPropertyName("sentiment")]
    public IEnumerable<Sentiment>? Sentiment { get; set; }

    /// <summary>
    /// Filter by tags applied to the conversation
    /// </summary>
    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    /// <summary>
    /// Filter by conversation resolution status which is determined by AI based on the conversation content.
    /// </summary>
    [JsonPropertyName("resolutionStatus")]
    public IEnumerable<ResolutionStatus>? ResolutionStatus { get; set; }

    /// <summary>
    /// Filter conversations based on whether they were resolved by Maven AI
    /// </summary>
    [JsonPropertyName("resolvedByMaven")]
    public bool? ResolvedByMaven { get; set; }

    /// <summary>
    /// Filter by the number of messages sent by the user in the conversation
    /// </summary>
    [JsonPropertyName("userMessageCount")]
    public NumberRange? UserMessageCount { get; set; }

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

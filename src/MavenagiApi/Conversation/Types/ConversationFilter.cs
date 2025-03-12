using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record ConversationFilter
{
    [JsonPropertyName("search")]
    public string? Search { get; set; }

    [JsonPropertyName("createdAfter")]
    public DateTime? CreatedAfter { get; set; }

    [JsonPropertyName("createdBefore")]
    public DateTime? CreatedBefore { get; set; }

    [JsonPropertyName("apps")]
    public IEnumerable<string>? Apps { get; set; }

    [JsonPropertyName("categories")]
    public IEnumerable<string>? Categories { get; set; }

    [JsonPropertyName("actions")]
    public IEnumerable<EntityIdFilter>? Actions { get; set; }

    [JsonPropertyName("incompleteActions")]
    public IEnumerable<EntityIdFilter>? IncompleteActions { get; set; }

    [JsonPropertyName("feedback")]
    public IEnumerable<FeedbackType>? Feedback { get; set; }

    [JsonPropertyName("humanAgents")]
    public IEnumerable<string>? HumanAgents { get; set; }

    [JsonPropertyName("languages")]
    public IEnumerable<string>? Languages { get; set; }

    [JsonPropertyName("quality")]
    public IEnumerable<Quality>? Quality { get; set; }

    [JsonPropertyName("qualityReason")]
    public IEnumerable<QualityReason>? QualityReason { get; set; }

    [JsonPropertyName("responseLength")]
    public IEnumerable<ResponseLength>? ResponseLength { get; set; }

    [JsonPropertyName("sentiment")]
    public IEnumerable<Sentiment>? Sentiment { get; set; }

    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    [JsonPropertyName("resolutionStatus")]
    public IEnumerable<ResolutionStatus>? ResolutionStatus { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ConversationDateHistogramRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Time-based grouping interval (e.g., HOUR, DAY, WEEK) for the date histogram.
    /// </summary>
    [JsonPropertyName("timeInterval")]
    public required TimeInterval TimeInterval { get; set; }

    /// <summary>
    /// Groups data before applying calculations, forming a separate time series for each group.
    /// </summary>
    [JsonPropertyName("groupBy")]
    public ConversationGroupBy? GroupBy { get; set; }

    /// <summary>
    /// Defines the y-axis values for the date histogram.
    /// </summary>
    [JsonPropertyName("metric")]
    public required ConversationMetric Metric { get; set; }

    /// <summary>
    /// Optional filter applied to refine the conversation data before processing.
    /// </summary>
    [JsonPropertyName("conversationFilter")]
    public ConversationFilter? ConversationFilter { get; set; }

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

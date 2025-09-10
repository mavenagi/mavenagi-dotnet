using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ConversationDateHistogramRequest
{
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
    public required object Metric { get; set; }

    /// <summary>
    /// Optional filter applied to refine the conversation data before processing.
    /// </summary>
    [JsonPropertyName("conversationFilter")]
    public ConversationFilter? ConversationFilter { get; set; }

    /// <summary>
    /// IANA timezone identifier (e.g., "America/Los_Angeles").
    /// When provided, time-based groupings (e.g., DAY) and date filters are evaluated in this timezone;
    /// otherwise UTC is used.
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

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

using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ConversationBarChartRequest
{
    /// <summary>
    /// Determines how data is grouped along the x-axis. Each unique value forms a separate bar.
    /// The name of the bar is derived from the grouping field's value or range.
    /// </summary>
    [JsonPropertyName("barDefinition")]
    public required ConversationGroupBy BarDefinition { get; set; }

    /// <summary>
    /// Metric defining the y-axis values for the bar chart.
    /// </summary>
    [JsonPropertyName("metric")]
    public required object Metric { get; set; }

    /// <summary>
    /// Optionally defines vertical grouping within each bar, producing multiple series.
    /// If omitted, a single series is generated.
    /// </summary>
    [JsonPropertyName("verticalGrouping")]
    public ConversationGroupBy? VerticalGrouping { get; set; }

    /// <summary>
    /// Optional filter applied to refine the conversation data before processing.
    /// </summary>
    [JsonPropertyName("conversationFilter")]
    public ConversationFilter? ConversationFilter { get; set; }

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

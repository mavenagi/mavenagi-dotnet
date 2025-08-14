using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ConversationPieChartRequest
{
    /// <summary>
    /// Field used to group data into slices for the pie chart.
    /// </summary>
    [JsonPropertyName("groupBy")]
    public required ConversationGroupBy GroupBy { get; set; }

    /// <summary>
    /// Metric defining the value for each pie slice, stored in the y-axis value.
    /// </summary>
    [JsonPropertyName("metric")]
    public required object Metric { get; set; }

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

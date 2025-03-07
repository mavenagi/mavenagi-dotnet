using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record PieChartRequest
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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

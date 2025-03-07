using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record PieChartResponse
{
    /// <summary>
    /// The dataset for the pie chart.
    /// Each slice in the pie chart is represented as a data point with a name and a corresponding y-value.
    /// </summary>
    [JsonPropertyName("series")]
    public required Series Series { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

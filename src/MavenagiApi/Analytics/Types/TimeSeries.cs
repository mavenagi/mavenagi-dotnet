using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record TimeSeries
{
    /// <summary>
    /// Name of the series, derived from the grouping field or percentile metric.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// List of time-based data points for the series.
    /// </summary>
    [JsonPropertyName("data")]
    public IEnumerable<TimeDataPoint> Data { get; set; } = new List<TimeDataPoint>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record DateHistogramResponse
{
    /// <summary>
    /// The dataset for the date histogram.
    /// Each series represents a separate plottable time series.
    /// Series names reflect the grouping field values.
    /// </summary>
    [JsonPropertyName("timeSeries")]
    public IEnumerable<TimeSeries> TimeSeries { get; set; } = new List<TimeSeries>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

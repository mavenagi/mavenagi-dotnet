using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record Series
{
    /// <summary>
    /// The name of the series, derived from the grouping field.
    /// If the metric is a percentile, the name represents the percentile value.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// List of labeled data points for the series.
    /// </summary>
    [JsonPropertyName("data")]
    public IEnumerable<LabeledPoint> Data { get; set; } = new List<LabeledPoint>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

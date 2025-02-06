using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record Percentile
{
    /// <summary>
    /// List of percentiles to calculate. Example: [25, 50, 75] computes the 25th, 50th, and 75th percentiles.
    /// </summary>
    [JsonPropertyName("percentiles")]
    public IEnumerable<double> Percentiles { get; set; } = new List<double>();

    /// <summary>
    /// Field to apply the metric to. The field should be numeric for all metrics except for Count (no field) and DistinctCount.
    /// </summary>
    [JsonPropertyName("targetField")]
    public required ConversationField TargetField { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

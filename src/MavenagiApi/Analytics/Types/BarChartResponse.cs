using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record BarChartResponse
{
    /// <summary>
    /// Each LabeledPoint in the series represents a value for the bar, where the name serves as the bar's label.
    /// If vertical grouping is defined, multiple series will be created, each representing a group.
    /// In such cases, the bars can be stacked to reflect the grouped data distribution.
    /// </summary>
    [JsonPropertyName("series")]
    public IEnumerable<Series> Series { get; set; } = new List<Series>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

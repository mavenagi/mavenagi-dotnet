using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record BarChartResponse
{
    /// <summary>
    /// Each LabeledPoint in the series represents a value for the bar, where the name serves as the bar's label.
    /// If vertical grouping is defined, multiple series will be created, each representing a group.
    /// In such cases, the bars can be stacked to reflect the grouped data distribution.
    /// </summary>
    [JsonPropertyName("series")]
    public IEnumerable<Series> Series { get; set; } = new List<Series>();

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

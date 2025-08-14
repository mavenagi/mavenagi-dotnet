using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record DateHistogramResponse
{
    /// <summary>
    /// The dataset for the date histogram.
    /// Each series represents a separate plottable time series.
    /// Series names reflect the grouping field values.
    /// </summary>
    [JsonPropertyName("timeSeries")]
    public IEnumerable<TimeSeries> TimeSeries { get; set; } = new List<TimeSeries>();

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

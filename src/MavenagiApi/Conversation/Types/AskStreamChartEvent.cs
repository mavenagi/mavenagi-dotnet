using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record AskStreamChartEvent
{
    /// <summary>
    /// The label of the chart
    /// </summary>
    [JsonPropertyName("label")]
    public required string Label { get; set; }

    [JsonPropertyName("specSchema")]
    public required ChartSpecSchema SpecSchema { get; set; }

    /// <summary>
    /// The spec string for the chart. For HIGHCHARTS_TS charts, the spec is the json object that represents the chart options.
    /// </summary>
    [JsonPropertyName("spec")]
    public required string Spec { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

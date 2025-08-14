using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

/// <summary>
/// Will only be provided if the responseConfig contains the charts_highcharts_ts capability.
/// </summary>
[Serializable]
public record BotChartResponse
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

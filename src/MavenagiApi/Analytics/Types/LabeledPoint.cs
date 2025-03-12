using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record LabeledPoint
{
    /// <summary>
    /// Label for the data point corresponding to the y-value.
    /// </summary>
    [JsonPropertyName("label")]
    public required string Label { get; set; }

    /// <summary>
    /// Value of the data point.
    /// </summary>
    [JsonPropertyName("y")]
    public required double Y { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

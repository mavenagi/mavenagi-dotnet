using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record TimeDataPoint
{
    /// <summary>
    /// X-axis value representing time in epoch milliseconds.
    /// </summary>
    [JsonPropertyName("x")]
    public required long X { get; set; }

    /// <summary>
    /// Y-axis value representing the measured data.
    /// </summary>
    [JsonPropertyName("y")]
    public required double Y { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

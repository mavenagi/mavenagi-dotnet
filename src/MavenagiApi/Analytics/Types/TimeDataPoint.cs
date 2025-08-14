using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
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

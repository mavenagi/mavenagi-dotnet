using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record Range
{
    /// <summary>
    /// Lower bound of the range (inclusive).
    /// </summary>
    [JsonPropertyName("from")]
    public double? From { get; set; }

    /// <summary>
    /// Upper bound of the range (exclusive).
    /// </summary>
    [JsonPropertyName("to")]
    public double? To { get; set; }

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

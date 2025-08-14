using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

/// <summary>
/// A range of numbers that can be used to filter search results by numeric fields.
/// - `greaterThanOrEqual`: The minimum value (inclusive).
/// - `lessThan`: The maximum value (exclusive).
/// </summary>
[Serializable]
public record NumberRange
{
    [JsonPropertyName("greaterThanOrEqual")]
    public int? GreaterThanOrEqual { get; set; }

    [JsonPropertyName("lessThan")]
    public int? LessThan { get; set; }

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

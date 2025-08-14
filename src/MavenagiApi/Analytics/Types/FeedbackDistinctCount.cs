using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

/// <summary>
/// Calculates the number of unique values in the specified field.
/// Supports fields with list values as well.
/// </summary>
[Serializable]
public record FeedbackDistinctCount
{
    /// <summary>
    /// All the distinct values of this field will be counted.
    /// </summary>
    [JsonPropertyName("targetField")]
    public required FeedbackField TargetField { get; set; }

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

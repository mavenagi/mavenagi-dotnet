using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

/// <summary>
/// Calculates specified percentile for a numeric field.
/// </summary>
[Serializable]
public record ConversationPercentile
{
    /// <summary>
    /// The percentile to calculate. Example: 25 computes the 25th percentile.
    /// </summary>
    [JsonPropertyName("percentile")]
    public required double Percentile { get; set; }

    /// <summary>
    /// Numeric field to apply the metric to.
    /// </summary>
    [JsonPropertyName("targetField")]
    public required NumericConversationField TargetField { get; set; }

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

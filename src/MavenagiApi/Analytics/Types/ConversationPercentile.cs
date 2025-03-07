using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

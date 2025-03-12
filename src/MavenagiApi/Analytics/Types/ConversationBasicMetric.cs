using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record ConversationBasicMetric
{
    /// <summary>
    /// Field to apply the metric to.
    /// </summary>
    [JsonPropertyName("targetField")]
    public required ConversationField TargetField { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

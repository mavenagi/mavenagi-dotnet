using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record DistinctCount
{
    /// <summary>
    /// Field to apply the metric to. The field should be numeric for all metrics except for Count (no field) and DistinctCount.
    /// </summary>
    [JsonPropertyName("targetField")]
    public required ConversationField TargetField { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

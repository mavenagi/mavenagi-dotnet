using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record FeedbackDistinctCount
{
    /// <summary>
    /// All the distinct values of this field will be counted.
    /// </summary>
    [JsonPropertyName("targetField")]
    public required FeedbackField TargetField { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

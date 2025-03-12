using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record FeedbackGroupBy
{
    /// <summary>
    /// Field used for data grouping.
    /// </summary>
    [JsonPropertyName("field")]
    public required FeedbackField Field { get; set; }

    /// <summary>
    /// Limits the number of groups returned (defaults to 100 if omitted).
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

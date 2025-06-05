using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record FeedbackFilter
{
    [JsonPropertyName("search")]
    public string? Search { get; set; }

    [JsonPropertyName("createdAfter")]
    public DateTime? CreatedAfter { get; set; }

    [JsonPropertyName("createdBefore")]
    public DateTime? CreatedBefore { get; set; }

    [JsonPropertyName("users")]
    public IEnumerable<string>? Users { get; set; }

    [JsonPropertyName("apps")]
    public IEnumerable<string>? Apps { get; set; }

    [JsonPropertyName("types")]
    public IEnumerable<FeedbackType>? Types { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

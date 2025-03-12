using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record FeedbackAnalyticsRequest
{
    /// <summary>
    /// Optional filter applied to refine the feedback data before processing.
    /// </summary>
    [JsonPropertyName("feedbackFilter")]
    public FeedbackFilter? FeedbackFilter { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

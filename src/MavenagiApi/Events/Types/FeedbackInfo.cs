using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record FeedbackInfo
{
    /// <summary>
    /// The rating of the feedback as a ratio [0.0, 1.0]
    /// </summary>
    [JsonPropertyName("rating")]
    public double? Rating { get; set; }

    /// <summary>
    /// Whether the feedback was marked as a thumbs up
    /// </summary>
    [JsonPropertyName("thumbUp")]
    public bool? ThumbUp { get; set; }

    /// <summary>
    /// A question and answer associated with the feedback
    /// </summary>
    [JsonPropertyName("survey")]
    public SurveyInfo? Survey { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

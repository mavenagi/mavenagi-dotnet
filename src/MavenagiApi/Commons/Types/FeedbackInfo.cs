using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
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

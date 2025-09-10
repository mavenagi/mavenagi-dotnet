using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record FeedbackAnalyticsRequest
{
    /// <summary>
    /// Optional filter applied to refine the feedback data before processing.
    /// </summary>
    [JsonPropertyName("feedbackFilter")]
    public FeedbackFilter? FeedbackFilter { get; set; }

    /// <summary>
    /// IANA timezone identifier (e.g., "America/Los_Angeles").
    /// When provided, time-based groupings (e.g., DAY) and date filters are evaluated in this timezone;
    /// otherwise UTC is used.
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

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

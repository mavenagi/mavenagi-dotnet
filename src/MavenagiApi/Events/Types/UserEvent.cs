using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record UserEvent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique ID of the event
    /// </summary>
    [JsonPropertyName("id")]
    public required EntityId Id { get; set; }

    /// <summary>
    /// The name of the event
    /// </summary>
    [JsonPropertyName("eventName")]
    public required UserEventName EventName { get; set; }

    /// <summary>
    /// Information about the user who triggered the event
    /// </summary>
    [JsonPropertyName("userInfo")]
    public required UserInfo UserInfo { get; set; }

    /// <summary>
    /// Information about any feedback associated with the event
    /// </summary>
    [JsonPropertyName("feedbackInfo")]
    public IEnumerable<FeedbackInfo>? FeedbackInfo { get; set; }

    /// <summary>
    /// Information about the page on which the event occurred
    /// </summary>
    [JsonPropertyName("pageInfo")]
    public PageInfo? PageInfo { get; set; }

    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }

    [JsonPropertyName("references")]
    public HashSet<EntityId>? References { get; set; }

    [JsonPropertyName("sourceInfo")]
    public SourceInfo? SourceInfo { get; set; }

    [JsonPropertyName("sessionInfo")]
    public SessionInfo? SessionInfo { get; set; }

    [JsonPropertyName("contextInfo")]
    public ContextInfo? ContextInfo { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

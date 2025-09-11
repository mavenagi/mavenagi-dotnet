using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record SystemEvent
{
    /// <summary>
    /// The unique ID of the event
    /// </summary>
    [JsonPropertyName("id")]
    public required EntityId Id { get; set; }

    /// <summary>
    /// The name of the event
    /// </summary>
    [JsonPropertyName("eventName")]
    public required SystemEventName EventName { get; set; }

    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }

    [JsonPropertyName("references")]
    public HashSet<ScopedEntity>? References { get; set; }

    [JsonPropertyName("sourceInfo")]
    public SourceInfo? SourceInfo { get; set; }

    [JsonPropertyName("sessionInfo")]
    public SessionInfo? SessionInfo { get; set; }

    [JsonPropertyName("contextInfo")]
    public ContextInfo? ContextInfo { get; set; }

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

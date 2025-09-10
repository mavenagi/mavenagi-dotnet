using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record EventFilter
{
    [JsonPropertyName("search")]
    public string? Search { get; set; }

    [JsonPropertyName("createdAfter")]
    public DateTime? CreatedAfter { get; set; }

    [JsonPropertyName("createdBefore")]
    public DateTime? CreatedBefore { get; set; }

    [JsonPropertyName("references")]
    public IEnumerable<ScopedEntity>? References { get; set; }

    [JsonPropertyName("eventTypes")]
    public IEnumerable<EventType>? EventTypes { get; set; }

    [JsonPropertyName("userEventNames")]
    public IEnumerable<UserEventName>? UserEventNames { get; set; }

    [JsonPropertyName("systemEventNames")]
    public IEnumerable<SystemEventName>? SystemEventNames { get; set; }

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

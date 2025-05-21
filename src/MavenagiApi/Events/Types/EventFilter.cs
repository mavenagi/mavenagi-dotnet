using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record EventFilter
{
    [JsonPropertyName("search")]
    public string? Search { get; set; }

    [JsonPropertyName("createdAfter")]
    public DateTime? CreatedAfter { get; set; }

    [JsonPropertyName("createdBefore")]
    public DateTime? CreatedBefore { get; set; }

    [JsonPropertyName("references")]
    public IEnumerable<EntityId>? References { get; set; }

    [JsonPropertyName("eventTypes")]
    public IEnumerable<EventType>? EventTypes { get; set; }

    [JsonPropertyName("userEventNames")]
    public IEnumerable<UserEventName>? UserEventNames { get; set; }

    [JsonPropertyName("systemEventNames")]
    public IEnumerable<SystemEventName>? SystemEventNames { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

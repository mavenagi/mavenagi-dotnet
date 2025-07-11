using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record EventFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

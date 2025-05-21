using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record EventBaseNoId
{
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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

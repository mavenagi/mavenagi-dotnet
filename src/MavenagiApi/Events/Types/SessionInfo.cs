using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record SessionInfo
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("start")]
    public DateTime? Start { get; set; }

    [JsonPropertyName("end")]
    public DateTime? End { get; set; }

    [JsonPropertyName("duration")]
    public long? Duration { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

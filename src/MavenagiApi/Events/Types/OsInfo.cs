using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record OsInfo
{
    [JsonPropertyName("type")]
    public OsType? Type { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record DeviceInfo
{
    [JsonPropertyName("type")]
    public required DeviceType Type { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("osInfo")]
    public OsInfo? OsInfo { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record BrowserInfo
{
    [JsonPropertyName("type")]
    public required BrowserType Type { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("userAgent")]
    public string? UserAgent { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

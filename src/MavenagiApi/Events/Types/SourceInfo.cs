using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record SourceInfo
{
    [JsonPropertyName("type")]
    public required SourceType Type { get; set; }

    [JsonPropertyName("deviceInfo")]
    public DeviceInfo? DeviceInfo { get; set; }

    [JsonPropertyName("browserInfo")]
    public BrowserInfo? BrowserInfo { get; set; }

    [JsonPropertyName("geoInfo")]
    public GeoInfo? GeoInfo { get; set; }

    [JsonPropertyName("ipInfo")]
    public IpInfo? IpInfo { get; set; }

    [JsonPropertyName("languageInfo")]
    public LanguageInfo? LanguageInfo { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

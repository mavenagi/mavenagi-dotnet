using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
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

using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record SourceInfo : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record GeoInfo
{
    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("region")]
    public string? Region { get; set; }

    [JsonPropertyName("latitude")]
    public double? Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double? Longitude { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

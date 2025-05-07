using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record SearchAppSettingsResponse
{
    [JsonPropertyName("results")]
    public IEnumerable<AppSettings> Results { get; set; } = new List<AppSettings>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

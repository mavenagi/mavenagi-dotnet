using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record LanguageInfo
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

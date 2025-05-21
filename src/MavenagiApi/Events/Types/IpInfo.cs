using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record IpInfo
{
    [JsonPropertyName("ip")]
    public string? Ip { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record ControlEvent
{
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

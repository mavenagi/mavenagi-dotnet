using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record HangUpPublishEvent
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

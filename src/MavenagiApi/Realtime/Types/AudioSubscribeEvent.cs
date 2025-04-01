using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record AudioSubscribeEvent
{
    [JsonPropertyName("audioContent")]
    public required string AudioContent { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

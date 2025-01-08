using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record BotTextResponse
{
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
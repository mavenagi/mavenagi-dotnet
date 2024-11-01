using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record Source
{
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

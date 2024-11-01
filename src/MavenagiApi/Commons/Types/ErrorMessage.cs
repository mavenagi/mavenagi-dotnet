using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record ErrorMessage
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

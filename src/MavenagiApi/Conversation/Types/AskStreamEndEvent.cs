using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record AskStreamEndEvent
{
    [JsonPropertyName("error")]
    public ErrorMessage? Error { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

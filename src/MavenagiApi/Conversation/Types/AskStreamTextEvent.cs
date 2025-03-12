using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record AskStreamTextEvent
{
    /// <summary>
    /// A partial response to the question. All stream text events should be concatenated to form the full response.
    /// </summary>
    [JsonPropertyName("contents")]
    public required string Contents { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record FeedbackBase
{
    /// <summary>
    /// The type of feedback
    /// </summary>
    [JsonPropertyName("type")]
    public required FeedbackType Type { get; set; }

    /// <summary>
    /// The feedback text
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

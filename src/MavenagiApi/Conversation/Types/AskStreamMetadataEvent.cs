using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record AskStreamMetadataEvent
{
    [JsonPropertyName("followupQuestions")]
    public IEnumerable<string> FollowupQuestions { get; set; } = new List<string>();

    [JsonPropertyName("sources")]
    public IEnumerable<Source> Sources { get; set; } = new List<Source>();

    /// <summary>
    /// The language of the message in ISO 639-1 code format
    /// </summary>
    [JsonPropertyName("language")]
    public string? Language { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

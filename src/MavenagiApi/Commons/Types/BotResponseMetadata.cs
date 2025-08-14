using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record BotResponseMetadata
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

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

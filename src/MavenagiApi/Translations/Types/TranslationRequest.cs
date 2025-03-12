using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record TranslationRequest
{
    /// <summary>
    /// The text to translate
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    /// <summary>
    /// The target language to translate to, in ISO 639-1 code format.
    /// </summary>
    [JsonPropertyName("targetLanguage")]
    public required string TargetLanguage { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

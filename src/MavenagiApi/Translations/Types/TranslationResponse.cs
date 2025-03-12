using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record TranslationResponse
{
    /// <summary>
    /// The translated text
    /// </summary>
    [JsonPropertyName("translatedText")]
    public required string TranslatedText { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

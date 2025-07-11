using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record AskStreamMetadataEvent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("followupQuestions")]
    public IEnumerable<string> FollowupQuestions { get; set; } = new List<string>();

    [JsonPropertyName("sources")]
    public IEnumerable<Source> Sources { get; set; } = new List<Source>();

    /// <summary>
    /// The language of the message in ISO 639-1 code format
    /// </summary>
    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

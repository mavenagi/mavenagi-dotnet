using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record InboxItemFixAddDocument : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Suggested document title if the fix type is ADD_DOCUMENT.
    /// </summary>
    [JsonPropertyName("suggestedTextTitle")]
    public required string SuggestedTextTitle { get; set; }

    /// <summary>
    /// Suggested document text if the fix type is ADD_DOCUMENT.
    /// </summary>
    [JsonPropertyName("suggestedText")]
    public required string SuggestedText { get; set; }

    /// <summary>
    /// Unique identifier for the inbox item fix.
    /// </summary>
    [JsonPropertyName("id")]
    public required EntityId Id { get; set; }

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

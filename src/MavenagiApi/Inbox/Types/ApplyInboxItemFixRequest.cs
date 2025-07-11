using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ApplyInboxItemFixRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("appId")]
    public required string AppId { get; set; }

    /// <summary>
    /// The type of the inbox item fix to retrieve
    /// </summary>
    [JsonPropertyName("fixType")]
    public required InboxItemFixType FixType { get; set; }

    /// <summary>
    /// Content for Add Document fixes
    /// </summary>
    [JsonPropertyName("addDocumentRequest")]
    public AddDocumentFixRequest? AddDocumentRequest { get; set; }

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

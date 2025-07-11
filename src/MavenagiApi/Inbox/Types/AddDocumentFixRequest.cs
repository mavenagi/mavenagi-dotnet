using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record AddDocumentFixRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Knowledge document to be added by this request
    /// </summary>
    [JsonPropertyName("knowledgeDocumentRequest")]
    public required KnowledgeDocumentRequest KnowledgeDocumentRequest { get; set; }

    /// <summary>
    /// Reference id of the Knowledge Base the document will be added to
    /// </summary>
    [JsonPropertyName("knowledgeBaseReferenceId")]
    public required string KnowledgeBaseReferenceId { get; set; }

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

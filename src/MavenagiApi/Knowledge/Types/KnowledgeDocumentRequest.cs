using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record KnowledgeDocumentRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ID that uniquely identifies this knowledge document within its knowledge base
    /// </summary>
    [JsonPropertyName("knowledgeDocumentId")]
    public required EntityIdBase KnowledgeDocumentId { get; set; }

    /// <summary>
    /// ID that uniquely identifies which knowledge base version to create the document in. If not provided will use the most recent version of the knowledge base.
    /// </summary>
    [JsonPropertyName("versionId")]
    public EntityIdWithoutAgent? VersionId { get; set; }

    [JsonPropertyName("contentType")]
    public required KnowledgeDocumentContentType ContentType { get; set; }

    /// <summary>
    /// The content of the document. Not shown directly to users. May be provided in HTML or markdown. HTML will be converted to markdown automatically. Images are not currently supported and will be ignored.
    /// </summary>
    [JsonPropertyName("content")]
    public required string Content { get; set; }

    /// <summary>
    /// Metadata for the knowledge document.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }

    /// <summary>
    /// The title of the document. Will be shown as part of answers.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// The URL of the document. Should be visible to end users. Will be shown as part of answers. Not used for crawling.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// The document language. Must be a valid ISO 639-1 language code.
    /// </summary>
    [JsonPropertyName("language")]
    public string? Language { get; set; }

    /// <summary>
    /// The time at which this document was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The time at which this document was last modified.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// The name of the author who created this document.
    /// </summary>
    [JsonPropertyName("author")]
    public string? Author { get; set; }

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

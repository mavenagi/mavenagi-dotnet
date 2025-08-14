using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record DocumentInformation
{
    /// <summary>
    /// Unique identifier for the knowledge base.
    /// </summary>
    [JsonPropertyName("knowledgeBaseId")]
    public required EntityIdWithoutAgent KnowledgeBaseId { get; set; }

    /// <summary>
    /// Unique identifier for the document.
    /// </summary>
    [JsonPropertyName("documentId")]
    public required EntityIdWithoutAgent DocumentId { get; set; }

    /// <summary>
    /// Title of the document.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Snippet or summary of the document.
    /// </summary>
    [JsonPropertyName("snippet")]
    public string? Snippet { get; set; }

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

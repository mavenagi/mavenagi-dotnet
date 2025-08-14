using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record AddDocumentFixRequest
{
    /// <summary>
    /// Knowledge document to be added by this request
    /// </summary>
    [JsonPropertyName("knowledgeDocumentRequest")]
    public required KnowledgeDocumentRequest KnowledgeDocumentRequest { get; set; }

    /// <summary>
    /// Reference id of the Knowledge Base the document will be added to.
    /// The appId is inferred from the request. Apps can only add documents to their own knowledge bases.
    /// </summary>
    [JsonPropertyName("knowledgeBaseReferenceId")]
    public required string KnowledgeBaseReferenceId { get; set; }

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

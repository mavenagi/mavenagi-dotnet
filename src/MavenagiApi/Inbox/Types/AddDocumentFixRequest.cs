using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record AddDocumentFixRequest
{
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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

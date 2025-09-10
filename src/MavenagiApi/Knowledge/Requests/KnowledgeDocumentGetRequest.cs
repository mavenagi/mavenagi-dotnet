using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record KnowledgeDocumentGetRequest
{
    /// <summary>
    /// The App ID of the knowledge base version.
    /// </summary>
    [JsonIgnore]
    public required string KnowledgeBaseVersionAppId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

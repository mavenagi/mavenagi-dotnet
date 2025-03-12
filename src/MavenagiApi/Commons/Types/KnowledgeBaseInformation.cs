using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record KnowledgeBaseInformation
{
    /// <summary>
    /// Unique identifier for the knowledge base.
    /// </summary>
    [JsonPropertyName("knowledgeBaseId")]
    public required EntityIdWithoutAgent KnowledgeBaseId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

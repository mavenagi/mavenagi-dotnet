using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record KnowledgeBaseVersion
{
    /// <summary>
    /// Indicates whether the completed version constitutes a full or partial refresh of the knowledge base. Deleting and updating documents is only supported for partial refreshes.
    /// </summary>
    [JsonPropertyName("type")]
    public required KnowledgeBaseVersionType Type { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

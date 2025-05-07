using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record KnowledgeBaseResponse
{
    /// <summary>
    /// ID that uniquely identifies this knowledge base
    /// </summary>
    [JsonPropertyName("knowledgeBaseId")]
    public required EntityId KnowledgeBaseId { get; set; }

    /// <summary>
    /// The type of the knowledge base. Can not be changed once created.
    /// </summary>
    [JsonPropertyName("type")]
    public required KnowledgeBaseType Type { get; set; }

    /// <summary>
    /// Metadata for the knowledge base.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();

    /// <summary>
    /// The name of the knowledge base
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// (Beta) The preconditions that must be met for knowledge base be relevant to a conversation. Can be used to limit knowledge to certain types of users.
    /// </summary>
    [JsonPropertyName("precondition")]
    public object? Precondition { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

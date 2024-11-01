using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record KnowledgeBaseRequest
{
    /// <summary>
    /// ID that uniquely identifies this knowledge base
    /// </summary>
    [JsonPropertyName("knowledgeBaseId")]
    public required EntityIdBase KnowledgeBaseId { get; set; }

    /// <summary>
    /// The name of the knowledge base
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The type of the knowledge base. Can not be changed once created.
    /// </summary>
    [JsonPropertyName("type")]
    public required KnowledgeBaseType Type { get; set; }

    /// <summary>
    /// The URL to pull content from for RSS and URL knowledge bases.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

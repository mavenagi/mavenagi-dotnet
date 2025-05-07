using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record KnowledgeBaseVersion
{
    /// <summary>
    /// The unique ID of the knowledge base version.
    /// </summary>
    [JsonPropertyName("versionId")]
    public required EntityId VersionId { get; set; }

    /// <summary>
    /// Indicates whether the completed version constitutes a full or partial refresh of the knowledge base. Deleting and updating documents is only supported for partial refreshes.
    /// </summary>
    [JsonPropertyName("type")]
    public required KnowledgeBaseVersionType Type { get; set; }

    /// <summary>
    /// The status of the knowledge base version
    /// </summary>
    [JsonPropertyName("status")]
    public required KnowledgeBaseVersionStatus Status { get; set; }

    /// <summary>
    /// A user-facing error message that provides more details about a version failure.
    /// </summary>
    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record FinalizeKnowledgeBaseVersionRequest
{
    /// <summary>
    /// ID that uniquely identifies which knowledge base version to finalize. If not provided will use the most recent version of the knowledge base.
    /// </summary>
    [JsonPropertyName("versionId")]
    public EntityIdWithoutAgent? VersionId { get; set; }

    /// <summary>
    /// Whether the knowledge base version processing was successful or not.
    /// </summary>
    [JsonPropertyName("status")]
    public KnowledgeBaseVersionFinalizeStatus? Status { get; set; }

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

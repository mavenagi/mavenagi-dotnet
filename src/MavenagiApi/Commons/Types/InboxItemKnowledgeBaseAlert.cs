using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record InboxItemKnowledgeBaseAlert
{
    /// <summary>
    /// Fix associated with the inbox item.
    /// </summary>
    [JsonPropertyName("fix")]
    public required InboxItemFixDeactivateKnowledgeBase Fix { get; set; }

    /// <summary>
    /// Information about the Knowledge Base referenced in the inbox item.
    /// </summary>
    [JsonPropertyName("knowledgeBase")]
    public required KnowledgeBaseInformation KnowledgeBase { get; set; }

    /// <summary>
    /// Unique identifier for the inbox item.
    /// </summary>
    [JsonPropertyName("id")]
    public required EntityId Id { get; set; }

    /// <summary>
    /// Timestamp when the inbox item was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Timestamp when the inbox item was last updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Status of the inbox item.
    /// </summary>
    [JsonPropertyName("status")]
    public required InboxItemStatus Status { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

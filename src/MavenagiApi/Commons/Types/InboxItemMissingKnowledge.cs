using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record InboxItemMissingKnowledge
{
    /// <summary>
    /// Fix associated with the inbox item.
    /// </summary>
    [JsonPropertyName("fix")]
    public required InboxItemFixAddDocument Fix { get; set; }

    /// <summary>
    /// List of Conversation information objects related to the inbox item.
    /// </summary>
    [JsonPropertyName("conversations")]
    public IEnumerable<ConversationInformation> Conversations { get; set; } =
        new List<ConversationInformation>();

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

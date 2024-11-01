using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record UserMessage
{
    /// <summary>
    /// The ID that uniquely identifies this message within the conversation
    /// </summary>
    [JsonPropertyName("conversationMessageId")]
    public required EntityId ConversationMessageId { get; set; }

    /// <summary>
    /// The language of the message in ISO 639-1 code format
    /// </summary>
    [JsonPropertyName("language")]
    public string? Language { get; set; }

    /// <summary>
    /// ID that uniquely identifies the user that created this message
    /// </summary>
    [JsonPropertyName("userId")]
    public required EntityIdBase UserId { get; set; }

    /// <summary>
    /// The text of the message. Cannot be empty
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    [JsonPropertyName("userMessageType")]
    public required UserConversationMessageType UserMessageType { get; set; }

    /// <summary>
    /// The date and time the conversation was created
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The date and time the conversation was last updated
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

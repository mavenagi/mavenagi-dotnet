using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record BotMessage
{
    /// <summary>
    /// The ID that uniquely identifies this message within the conversation
    /// </summary>
    [JsonPropertyName("conversationMessageId")]
    public required EntityId ConversationMessageId { get; set; }

    [JsonPropertyName("botMessageType")]
    public required BotConversationMessageType BotMessageType { get; set; }

    [JsonPropertyName("responses")]
    public IEnumerable<object> Responses { get; set; } = new List<object>();

    [JsonPropertyName("metadata")]
    public required BotResponseMetadata Metadata { get; set; }

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

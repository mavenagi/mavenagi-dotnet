using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record Feedback
{
    /// <summary>
    /// The ID of the piece of feedback
    /// </summary>
    [JsonPropertyName("feedbackId")]
    public required EntityId FeedbackId { get; set; }

    /// <summary>
    /// The ID of the conversation the feedback is about
    /// </summary>
    [JsonPropertyName("conversationId")]
    public required EntityId ConversationId { get; set; }

    /// <summary>
    /// The ID of the conversation message the feedback is about
    /// </summary>
    [JsonPropertyName("conversationMessageId")]
    public required EntityId ConversationMessageId { get; set; }

    /// <summary>
    /// The ID of the user who created the feedback
    /// </summary>
    [JsonPropertyName("userId")]
    public EntityId? UserId { get; set; }

    /// <summary>
    /// The date and time the feedback was created
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The type of feedback
    /// </summary>
    [JsonPropertyName("type")]
    public required FeedbackType Type { get; set; }

    /// <summary>
    /// The feedback text
    /// </summary>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

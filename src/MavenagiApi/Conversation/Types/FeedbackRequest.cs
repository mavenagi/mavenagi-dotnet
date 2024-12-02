using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record FeedbackRequest
{
    /// <summary>
    /// The ID that uniquely identifies this feedback
    /// </summary>
    [JsonPropertyName("feedbackId")]
    public required EntityIdBase FeedbackId { get; set; }

    /// <summary>
    /// The ID that uniquely identifies the the conversation the feedback is about
    /// </summary>
    [JsonPropertyName("conversationId")]
    public required EntityIdBase ConversationId { get; set; }

    /// <summary>
    /// The ID that uniquely identifies the message within the conversation the feedback is about
    /// </summary>
    [JsonPropertyName("conversationMessageId")]
    public required EntityIdBase ConversationMessageId { get; set; }

    /// <summary>
    /// The ID of the user who is creating the feedback
    /// </summary>
    [JsonPropertyName("userId")]
    public EntityIdBase? UserId { get; set; }

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

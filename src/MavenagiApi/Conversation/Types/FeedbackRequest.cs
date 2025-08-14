using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
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

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

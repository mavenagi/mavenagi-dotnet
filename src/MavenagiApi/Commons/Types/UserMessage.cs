using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
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
    /// The attachments associated with the message
    /// </summary>
    [JsonPropertyName("attachments")]
    public IEnumerable<AttachmentResponse> Attachments { get; set; } =
        new List<AttachmentResponse>();

    /// <summary>
    /// The ID of the agent user that created this message. More detail can be fetched via the agent user APIs. Will be empty only for legacy conversations.
    /// </summary>
    [JsonPropertyName("agentUserId")]
    public string? AgentUserId { get; set; }

    /// <summary>
    /// The display name of the user who created this message. Only available for users who have saved name information.
    /// </summary>
    [JsonPropertyName("userDisplayName")]
    public string? UserDisplayName { get; set; }

    /// <summary>
    /// The delivery status of the message. Only applicable to messages sent via the deliverMessage API.
    /// All other messages have an `UNKNOWN` status.
    ///
    /// * `SENT`: The message has been sent to the user.
    /// * `FAILED`: The message sending encountered an error.
    /// * `UNKNOWN`: The message status is unknown.
    /// </summary>
    [JsonPropertyName("status")]
    public required MessageStatus Status { get; set; }

    /// <summary>
    /// Only present on newer messaged where `userMessageType` is `USER`.
    /// Indicates the state of the answer to the user message.
    ///
    /// - `NOT_ASKED`: An answer was not requested for this user message.
    /// - `LLM_ENABLED`: An answer was requested for this user message and the LLM was enabled.
    /// - `LLM_DISABLED`: An answer was requested for this user message and the LLM was disabled.
    /// </summary>
    [JsonPropertyName("responseState")]
    public UserMessageResponseState? ResponseState { get; set; }

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

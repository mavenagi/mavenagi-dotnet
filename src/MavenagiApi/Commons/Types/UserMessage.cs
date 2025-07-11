using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record UserMessage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
    public IEnumerable<UserMessageAttachment> Attachments { get; set; } =
        new List<UserMessageAttachment>();

    /// <summary>
    /// The display name of the user who created this message. Only available for users who have saved name information.
    /// </summary>
    [JsonPropertyName("userDisplayName")]
    public string? UserDisplayName { get; set; }

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

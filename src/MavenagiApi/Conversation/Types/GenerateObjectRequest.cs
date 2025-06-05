using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record GenerateObjectRequest
{
    /// <summary>
    /// JSON schema string defining the expected object shape.
    /// </summary>
    [JsonPropertyName("schema")]
    public required string Schema { get; set; }

    /// <summary>
    /// Externally supplied ID to uniquely identify this message within the conversation. If a message with this ID already exists it will be reused and will not be updated.
    /// </summary>
    [JsonPropertyName("conversationMessageId")]
    public required EntityIdBase ConversationMessageId { get; set; }

    /// <summary>
    /// Externally supplied ID to uniquely identify the user that created this message
    /// </summary>
    [JsonPropertyName("userId")]
    public required EntityIdBase UserId { get; set; }

    /// <summary>
    /// The text of the message
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    /// <summary>
    /// The attachments to the message.
    /// </summary>
    [JsonPropertyName("attachments")]
    public IEnumerable<Attachment>? Attachments { get; set; }

    /// <summary>
    /// Transient data which the Maven platform will not persist. This data will only be forwarded to actions taken by this ask request. For example, one may put in user tokens as transient data.
    /// </summary>
    [JsonPropertyName("transientData")]
    public Dictionary<string, string>? TransientData { get; set; }

    /// <summary>
    /// IANA timezone identifier (e.g. "America/New_York", "Europe/London") to be used for time-based operations in the conversation.
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

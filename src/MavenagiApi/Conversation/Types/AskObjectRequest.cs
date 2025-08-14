using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record AskObjectRequest
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
    /// The attachments to the message. Image attachments will be sent to the LLM as additional data.
    /// Non-image attachments can be stored and downloaded from the API but will not be sent to the LLM.
    /// </summary>
    [JsonPropertyName("attachments")]
    public IEnumerable<AttachmentRequest>? Attachments { get; set; }

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

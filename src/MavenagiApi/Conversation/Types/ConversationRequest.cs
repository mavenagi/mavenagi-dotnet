using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ConversationRequest
{
    /// <summary>
    /// An externally supplied ID to uniquely identify this conversation
    /// </summary>
    [JsonPropertyName("conversationId")]
    public required EntityIdBase ConversationId { get; set; }

    /// <summary>
    /// Optional configurations for responses to this conversation
    /// </summary>
    [JsonPropertyName("responseConfig")]
    public ResponseConfig? ResponseConfig { get; set; }

    /// <summary>
    /// The subject of the conversation
    /// </summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>
    /// The url of the conversation
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

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
    /// The tags of the conversation. Used for filtering in Agent Designer.
    /// </summary>
    [JsonPropertyName("tags")]
    public HashSet<string>? Tags { get; set; }

    /// <summary>
    /// The metadata of the conversation supplied by the app which created the conversation.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }

    /// <summary>
    /// The messages in the conversation
    /// </summary>
    [JsonPropertyName("messages")]
    public IEnumerable<ConversationMessageRequest> Messages { get; set; } =
        new List<ConversationMessageRequest>();

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

using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
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

    [JsonPropertyName("status")]
    public required MessageStatus Status { get; set; }

    /// <summary>
    /// The logic that was used to generate the response. Response size may be large; only present on the getConversation request.
    /// </summary>
    [JsonPropertyName("logic")]
    public BotLogic? Logic { get; set; }

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

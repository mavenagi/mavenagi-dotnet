using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record DeliverConversationMessageRequest
{
    /// <summary>
    /// The ID of the conversation to deliver the message to. Message delivery will fail if the conversation does not have the `ASYNC` capability or if it is not `open`.
    /// </summary>
    [JsonPropertyName("conversationId")]
    public required EntityIdWithoutAgent ConversationId { get; set; }

    /// <summary>
    /// The message to deliver.
    /// </summary>
    [JsonPropertyName("message")]
    public required ConversationMessageRequest Message { get; set; }

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

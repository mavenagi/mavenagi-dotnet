using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ConversationPatchRequest
{
    /// <summary>
    /// The App ID of the conversation to patch. If not provided the ID of the calling app will be used.
    /// </summary>
    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    /// <summary>
    /// Whether the conversation is able to receive asynchronous messages. Only valid for conversations with the `ASYNC` capability.
    /// </summary>
    [JsonPropertyName("open")]
    public bool? Open { get; set; }

    /// <summary>
    /// Whether the LLM is enabled for this conversation.
    /// </summary>
    [JsonPropertyName("llmEnabled")]
    public bool? LlmEnabled { get; set; }

    /// <summary>
    /// A list of attachments to add to the conversation. Attachments can only be appended. Removal is not allowed.
    /// </summary>
    [JsonPropertyName("attachments")]
    public IEnumerable<AttachmentRequest>? Attachments { get; set; }

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

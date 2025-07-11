using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record BotMessage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID that uniquely identifies this message within the conversation
    /// </summary>
    [JsonPropertyName("conversationMessageId")]
    public required EntityId ConversationMessageId { get; set; }

    [JsonPropertyName("botMessageType")]
    public required BotConversationMessageType BotMessageType { get; set; }

    [JsonPropertyName("responses")]
    public IEnumerable<BotResponse> Responses { get; set; } = new List<BotResponse>();

    [JsonPropertyName("metadata")]
    public required BotResponseMetadata Metadata { get; set; }

    [JsonPropertyName("status")]
    public required BotMessageStatus Status { get; set; }

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

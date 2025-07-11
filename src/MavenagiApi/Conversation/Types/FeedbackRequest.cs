using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record FeedbackRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record ConversationResponse
{
    /// <summary>
    /// The ID that uniquely identifies this conversation
    /// </summary>
    [JsonPropertyName("conversationId")]
    public required EntityId ConversationId { get; set; }

    /// <summary>
    /// The messages in the conversation
    /// </summary>
    [JsonPropertyName("messages")]
    public IEnumerable<object> Messages { get; set; } = new List<object>();

    /// <summary>
    /// An analysis of the conversation.
    /// </summary>
    [JsonPropertyName("analysis")]
    public required ConversationAnalysis Analysis { get; set; }

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
    /// The metadata of the conversation.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

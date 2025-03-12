using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record ConversationInformation
{
    /// <summary>
    /// Unique identifier for the conversation.
    /// </summary>
    [JsonPropertyName("conversationId")]
    public required EntityIdWithoutAgent ConversationId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record AskStreamStartEvent
{
    [JsonPropertyName("conversationMessageId")]
    public required EntityId ConversationMessageId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

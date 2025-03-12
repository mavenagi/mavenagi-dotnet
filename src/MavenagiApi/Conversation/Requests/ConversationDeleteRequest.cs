using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record ConversationDeleteRequest
{
    /// <summary>
    /// The App ID of the conversation to delete. If not provided the ID of the calling app will be used.
    /// </summary>
    [JsonIgnore]
    public string? AppId { get; set; }

    /// <summary>
    /// The reason for deleting the conversation. This message will replace all user messages in the conversation.
    /// </summary>
    [JsonIgnore]
    public required string Reason { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

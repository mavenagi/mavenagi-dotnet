using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record ConversationDeleteRequest
{
    /// <summary>
    /// The App ID of the conversation to delete. If not provided the ID of the calling app will be used.
    /// </summary>
    public string? AppId { get; set; }

    /// <summary>
    /// The reason for deleting the conversation. This message will replace all user messages in the conversation.
    /// </summary>
    public required string Reason { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

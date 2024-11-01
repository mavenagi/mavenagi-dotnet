using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record ConversationGetRequest
{
    /// <summary>
    /// The App ID of the conversation to get. If not provided the ID of the calling app will be used.
    /// </summary>
    public string? AppId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

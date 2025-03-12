using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record InboxItemRequest
{
    /// <summary>
    /// The App ID of the inbox item to retrieve
    /// </summary>
    [JsonIgnore]
    public required string AppId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

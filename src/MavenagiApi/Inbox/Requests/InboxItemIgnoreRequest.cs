using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record InboxItemIgnoreRequest
{
    /// <summary>
    /// The App ID of the inbox item fix to ignore
    /// </summary>
    [JsonIgnore]
    public required string AppId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

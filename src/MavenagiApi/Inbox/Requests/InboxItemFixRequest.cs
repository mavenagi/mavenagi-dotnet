using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record InboxItemFixRequest
{
    /// <summary>
    /// The App ID of the inbox item fix to retrieve
    /// </summary>
    [JsonIgnore]
    public required string AppId { get; set; }

    /// <summary>
    /// The type of the inbox item fix to retrieve
    /// </summary>
    [JsonIgnore]
    public required InboxItemFixType FixType { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

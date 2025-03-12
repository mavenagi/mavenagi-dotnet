using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record UserDeleteRequest
{
    /// <summary>
    /// The App ID of the user to delete. If not provided the ID of the calling app will be used.
    /// </summary>
    [JsonIgnore]
    public string? AppId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

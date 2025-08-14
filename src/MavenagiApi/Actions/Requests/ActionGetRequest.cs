using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ActionGetRequest
{
    /// <summary>
    /// The App ID of the action to get. If not provided the ID of the calling app will be used.
    /// </summary>
    [JsonIgnore]
    public string? AppId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

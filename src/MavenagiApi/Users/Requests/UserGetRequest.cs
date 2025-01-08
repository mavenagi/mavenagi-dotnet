using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record UserGetRequest
{
    /// <summary>
    /// The App ID of the user to get. If not provided the ID of the calling app will be used.
    /// </summary>
    public string? AppId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

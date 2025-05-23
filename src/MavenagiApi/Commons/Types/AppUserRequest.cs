using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record AppUserRequest
{
    /// <summary>
    /// ID that uniquely identifies this app user
    /// </summary>
    [JsonPropertyName("userId")]
    public required EntityIdBase UserId { get; set; }

    /// <summary>
    /// Used to determine whether two users from different apps are the same
    /// </summary>
    [JsonPropertyName("identifiers")]
    public HashSet<AppUserIdentifier> Identifiers { get; set; } = new HashSet<AppUserIdentifier>();

    [JsonPropertyName("data")]
    public Dictionary<string, UserData> Data { get; set; } = new Dictionary<string, UserData>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

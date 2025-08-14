using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record AppUserResponse
{
    /// <summary>
    /// ID that uniquely identifies this user
    /// </summary>
    [JsonPropertyName("userId")]
    public required EntityId UserId { get; set; }

    /// <summary>
    /// Data from all apps
    /// </summary>
    [JsonPropertyName("allUserData")]
    public Dictionary<string, Dictionary<string, string>> AllUserData { get; set; } =
        new Dictionary<string, Dictionary<string, string>>();

    /// <summary>
    /// Default data for this user
    /// </summary>
    [JsonPropertyName("defaultUserData")]
    public Dictionary<string, string> DefaultUserData { get; set; } =
        new Dictionary<string, string>();

    /// <summary>
    /// Used to determine whether two users from different apps are the same
    /// </summary>
    [JsonPropertyName("identifiers")]
    public HashSet<AppUserIdentifier> Identifiers { get; set; } = new HashSet<AppUserIdentifier>();

    [JsonPropertyName("data")]
    public Dictionary<string, UserData> Data { get; set; } = new Dictionary<string, UserData>();

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record AgentUser
{
    /// <summary>
    /// The ID of the agent user.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The date and time the agent user was created
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The date and time the agent user was last updated
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// All identifiers for the agent user. This is a merged set of identifiers from the app created users.
    /// </summary>
    [JsonPropertyName("identifiers")]
    public HashSet<AppUserIdentifier> Identifiers { get; set; } = new HashSet<AppUserIdentifier>();

    /// <summary>
    /// A name for the agent user, if one can be determined.
    /// The value is derived from the user data provided by individual apps - specifically data fields keyed by `name`, `first_name` or `firstName`.
    /// </summary>
    [JsonPropertyName("defaultName")]
    public string? DefaultName { get; set; }

    /// <summary>
    /// App created users that are associated with this agent user.
    /// If two apps create users with the same identifying properties, they will be merged into a single agent user.
    /// </summary>
    [JsonPropertyName("users")]
    public IEnumerable<AppUserSummary> Users { get; set; } = new List<AppUserSummary>();

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

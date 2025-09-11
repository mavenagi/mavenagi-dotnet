using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record AgentUserFilter
{
    /// <summary>
    /// Full-text search query for matching agent users by content.
    /// When you search with this parameter, you're performing a full-text search across the user identifiers.
    /// </summary>
    [JsonPropertyName("search")]
    public string? Search { get; set; }

    /// <summary>
    /// Filter by identifiers
    /// </summary>
    [JsonPropertyName("identifiers")]
    public IEnumerable<string>? Identifiers { get; set; }

    /// <summary>
    /// Filter by anonymous users. When true, only anonymous users are returned.
    /// When false, only non-anonymous users are returned. An anonymous user is one without any identifiers or name data.
    /// </summary>
    [JsonPropertyName("isAnonymous")]
    public bool? IsAnonymous { get; set; }

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

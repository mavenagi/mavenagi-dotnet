using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record AppUserSummary
{
    /// <summary>
    /// App provided user ID.
    /// </summary>
    [JsonPropertyName("userId")]
    public required EntityId UserId { get; set; }

    /// <summary>
    /// App provided identifiers for the user.
    /// </summary>
    [JsonPropertyName("identifiers")]
    public HashSet<AppUserIdentifier> Identifiers { get; set; } = new HashSet<AppUserIdentifier>();

    /// <summary>
    /// App provided data masked according to the data's visibility type. `HIDDEN` or `PARTIALLY_VISIBLE` data values will be not be fully returned.
    /// </summary>
    [JsonPropertyName("visibleData")]
    public Dictionary<string, string> VisibleData { get; set; } = new Dictionary<string, string>();

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

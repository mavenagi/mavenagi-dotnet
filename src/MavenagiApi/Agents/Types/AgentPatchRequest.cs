using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record AgentPatchRequest
{
    /// <summary>
    /// The name of the agent.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The environment of the agent.
    /// </summary>
    [JsonPropertyName("environment")]
    public AgentEnvironment? Environment { get; set; }

    /// <summary>
    /// The agent's default timezone. This is used when a timezone is not set on a conversation.
    /// </summary>
    [JsonPropertyName("defaultTimezone")]
    public string? DefaultTimezone { get; set; }

    /// <summary>
    /// The PII categories that are enabled for the agent.
    /// </summary>
    [JsonPropertyName("enabledPiiCategories")]
    public HashSet<PiiCategory>? EnabledPiiCategories { get; set; }

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

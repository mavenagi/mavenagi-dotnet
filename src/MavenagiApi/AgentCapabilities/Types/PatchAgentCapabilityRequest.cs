using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record PatchAgentCapabilityRequest
{
    /// <summary>
    /// Whether this capability is enabled or disabled
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Override description for action capabilities. Only applies to actions, ignored for triggers.
    /// </summary>
    [JsonPropertyName("descriptionOverride")]
    public string? DescriptionOverride { get; set; }

    /// <summary>
    /// Whether this action capability is pinned. Only applies to actions, ignored for triggers.
    /// </summary>
    [JsonPropertyName("pinned")]
    public bool? Pinned { get; set; }

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

using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record AgentCapabilityListRequest
{
    [JsonPropertyName("capabilityType")]
    public AgentCapabilityType? CapabilityType { get; set; }

    [JsonPropertyName("pinned")]
    public bool? Pinned { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("integrationIds")]
    public IEnumerable<string>? IntegrationIds { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("userInteractionRequired")]
    public bool? UserInteractionRequired { get; set; }

    /// <summary>
    /// The field to sort by, defaults to created timestamp
    /// </summary>
    [JsonPropertyName("sortId")]
    public AgentCapabilityField? SortId { get; set; }

    /// <summary>
    /// Page number to return, defaults to 0
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    /// <summary>
    /// The size of the page to return, defaults to 20
    /// </summary>
    [JsonPropertyName("size")]
    public int? Size { get; set; }

    /// <summary>
    /// Whether to sort descending, defaults to true
    /// </summary>
    [JsonPropertyName("sortDesc")]
    public bool? SortDesc { get; set; }

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

using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record InboxFilter
{
    /// <summary>
    /// List of inbox item statuses to filter by.
    /// </summary>
    [JsonPropertyName("statuses")]
    public IEnumerable<InboxItemStatus>? Statuses { get; set; }

    /// <summary>
    /// List of inbox item types to filter by.
    /// </summary>
    [JsonPropertyName("type")]
    public IEnumerable<InboxItemType>? Type { get; set; }

    /// <summary>
    /// Filter for items created after this timestamp.
    /// </summary>
    [JsonPropertyName("createdAfter")]
    public DateTime? CreatedAfter { get; set; }

    /// <summary>
    /// Filter for items created before this timestamp.
    /// </summary>
    [JsonPropertyName("createdBefore")]
    public DateTime? CreatedBefore { get; set; }

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

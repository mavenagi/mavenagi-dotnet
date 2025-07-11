using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record InboxSearchRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
    /// The field to sort by, defaults to created timestamp.
    /// </summary>
    [JsonPropertyName("sortId")]
    public string? SortId { get; set; }

    /// <summary>
    /// Whether to sort descending, defaults to true.
    /// </summary>
    [JsonPropertyName("sortDesc")]
    public bool? SortDesc { get; set; }

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

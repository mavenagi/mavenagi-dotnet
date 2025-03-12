using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record InboxSearchRequest
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
    /// Page number to return, defaults to 0
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    /// <summary>
    /// The size of the page to return, defaults to 20
    /// </summary>
    [JsonPropertyName("size")]
    public int? Size { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

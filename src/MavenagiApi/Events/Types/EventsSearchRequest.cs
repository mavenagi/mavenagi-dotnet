using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record EventsSearchRequest
{
    [JsonPropertyName("sort")]
    public EventField? Sort { get; set; }

    [JsonPropertyName("filter")]
    public EventFilter? Filter { get; set; }

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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

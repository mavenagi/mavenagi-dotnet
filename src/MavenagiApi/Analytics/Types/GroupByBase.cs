using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record GroupByBase
{
    /// <summary>
    /// Limits the number of groups returned (defaults to 100 if omitted).
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

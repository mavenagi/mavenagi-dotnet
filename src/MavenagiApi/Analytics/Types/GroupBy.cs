using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record GroupBy
{
    /// <summary>
    /// Field used for data grouping.
    /// </summary>
    [JsonPropertyName("field")]
    public required ConversationField Field { get; set; }

    /// <summary>
    /// Limits the number of groups returned (defaults to 100 if omitted).
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// Numeric ranges for grouping data into predefined buckets. Applies only to numeric fields.
    /// </summary>
    [JsonPropertyName("ranges")]
    public IEnumerable<Range>? Ranges { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

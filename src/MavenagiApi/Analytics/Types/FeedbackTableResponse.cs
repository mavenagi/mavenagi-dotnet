using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record FeedbackTableResponse
{
    /// <summary>
    /// The dataset rows, where each row represents a unique combination of grouping field values.
    /// The identifier map contains grouping field names mapped to their respective values.
    /// The data map contains column headers mapped to their respective metric values.
    /// </summary>
    [JsonPropertyName("rows")]
    public IEnumerable<FeedbackRow> Rows { get; set; } = new List<FeedbackRow>();

    /// <summary>
    /// Column headers in the table, aligning with the column definitions specified in the request.
    /// </summary>
    [JsonPropertyName("headers")]
    public IEnumerable<string> Headers { get; set; } = new List<string>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

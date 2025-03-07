using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record FeedbackTableRequest
{
    /// <summary>
    /// Defines the time interval for grouping data. If specified, data is grouped accordingly based on the time they were created.
    ///  Example: If set to "DAY," data will be aggregated by day.
    /// </summary>
    [JsonPropertyName("timeGrouping")]
    public TimeInterval? TimeGrouping { get; set; }

    /// <summary>
    /// Specifies the fields by which data should be grouped. Each unique combination forms a row.
    /// If multiple fields are provided, the result is grouped by their unique value combinations.
    /// If empty, all data is aggregated into a single row.
    /// </summary>
    [JsonPropertyName("fieldGroupings")]
    public IEnumerable<FeedbackGroupBy> FieldGroupings { get; set; } = new List<FeedbackGroupBy>();

    /// <summary>
    /// Specifies the metrics to be displayed as columns.
    /// Column headers act as keys, with computed metric values as their mapped values.
    /// There needs to be at least one column definition in the table request.
    /// </summary>
    [JsonPropertyName("columnDefinitions")]
    public IEnumerable<FeedbackColumnDefinition> ColumnDefinitions { get; set; } =
        new List<FeedbackColumnDefinition>();

    /// <summary>
    /// Optional filter applied to refine the feedback data before processing.
    /// </summary>
    [JsonPropertyName("feedbackFilter")]
    public FeedbackFilter? FeedbackFilter { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

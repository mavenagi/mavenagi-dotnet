using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ConversationTableRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Defines the time interval for grouping data. If specified, data is grouped accordingly  based on the time they were created. Example: If set to "DAY," data will be aggregated by day.
    /// </summary>
    [JsonPropertyName("timeGrouping")]
    public TimeInterval? TimeGrouping { get; set; }

    /// <summary>
    /// Specifies the fields by which data should be grouped. Each unique combination forms a row.
    /// If multiple fields are provided, the result is grouped by their unique value combinations.
    /// If empty, all data is aggregated into a single row. |
    /// Note: The field `CreatedAt` should not be used here, all time-based grouping should be done using the `timeGrouping` field.
    /// </summary>
    [JsonPropertyName("fieldGroupings")]
    public IEnumerable<ConversationGroupBy> FieldGroupings { get; set; } =
        new List<ConversationGroupBy>();

    /// <summary>
    /// Specifies the metrics to be displayed as columns. Column headers act as keys, with computed metric values as their mapped values. There needs to be at least one column definition in the table request.
    /// </summary>
    [JsonPropertyName("columnDefinitions")]
    public IEnumerable<ConversationColumnDefinition> ColumnDefinitions { get; set; } =
        new List<ConversationColumnDefinition>();

    /// <summary>
    /// Optional filter applied to refine the conversation data before processing.
    /// </summary>
    [JsonPropertyName("conversationFilter")]
    public ConversationFilter? ConversationFilter { get; set; }

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

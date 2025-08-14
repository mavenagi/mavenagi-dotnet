using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ConversationGroupBy
{
    /// <summary>
    /// Field used for data grouping.
    /// </summary>
    [JsonPropertyName("field")]
    public required ConversationField Field { get; set; }

    /// <summary>
    /// Numeric ranges for grouping data into predefined buckets. Applies only to numeric fields.
    /// </summary>
    [JsonPropertyName("ranges")]
    public IEnumerable<Range>? Ranges { get; set; }

    /// <summary>
    /// Limits the number of groups returned (defaults to 100 if omitted).
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

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

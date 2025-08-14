using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ConversationTableResponse
{
    /// <summary>
    /// The dataset rows, where each row represents a unique combination of grouping field values.
    /// The identifier map contains grouping field names mapped to their respective values.
    /// The data map contains column headers mapped to their respective metric values.
    /// </summary>
    [JsonPropertyName("rows")]
    public IEnumerable<ConversationRow> Rows { get; set; } = new List<ConversationRow>();

    /// <summary>
    /// Column headers in the table, aligning with the column definitions specified in the request.
    /// </summary>
    [JsonPropertyName("headers")]
    public IEnumerable<string> Headers { get; set; } = new List<string>();

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

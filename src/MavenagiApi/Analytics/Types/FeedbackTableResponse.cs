using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record FeedbackTableResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

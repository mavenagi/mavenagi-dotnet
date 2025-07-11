using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record FeedbackColumnDefinition : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The metric calculated for this column, stored in the row data under the specified header.
    /// </summary>
    [JsonPropertyName("metric")]
    public required FeedbackMetric Metric { get; set; }

    /// <summary>
    /// Unique column header, serving as the key for corresponding metric values.
    /// </summary>
    [JsonPropertyName("header")]
    public required string Header { get; set; }

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

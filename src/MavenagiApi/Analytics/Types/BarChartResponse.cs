using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record BarChartResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Each LabeledPoint in the series represents a value for the bar, where the name serves as the bar's label.
    /// If vertical grouping is defined, multiple series will be created, each representing a group.
    /// In such cases, the bars can be stacked to reflect the grouped data distribution.
    /// </summary>
    [JsonPropertyName("series")]
    public IEnumerable<Series> Series { get; set; } = new List<Series>();

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

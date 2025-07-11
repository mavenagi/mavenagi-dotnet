using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

/// <summary>
/// Calculates specified percentile for a numeric field.
/// </summary>
[Serializable]
public record ConversationPercentile : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The percentile to calculate. Example: 25 computes the 25th percentile.
    /// </summary>
    [JsonPropertyName("percentile")]
    public required double Percentile { get; set; }

    /// <summary>
    /// Numeric field to apply the metric to.
    /// </summary>
    [JsonPropertyName("targetField")]
    public required NumericConversationField TargetField { get; set; }

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

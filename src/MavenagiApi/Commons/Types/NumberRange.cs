using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

/// <summary>
/// A range of numbers that can be used to filter search results by numeric fields.
/// - `greaterThanOrEqual`: The minimum value (inclusive).
/// - `lessThan`: The maximum value (exclusive).
/// </summary>
[Serializable]
public record NumberRange : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("greaterThanOrEqual")]
    public int? GreaterThanOrEqual { get; set; }

    [JsonPropertyName("lessThan")]
    public int? LessThan { get; set; }

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

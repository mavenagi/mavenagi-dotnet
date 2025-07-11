using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record TagsPrecondition : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The tags that must be present in the conversation context for the precondition to be met
    /// </summary>
    [JsonPropertyName("tags")]
    public HashSet<string> Tags { get; set; } = new HashSet<string>();

    /// <summary>
    /// Operator to apply to this precondition
    /// </summary>
    [JsonPropertyName("operator")]
    public PreconditionOperator? Operator { get; set; }

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

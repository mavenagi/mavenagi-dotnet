using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ResponseConfigPrecondition : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("useMarkdown")]
    public bool? UseMarkdown { get; set; }

    [JsonPropertyName("useForms")]
    public bool? UseForms { get; set; }

    [JsonPropertyName("useImages")]
    public bool? UseImages { get; set; }

    [JsonPropertyName("isCopilot")]
    public bool? IsCopilot { get; set; }

    [JsonPropertyName("responseLength")]
    public ResponseLength? ResponseLength { get; set; }

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

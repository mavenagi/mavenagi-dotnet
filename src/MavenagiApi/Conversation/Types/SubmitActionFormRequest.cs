using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record SubmitActionFormRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("actionFormId")]
    public required string ActionFormId { get; set; }

    /// <summary>
    /// Map of parameter IDs to values provided by the user. All required action fields must be provided.
    /// </summary>
    [JsonPropertyName("parameters")]
    public Dictionary<string, object?> Parameters { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// Transient data which the Maven platform will not persist. This data will only be forwarded to actions taken. For example, one may put in user tokens as transient data.
    /// </summary>
    [JsonPropertyName("transientData")]
    public Dictionary<string, string>? TransientData { get; set; }

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

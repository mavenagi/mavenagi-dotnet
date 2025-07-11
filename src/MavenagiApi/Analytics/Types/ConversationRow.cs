using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ConversationRow : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A unique identifier for each row, consisting of field names mapped to their respective values.
    /// This includes time groupings and any specified field groupings.
    /// </summary>
    [JsonPropertyName("identifier")]
    public Dictionary<ConversationField, FieldValue> Identifier { get; set; } =
        new Dictionary<ConversationField, FieldValue>();

    /// <summary>
    /// The actual row data, where keys represent column headers and values contain the respective metric results.
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, CellData> Data { get; set; } = new Dictionary<string, CellData>();

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

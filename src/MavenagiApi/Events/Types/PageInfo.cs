using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record PageInfo : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("pageName")]
    public required string PageName { get; set; }

    [JsonPropertyName("pageUrl")]
    public string? PageUrl { get; set; }

    [JsonPropertyName("pageTitle")]
    public string? PageTitle { get; set; }

    [JsonPropertyName("linkUrl")]
    public string? LinkUrl { get; set; }

    [JsonPropertyName("elementId")]
    public string? ElementId { get; set; }

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

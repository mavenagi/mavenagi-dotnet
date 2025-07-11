using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record FinalizeKnowledgeBaseVersionRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ID that uniquely identifies which knowledge base version to finalize. If not provided will use the most recent version of the knowledge base.
    /// </summary>
    [JsonPropertyName("versionId")]
    public EntityIdWithoutAgent? VersionId { get; set; }

    /// <summary>
    /// Whether the knowledge base version processing was successful or not.
    /// </summary>
    [JsonPropertyName("status")]
    public KnowledgeBaseVersionFinalizeStatus? Status { get; set; }

    /// <summary>
    /// A user-facing error message that provides more details about a version failure.
    /// </summary>
    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

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

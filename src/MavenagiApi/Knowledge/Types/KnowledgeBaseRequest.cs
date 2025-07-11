using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record KnowledgeBaseRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ID that uniquely identifies this knowledge base
    /// </summary>
    [JsonPropertyName("knowledgeBaseId")]
    public required EntityIdBase KnowledgeBaseId { get; set; }

    /// <summary>
    /// Metadata for the knowledge base.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }

    /// <summary>
    /// The name of the knowledge base
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// (Beta) The preconditions that must be met for knowledge base be relevant to a conversation. Can be used to limit knowledge to certain types of users.
    /// </summary>
    [JsonPropertyName("precondition")]
    public Precondition? Precondition { get; set; }

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

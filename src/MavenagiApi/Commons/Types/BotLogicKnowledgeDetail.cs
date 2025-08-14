using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record BotLogicKnowledgeDetail
{
    [JsonPropertyName("knowledgeBaseId")]
    public required EntityIdWithoutAgent KnowledgeBaseId { get; set; }

    [JsonPropertyName("documentId")]
    public required EntityIdWithoutAgent DocumentId { get; set; }

    [JsonPropertyName("documentName")]
    public required string DocumentName { get; set; }

    [JsonPropertyName("documentExcerpt")]
    public required string DocumentExcerpt { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

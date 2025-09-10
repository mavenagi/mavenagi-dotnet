using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record KnowledgeBaseVersionsListResponse
{
    /// <summary>
    /// The active knowledge base versions for the knowledge base. Includes all versions within the last 90 days or the last 10, whichever is greater.
    /// </summary>
    [JsonPropertyName("knowledgeBaseVersions")]
    public IEnumerable<KnowledgeBaseVersion> KnowledgeBaseVersions { get; set; } =
        new List<KnowledgeBaseVersion>();

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

using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record BotLogicKnowledgeItem
{
    [JsonPropertyName("knowledgeReviewed")]
    public IEnumerable<BotLogicKnowledgeDetail> KnowledgeReviewed { get; set; } =
        new List<BotLogicKnowledgeDetail>();

    [JsonPropertyName("knowledgeUtilized")]
    public IEnumerable<BotLogicKnowledgeDetail> KnowledgeUtilized { get; set; } =
        new List<BotLogicKnowledgeDetail>();

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

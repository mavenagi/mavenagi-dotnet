using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record BotLogicActionItem
{
    [JsonPropertyName("actionsReviewed")]
    public IEnumerable<BotLogicActionReviewedDetail> ActionsReviewed { get; set; } =
        new List<BotLogicActionReviewedDetail>();

    [JsonPropertyName("actionsExecuted")]
    public IEnumerable<BotLogicActionExecutedDetail> ActionsExecuted { get; set; } =
        new List<BotLogicActionExecutedDetail>();

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

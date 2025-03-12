using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record ConversationExecutedActionPrecondition
{
    /// <summary>
    /// ID of an action that must have executed in this conversation for the precondition to be met
    /// </summary>
    [JsonPropertyName("actionId")]
    public required string ActionId { get; set; }

    /// <summary>
    /// App ID that the given actionId belongs to. If not provided, the calling appId will be used.
    /// </summary>
    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    /// <summary>
    /// Operator to apply to this precondition
    /// </summary>
    [JsonPropertyName("operator")]
    public PreconditionOperator? Operator { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

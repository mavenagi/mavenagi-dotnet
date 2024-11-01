using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record TagsPrecondition
{
    /// <summary>
    /// The tags that must be present in the conversation context for the precondition to be met
    /// </summary>
    [JsonPropertyName("tags")]
    public HashSet<string> Tags { get; set; } = new HashSet<string>();

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

using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record PreconditionBase
{
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

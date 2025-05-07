using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record AppPrecondition
{
    /// <summary>
    /// Match only conversations created by this appId
    /// </summary>
    [JsonPropertyName("appId")]
    public required string AppId { get; set; }

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

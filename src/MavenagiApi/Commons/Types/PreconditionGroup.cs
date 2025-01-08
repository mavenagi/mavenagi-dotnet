using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record PreconditionGroup
{
    [JsonPropertyName("operator")]
    public required PreconditionGroupOperator Operator { get; set; }

    [JsonPropertyName("preconditions")]
    public IEnumerable<object> Preconditions { get; set; } = new List<object>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

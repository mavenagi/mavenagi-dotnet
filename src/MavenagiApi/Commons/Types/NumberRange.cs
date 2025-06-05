using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record NumberRange
{
    [JsonPropertyName("greaterThanOrEqual")]
    public int? GreaterThanOrEqual { get; set; }

    [JsonPropertyName("lessThan")]
    public int? LessThan { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

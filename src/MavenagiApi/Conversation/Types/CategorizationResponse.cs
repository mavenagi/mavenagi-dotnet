using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record CategorizationResponse
{
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

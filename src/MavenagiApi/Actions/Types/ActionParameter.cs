using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record ActionParameter
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("label")]
    public required string Label { get; set; }

    [JsonPropertyName("description")]
    public required string Description { get; set; }

    [JsonPropertyName("required")]
    public required bool Required { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

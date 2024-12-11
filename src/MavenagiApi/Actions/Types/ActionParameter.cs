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

    /// <summary>
    /// The parameter type. Values provided to executeAction will conform to this type. Defaults to STRING.
    /// </summary>
    [JsonPropertyName("type")]
    public ActionParameterType? Type { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record BotObjectResponse
{
    /// <summary>
    /// A human-readable name for the generated object, for use in the UI.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    /// <summary>
    /// The generated object conforming to the provided schema.
    /// </summary>
    [JsonPropertyName("object")]
    public required object Object { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

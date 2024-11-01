using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record UserData
{
    /// <summary>
    /// The value of the user metadata
    /// </summary>
    [JsonPropertyName("value")]
    public required string Value { get; set; }

    /// <summary>
    /// The visibility of the user metadata
    /// </summary>
    [JsonPropertyName("visibility")]
    public required VisibilityType Visibility { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

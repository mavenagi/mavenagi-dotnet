using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record AppUserIdentifier
{
    /// <summary>
    /// The identifying property text
    /// </summary>
    [JsonPropertyName("value")]
    public required string Value { get; set; }

    [JsonPropertyName("type")]
    public required AppUserIdentifyingPropertyType Type { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

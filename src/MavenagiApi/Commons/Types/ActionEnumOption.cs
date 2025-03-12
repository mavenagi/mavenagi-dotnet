using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record ActionEnumOption
{
    /// <summary>
    /// Will be shown during form display as the user facing string in a dropdown or radio.
    /// </summary>
    [JsonPropertyName("label")]
    public required string Label { get; set; }

    /// <summary>
    /// A valid value for the field.
    /// </summary>
    [JsonPropertyName("value")]
    public required object Value { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

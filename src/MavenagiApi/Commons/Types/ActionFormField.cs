using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ActionFormField : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID field should be used as the key in the `submitActionForm` API.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The title of the field to show on the form. Provided in the user's language.
    /// </summary>
    [JsonPropertyName("label")]
    public required string Label { get; set; }

    /// <summary>
    /// A longer description of the field which should be shown in smaller text near the label. Provided in the user's language.
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// Whether the field is required for the action. Client side validation is recommended for an improved user experience.
    /// </summary>
    [JsonPropertyName("required")]
    public required bool Required { get; set; }

    /// <summary>
    /// A value for the field provided by the LLM. All form fields should default to this value if present.
    /// </summary>
    [JsonPropertyName("suggestion")]
    public object? Suggestion { get; set; }

    /// <summary>
    /// Describes how the action field should be validated. Client side validation is recommended but not required. | If `enumOptions` are provided, using a dropdown or radio field is preferred. Otherwise, if the `type` is `BOOLEAN` a checkbox is preferred. | Fallback to a text input.
    /// </summary>
    [JsonPropertyName("type")]
    public required ActionParameterType Type { get; set; }

    /// <summary>
    /// The options that should be shown to the user as a dropdown or radio.
    /// </summary>
    [JsonPropertyName("enumOptions")]
    public IEnumerable<ActionEnumOption>? EnumOptions { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

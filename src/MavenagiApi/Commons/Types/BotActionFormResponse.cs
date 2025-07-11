using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

/// <summary>
/// This response should be rendered as a form which users can submit. Upon submission call the `submitActionForm` API.
/// </summary>
[Serializable]
public record BotActionFormResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID to use when submitting the form via the `submitActionForm` API.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The ID of the action that will be executed when the form is submitted.
    /// </summary>
    [JsonPropertyName("actionId")]
    public required EntityIdWithoutAgent ActionId { get; set; }

    /// <summary>
    /// Text which should be displayed to the user at the top of the form. Provided in the user's language.
    /// </summary>
    [JsonPropertyName("formLabel")]
    public required string FormLabel { get; set; }

    /// <summary>
    /// The fields that should be displayed within the form.
    /// </summary>
    [JsonPropertyName("fields")]
    public IEnumerable<ActionFormField> Fields { get; set; } = new List<ActionFormField>();

    /// <summary>
    /// Text that should be displayed to the user on the submit button. Provided in the user's language.
    /// </summary>
    [JsonPropertyName("submitLabel")]
    public required string SubmitLabel { get; set; }

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

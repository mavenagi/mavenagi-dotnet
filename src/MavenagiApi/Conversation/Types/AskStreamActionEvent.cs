using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record AskStreamActionEvent
{
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

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

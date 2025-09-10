using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ActionParameter
{
    /// <summary>
    /// The ID field will be used when parameters are supplied to `executeAction`.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The title of the field that will be shown on action forms.
    /// </summary>
    [JsonPropertyName("label")]
    public required string Label { get; set; }

    /// <summary>
    /// A longer description of the field which will be shown in smaller text near the label on action forms.
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// Whether the field is required for action execution.
    /// </summary>
    [JsonPropertyName("required")]
    public required bool Required { get; set; }

    /// <summary>
    /// When user interaction is required, whether this parameter should be excluded from forms. Hidden parameters are not displayed to users but their values are still populated by the LLM and sent to actions. Defaults to false.
    /// </summary>
    [JsonPropertyName("hidden")]
    public bool? Hidden { get; set; }

    /// <summary>
    /// The parameter type. Values provided to `executeAction` will conform to this type. Defaults to `STRING`.
    /// </summary>
    [JsonPropertyName("type")]
    public ActionParameterType? Type { get; set; }

    /// <summary>
    /// Restricts the action parameter to only the options in this list. Valid for type `STRING`, `BOOLEAN`, and `NUMBER`. Should not be used when type is `SCHEMA`.
    /// </summary>
    [JsonPropertyName("enumOptions")]
    public IEnumerable<ActionEnumOption>? EnumOptions { get; set; }

    /// <summary>
    /// JSON schema for validating the parameter value. Only valid when type is `SCHEMA`.
    /// </summary>
    [JsonPropertyName("schema")]
    public string? Schema { get; set; }

    /// <summary>
    /// OAuth configuration required to start an OAuth authorization flow when this parameter's type is `OAUTH`.
    /// </summary>
    [JsonPropertyName("oauthConfiguration")]
    public ActionOAuthConfiguration? OauthConfiguration { get; set; }

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

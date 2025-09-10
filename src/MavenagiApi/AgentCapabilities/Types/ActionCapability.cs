using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ActionCapability
{
    [JsonPropertyName("userInteractionRequired")]
    public required bool UserInteractionRequired { get; set; }

    /// <summary>
    /// When user interaction is required, the name of the button that is shown to the end user to confirm execution of the action. Defaults to "Submit" if not supplied.
    /// </summary>
    [JsonPropertyName("buttonName")]
    public string? ButtonName { get; set; }

    /// <summary>
    /// The parameters that the action uses as input. An action will only be executed when all of the required parameters are provided. Parameter values may be inferred from the user's conversation by the LLM.
    /// </summary>
    [JsonPropertyName("userFormParameters")]
    public IEnumerable<ActionParameter> UserFormParameters { get; set; } =
        new List<ActionParameter>();

    [JsonPropertyName("precondition")]
    public object? Precondition { get; set; }

    [JsonPropertyName("descriptionOverride")]
    public string? DescriptionOverride { get; set; }

    /// <summary>
    /// A human-readable explanation of the precondition associated with this action, if present.
    /// </summary>
    [JsonPropertyName("preconditionExplanation")]
    public string? PreconditionExplanation { get; set; }

    [JsonPropertyName("pinned")]
    public required bool Pinned { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Timestamp when the capability was created
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Whether this capability will be called by Maven.
    /// </summary>
    [JsonPropertyName("enabled")]
    public required bool Enabled { get; set; }

    [JsonPropertyName("version")]
    public required int Version { get; set; }

    /// <summary>
    /// ID that uniquely identifies this capability
    /// </summary>
    [JsonPropertyName("capabilityId")]
    public required EntityId CapabilityId { get; set; }

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

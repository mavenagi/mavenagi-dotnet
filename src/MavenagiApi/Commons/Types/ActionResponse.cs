using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ActionResponse
{
    /// <summary>
    /// ID that uniquely identifies this action
    /// </summary>
    [JsonPropertyName("actionId")]
    public required EntityId ActionId { get; set; }

    /// <summary>
    /// The instructions given to the LLM when determining whether to execute the action.
    /// This field defaults to the `description` field if not provided. Use the `patch` API to update.
    /// </summary>
    [JsonPropertyName("instructions")]
    public string? Instructions { get; set; }

    /// <summary>
    /// Determines whether the action is sent to the LLM as part of a conversation.
    ///
    /// - `ALWAYS`: The action is always available for use in conversations, textual relevance is not considered.
    /// - `WHEN_RELEVANT`: The action is available only in conversations where the action is determined to be relevant to the user's question.
    /// - `NEVER`: The action is not available for use in conversations.
    /// </summary>
    [JsonPropertyName("llmInclusionStatus")]
    public required LlmInclusionStatus LlmInclusionStatus { get; set; }

    /// <summary>
    /// The IDs of the segment that must be matched for the action to be relevant to a conversation.
    /// Segments are replacing inline preconditions - an Action may not have both an inline precondition and a segment.
    /// Inline precondition support will be removed in a future release.
    /// </summary>
    [JsonPropertyName("segmentId")]
    public EntityId? SegmentId { get; set; }

    /// <summary>
    /// A human-readable explanation of the precondition associated with this action, if present.
    /// </summary>
    [JsonPropertyName("preconditionExplanation")]
    public string? PreconditionExplanation { get; set; }

    /// <summary>
    /// Whether the action has been deleted. Deleted actions will not sent to the LLM nor returned in search results.
    /// </summary>
    [JsonPropertyName("deleted")]
    public required bool Deleted { get; set; }

    /// <summary>
    /// The name of the action. This is displayed to the end user as part of forms when user interaction is required. It is also used to help Maven decide if the action is relevant to a conversation.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The description of the action. Must be less than 1024 characters. This helps Maven decide if the action is relevant to a conversation and is not displayed directly to the end user. Descriptions are used by the LLM.
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// Whether the action requires user interaction to execute. If false, and all of the required action parameters are known, the LLM may call the action automatically. If true, an conversations ask call will return a BotActionFormResponse which must be submitted by an API caller. API callers must display a button with the buttonName label to confirm the user's intent.
    /// </summary>
    [JsonPropertyName("userInteractionRequired")]
    public required bool UserInteractionRequired { get; set; }

    /// <summary>
    /// When user interaction is required, the name of the button that is shown to the end user to confirm execution of the action. Defaults to "Submit" if not supplied.
    /// </summary>
    [JsonPropertyName("buttonName")]
    public string? ButtonName { get; set; }

    /// <summary>
    /// The preconditions that must be met for an action to be relevant to a conversation. Can be used to restrict actions to certain types of users.
    /// </summary>
    [JsonPropertyName("precondition")]
    public object? Precondition { get; set; }

    /// <summary>
    /// The parameters that the action uses as input. An action will only be executed when all of the required parameters are provided. During execution, actions all have access to the full Conversation and User objects. Parameter values may be inferred from the user's conversation by the LLM.
    /// </summary>
    [JsonPropertyName("userFormParameters")]
    public IEnumerable<ActionParameter> UserFormParameters { get; set; } =
        new List<ActionParameter>();

    /// <summary>
    /// The ISO 639-1 code for the language used in all fields of this action. Will be derived using the description's text if not specified.
    /// </summary>
    [JsonPropertyName("language")]
    public string? Language { get; set; }

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

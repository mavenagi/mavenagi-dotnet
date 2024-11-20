using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record ActionBase
{
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
    /// When user interaction is required, the name of the button that is shown to the end user to confirm execution of the action
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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

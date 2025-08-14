using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ConversationSummary
{
    /// <summary>
    /// The IDs of the actions that were taken by Maven in the conversation
    /// </summary>
    [JsonPropertyName("actionIds")]
    public IEnumerable<EntityIdWithoutAgent> ActionIds { get; set; } =
        new List<EntityIdWithoutAgent>();

    /// <summary>
    /// The IDs of the actions that were taken by Maven but not completed in the conversation. Occurs when the user is shown an action form but does not submit it.
    /// </summary>
    [JsonPropertyName("incompleteActionIds")]
    public IEnumerable<EntityIdWithoutAgent> IncompleteActionIds { get; set; } =
        new List<EntityIdWithoutAgent>();

    /// <summary>
    /// The number of insert events on messages in the conversation.
    /// </summary>
    [JsonPropertyName("insertCount")]
    public required int InsertCount { get; set; }

    /// <summary>
    /// The number of thumbs up events on messages in the conversation.
    /// </summary>
    [JsonPropertyName("thumbsUpCount")]
    public required int ThumbsUpCount { get; set; }

    /// <summary>
    /// The number of thumbs down events on messages in the conversation.
    /// </summary>
    [JsonPropertyName("thumbsDownCount")]
    public required int ThumbsDownCount { get; set; }

    /// <summary>
    /// The number of messages of type `USER` in the conversation.
    /// </summary>
    [JsonPropertyName("userMessageCount")]
    public required int UserMessageCount { get; set; }

    /// <summary>
    /// The total time in milliseconds that the user spent interacting with the conversation.
    /// Calculated by taking the timestamp of the last message in the conversation minus the timestamp of the first message.
    /// </summary>
    [JsonPropertyName("handleTime")]
    public long? HandleTime { get; set; }

    /// <summary>
    /// The time in milliseconds that elapsed before a human agent responded to the conversation.
    /// Calculated by taking the timestamp of the first message of type `HUMAN_AGENT`
    /// minus the timestamp of the first message in the conversation.
    ///
    /// Will not be provided if the conversation does not have a message of type `HUMAN_AGENT`.
    /// </summary>
    [JsonPropertyName("humanAgentResponseDelay")]
    public long? HumanAgentResponseDelay { get; set; }

    /// <summary>
    /// The names of all users that have a message of type `HUMAN_AGENT` on the conversation.
    /// </summary>
    [JsonPropertyName("humanAgents")]
    public IEnumerable<string> HumanAgents { get; set; } = new List<string>();

    /// <summary>
    /// The names of all users that have an associated insert event on the conversation.
    /// </summary>
    [JsonPropertyName("humanAgentsWithInserts")]
    public IEnumerable<string> HumanAgentsWithInserts { get; set; } = new List<string>();

    /// <summary>
    /// The names of all users that have a message of type `USER` on the conversation.
    /// </summary>
    [JsonPropertyName("users")]
    public IEnumerable<string> Users { get; set; } = new List<string>();

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

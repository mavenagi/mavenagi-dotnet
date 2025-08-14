using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record EventTriggerResponse
{
    /// <summary>
    /// ID that uniquely identifies this event trigger
    /// </summary>
    [JsonPropertyName("triggerId")]
    public required EntityId TriggerId { get; set; }

    /// <summary>
    /// Whether this trigger will be called by Maven.
    /// </summary>
    [JsonPropertyName("enabled")]
    public required bool Enabled { get; set; }

    /// <summary>
    /// The description of what the event trigger does, shown in the Maven Dashboard
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// The type of event trigger this app wishes to handle.
    ///
    /// Conversation triggers fire when a conversation is created, after each additional message, and upon deletion events.
    /// There is a small delay before trigger execution to allow time for conversation analysis to complete.
    ///
    /// Feedback can not be modified, so the feedback trigger fires immediately after feedback is created.
    /// </summary>
    [JsonPropertyName("type")]
    public required EventTriggerType Type { get; set; }

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

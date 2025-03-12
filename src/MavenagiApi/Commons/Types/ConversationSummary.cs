using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

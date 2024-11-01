using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record EventTriggerResponse
{
    /// <summary>
    /// ID that uniquely identifies this event trigger
    /// </summary>
    [JsonPropertyName("triggerId")]
    public required EntityId TriggerId { get; set; }

    /// <summary>
    /// The description of what the event trigger does, shown in the Maven Dashboard
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// The type of event trigger this app wishes to handle
    /// </summary>
    [JsonPropertyName("type")]
    public required EventTriggerType Type { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

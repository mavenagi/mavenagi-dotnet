using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record EventTriggerBase : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

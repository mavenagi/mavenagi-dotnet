using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record ConversationMetadata
{
    /// <summary>
    /// All metadata for the conversation. Keyed by appId.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, Dictionary<string, string>> Metadata { get; set; } =
        new Dictionary<string, Dictionary<string, string>>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

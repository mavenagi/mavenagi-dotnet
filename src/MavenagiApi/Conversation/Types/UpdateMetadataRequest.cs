using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record UpdateMetadataRequest
{
    /// <summary>
    /// The App ID of the conversation to modify metadata for. If not provided the ID of the calling app will be used.
    /// </summary>
    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    /// <summary>
    /// The metadata values to add to the conversation.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, string> Values { get; set; } = new Dictionary<string, string>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record UserMessageAttachment
{
    /// <summary>
    /// The URL to access the attachment, The URL will be valid for 20 minutes.
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

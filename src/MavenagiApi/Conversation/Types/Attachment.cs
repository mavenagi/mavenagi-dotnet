using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record Attachment
{
    /// <summary>
    /// The mime-type of the attachment. Supported types are {image/jpeg, image/jpg, image/png, image/gif, image/webp}.
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// The attachment data.
    /// </summary>
    [JsonPropertyName("content")]
    public required string Content { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record BaseAttachment
{
    /// <summary>
    /// The mime-type of the attachment. Supported types are:
    /// - image/jpeg
    /// - image/jpg
    /// - image/png
    /// - image/gif
    /// - image/webp
    /// - application/pdf
    /// - text/plain
    /// - text/csv
    /// - application/vnd.openxmlformats-officedocument.wordprocessingml.document
    /// - application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
    /// - application/vnd.openxmlformats-officedocument.presentationml.presentation
    /// - application/msword
    /// - application/vnd.ms-excel
    /// - application/vnd.ms-powerpoint
    /// - audio/aac
    /// - audio/mpeg
    /// - audio/mp4
    /// - audio/wav
    /// - audio/ogg
    /// - video/mp4
    /// - video/webm
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// An optional name for the attachment.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

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

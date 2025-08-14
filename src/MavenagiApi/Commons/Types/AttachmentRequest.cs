using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

/// <summary>
/// Attachments can be created either with inline data (up to 5MB) using the `content` field or by
/// referencing an asynchronously uploaded asset using the `assetId` field.
///
/// See the Assets APIs for more details on how to upload assets and get an asset ID.
///
/// &lt;Tip&gt;
///   Due to backwards compatibility, both the `type` field and the `name` field are present when attaching an Asset by ID.
///   These fields will be ignored in favor of the values supplied during the initial Asset upload.
///   They are only used for inline content uploads.
/// &lt;/Tip&gt;
/// </summary>
[Serializable]
public record AttachmentRequest
{
    /// <summary>
    /// Inline attachment data, up to 5MB.
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    /// <summary>
    /// The ID of an asynchronously uploaded asset.
    /// </summary>
    [JsonPropertyName("assetId")]
    public EntityIdBase? AssetId { get; set; }

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

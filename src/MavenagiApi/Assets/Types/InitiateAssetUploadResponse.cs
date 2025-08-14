using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record InitiateAssetUploadResponse
{
    /// <summary>
    /// The ID of the asset. Use this ID to commit the asset after upload.
    /// </summary>
    [JsonPropertyName("assetId")]
    public required EntityIdBase AssetId { get; set; }

    /// <summary>
    /// Pre-signed URL for file upload. Use this URL to upload the file directly to storage.
    /// </summary>
    [JsonPropertyName("uploadUrl")]
    public required string UploadUrl { get; set; }

    /// <summary>
    /// The expiration time for the upload URL
    /// </summary>
    [JsonPropertyName("expiresAt")]
    public required DateTime ExpiresAt { get; set; }

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

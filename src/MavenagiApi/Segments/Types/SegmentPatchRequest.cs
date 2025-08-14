using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record SegmentPatchRequest
{
    /// <summary>
    /// The App ID of the segment to update. If not provided, the ID of the calling app will be used.
    /// </summary>
    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    /// <summary>
    /// The name of the segment.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The precondition that must be met for a conversation message to be included in the segment.
    /// </summary>
    [JsonPropertyName("precondition")]
    public object? Precondition { get; set; }

    /// <summary>
    /// The status of the segment. Segments can only be deactivated if they are not set on any actions or active knowledge bases.
    /// </summary>
    [JsonPropertyName("status")]
    public SegmentStatus? Status { get; set; }

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

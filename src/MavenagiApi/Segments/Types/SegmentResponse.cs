using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record SegmentResponse
{
    /// <summary>
    /// ID that uniquely identifies this segment
    /// </summary>
    [JsonPropertyName("segmentId")]
    public required EntityId SegmentId { get; set; }

    /// <summary>
    /// Whether or not the segment is in active use. To preserve historical data, segments can not be deleted.
    ///
    /// Only active segments will be evaluated for matching user questions.
    /// </summary>
    [JsonPropertyName("status")]
    public required SegmentStatus Status { get; set; }

    /// <summary>
    /// The name of the segment.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The precondition that must be met for a conversation message to be included in the segment.
    /// </summary>
    [JsonPropertyName("precondition")]
    public required object Precondition { get; set; }

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

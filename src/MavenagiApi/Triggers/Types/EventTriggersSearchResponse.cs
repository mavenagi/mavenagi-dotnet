using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record EventTriggersSearchResponse
{
    [JsonPropertyName("triggers")]
    public IEnumerable<EventTriggerResponse> Triggers { get; set; } =
        new List<EventTriggerResponse>();

    /// <summary>
    /// The page being returned, starts at 0
    /// </summary>
    [JsonPropertyName("number")]
    public required int Number { get; set; }

    /// <summary>
    /// The number of elements in this page
    /// </summary>
    [JsonPropertyName("size")]
    public required int Size { get; set; }

    /// <summary>
    /// The total number of elements in the collection
    /// </summary>
    [JsonPropertyName("totalElements")]
    public required long TotalElements { get; set; }

    /// <summary>
    /// The total number of pages in the collection
    /// </summary>
    [JsonPropertyName("totalPages")]
    public required int TotalPages { get; set; }

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

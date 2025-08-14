using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record KnowledgeBaseFilter
{
    /// <summary>
    /// Full-text search query for matching knowledge bases by content.
    /// When you search with this parameter, you're performing a full-text search across the knowledge title, tags and metadata.
    ///
    /// This field also supports a syntax for advanced filtering the `metadata` field.
    ///
    /// Metadata examples:
    /// - `metadata:myvalue` - matches knowledge bases with any metadata field set to `myvalue`
    /// - `metadata.mykey:myvalue` - matches knowledge bases with a metadata field `mykey` set to `myvalue`
    /// - `metadata.mykey:myvalue OR anothervalue` - matches knowledge bases with a metadata field `mykey` set to `myvalue` or `anothervalue`
    /// - `metadata.mykey:*` - matches knowledge bases with a metadata field `mykey`
    /// - `-metadata:myvalue` - matches knowledge bases that do not have any metadata field set to `myvalue`
    /// - `_exists_:metadata` - matches knowledge bases that have any metadata field set
    /// </summary>
    [JsonPropertyName("search")]
    public string? Search { get; set; }

    /// <summary>
    /// Filter by title
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Filter knowledge bases created on or after this timestamp
    /// </summary>
    [JsonPropertyName("createdAfter")]
    public DateTime? CreatedAfter { get; set; }

    /// <summary>
    /// Filter knowledge bases created on or before this timestamp
    /// </summary>
    [JsonPropertyName("createdBefore")]
    public DateTime? CreatedBefore { get; set; }

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

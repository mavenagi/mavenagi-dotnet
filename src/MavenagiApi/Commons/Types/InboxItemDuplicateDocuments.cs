using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record InboxItemDuplicateDocuments
{
    /// <summary>
    /// The fix recommended for being applied
    /// </summary>
    [JsonPropertyName("recommendedFixes")]
    public IEnumerable<InboxItemFixDeactivateDocument> RecommendedFixes { get; set; } =
        new List<InboxItemFixDeactivateDocument>();

    /// <summary>
    /// List of fixes associated with the inbox item.
    /// </summary>
    [JsonPropertyName("otherFixes")]
    public IEnumerable<InboxItemFixDeactivateDocument> OtherFixes { get; set; } =
        new List<InboxItemFixDeactivateDocument>();

    /// <summary>
    /// Information about the source document associated with the inbox item.
    /// </summary>
    [JsonPropertyName("sourceDocument")]
    public required DocumentInformation SourceDocument { get; set; }

    /// <summary>
    /// List of Document information objects related to the inbox item.
    /// </summary>
    [JsonPropertyName("documents")]
    public IEnumerable<DocumentInformation> Documents { get; set; } =
        new List<DocumentInformation>();

    /// <summary>
    /// Unique identifier for the inbox item.
    /// </summary>
    [JsonPropertyName("id")]
    public required EntityId Id { get; set; }

    /// <summary>
    /// Timestamp when the inbox item was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Timestamp when the inbox item was last updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Status of the inbox item.
    /// </summary>
    [JsonPropertyName("status")]
    public required InboxItemStatus Status { get; set; }

    /// <summary>
    /// Severity of the inbox item.
    /// </summary>
    [JsonPropertyName("severity")]
    public required InboxItemSeverity Severity { get; set; }

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

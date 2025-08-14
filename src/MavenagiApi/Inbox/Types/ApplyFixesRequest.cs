using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ApplyFixesRequest
{
    /// <summary>
    /// The appId of the inbox item and fixes.
    /// </summary>
    [JsonPropertyName("appId")]
    public required string AppId { get; set; }

    /// <summary>
    /// A list of one or more reference IDs of fixes to apply. All must belong to the same inbox item.
    /// </summary>
    [JsonPropertyName("fixReferenceIds")]
    public IEnumerable<string> FixReferenceIds { get; set; } = new List<string>();

    /// <summary>
    /// Only applies to add document fixes, includes the document content to save.
    /// </summary>
    [JsonPropertyName("addDocumentRequest")]
    public AddDocumentFixRequest? AddDocumentRequest { get; set; }

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

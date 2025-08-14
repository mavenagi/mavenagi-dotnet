using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record InboxItemFixAddDocument
{
    /// <summary>
    /// Suggested document title if the fix type is ADD_DOCUMENT.
    /// </summary>
    [JsonPropertyName("suggestedTextTitle")]
    public required string SuggestedTextTitle { get; set; }

    /// <summary>
    /// Suggested document text if the fix type is ADD_DOCUMENT.
    /// </summary>
    [JsonPropertyName("suggestedText")]
    public required string SuggestedText { get; set; }

    /// <summary>
    /// Unique identifier for the inbox item fix.
    /// </summary>
    [JsonPropertyName("id")]
    public required EntityId Id { get; set; }

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

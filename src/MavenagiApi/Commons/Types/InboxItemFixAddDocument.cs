using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

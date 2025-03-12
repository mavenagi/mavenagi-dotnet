using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record DocumentInformation
{
    /// <summary>
    /// Unique identifier for the document.
    /// </summary>
    [JsonPropertyName("documentId")]
    public required EntityIdWithoutAgent DocumentId { get; set; }

    /// <summary>
    /// Title of the document.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Snippet or summary of the document.
    /// </summary>
    [JsonPropertyName("snippet")]
    public string? Snippet { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

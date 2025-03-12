using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record InboxItemFixDeactivateDocument
{
    /// <summary>
    /// Information about the document associated with this fix.
    /// </summary>
    [JsonPropertyName("documentInformation")]
    public required DocumentInformation DocumentInformation { get; set; }

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

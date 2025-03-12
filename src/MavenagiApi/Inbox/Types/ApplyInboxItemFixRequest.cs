using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record ApplyInboxItemFixRequest
{
    [JsonPropertyName("appId")]
    public required string AppId { get; set; }

    /// <summary>
    /// Content for Add Document fixes
    /// </summary>
    [JsonPropertyName("addDocumentRequest")]
    public AddDocumentFixRequest? AddDocumentRequest { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

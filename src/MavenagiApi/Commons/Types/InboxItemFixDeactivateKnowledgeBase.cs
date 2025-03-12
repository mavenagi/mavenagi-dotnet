using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record InboxItemFixDeactivateKnowledgeBase
{
    /// <summary>
    /// The knowledge base associated with this fix.
    /// </summary>
    [JsonPropertyName("knowledgeBase")]
    public required KnowledgeBaseInformation KnowledgeBase { get; set; }

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

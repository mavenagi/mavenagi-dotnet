using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record GenerateMavenSuggestionsRequest
{
    /// <summary>
    /// The message ids to generate a suggested response for. One suggestion will be generated for each message id.
    /// </summary>
    [JsonPropertyName("conversationMessageIds")]
    public IEnumerable<EntityIdBase> ConversationMessageIds { get; set; } =
        new List<EntityIdBase>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

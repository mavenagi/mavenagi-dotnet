using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record ConversationAnalysis
{
    /// <summary>
    /// Generated user request summary of the conversation
    /// </summary>
    [JsonPropertyName("userRequest")]
    public string? UserRequest { get; set; }

    /// <summary>
    /// Generated agent response summary of the conversation
    /// </summary>
    [JsonPropertyName("agentResponse")]
    public string? AgentResponse { get; set; }

    /// <summary>
    /// Generated resolution status of the conversation
    /// </summary>
    [JsonPropertyName("resolutionStatus")]
    public string? ResolutionStatus { get; set; }

    /// <summary>
    /// Generated category of the conversation
    /// </summary>
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    /// <summary>
    /// Generated sentiment of the conversation
    /// </summary>
    [JsonPropertyName("sentiment")]
    public Sentiment? Sentiment { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

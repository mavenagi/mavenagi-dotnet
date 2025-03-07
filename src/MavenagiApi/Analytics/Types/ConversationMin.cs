using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record ConversationMin
{
    /// <summary>
    /// Numeric field to apply the metric to.
    /// </summary>
    [JsonPropertyName("targetField")]
    public required NumericConversationField TargetField { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

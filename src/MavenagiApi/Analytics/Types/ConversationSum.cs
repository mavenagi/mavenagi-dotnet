using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record ConversationSum
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

using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record ConversationColumnDefinition
{
    /// <summary>
    /// The metric calculated for this column, stored in the row data under the specified header.
    /// </summary>
    [JsonPropertyName("metric")]
    public required object Metric { get; set; }

    /// <summary>
    /// Unique column header, serving as the key for corresponding metric values.
    /// </summary>
    [JsonPropertyName("header")]
    public required string Header { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

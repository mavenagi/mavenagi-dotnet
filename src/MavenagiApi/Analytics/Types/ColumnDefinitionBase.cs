using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record ColumnDefinitionBase
{
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

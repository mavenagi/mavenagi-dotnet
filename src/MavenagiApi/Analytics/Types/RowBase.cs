using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record RowBase
{
    /// <summary>
    /// The actual row data, where keys represent column headers and values contain the respective metric results.
    /// </summary>
    [JsonPropertyName("data")]
    public object Data { get; set; } = new Dictionary<string, object?>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

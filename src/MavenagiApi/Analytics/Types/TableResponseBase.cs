using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record TableResponseBase
{
    /// <summary>
    /// Column headers in the table, aligning with the column definitions specified in the request.
    /// </summary>
    [JsonPropertyName("headers")]
    public IEnumerable<string> Headers { get; set; } = new List<string>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record ResponseConfig
{
    /// <summary>
    /// List of capabilities supported by the caller. Defaults to all. Only the markdown capability is supported at this time. If not provided, responses will be plain text.
    /// </summary>
    [JsonPropertyName("capabilities")]
    public IEnumerable<Capability> Capabilities { get; set; } = new List<Capability>();

    /// <summary>
    /// Whether the response is for an human agent (true) or an end user (false). Defaults to false.
    /// </summary>
    [JsonPropertyName("isCopilot")]
    public required bool IsCopilot { get; set; }

    /// <summary>
    /// The desired response length. Defaults to ResponseLength.MEDIUM.
    /// </summary>
    [JsonPropertyName("responseLength")]
    public required ResponseLength ResponseLength { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

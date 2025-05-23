using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record ControlEvent
{
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    /// not used.
    /// </summary>
    [JsonPropertyName("unused")]
    public AudioFormat? Unused { get; set; }

    [JsonPropertyName("seqId")]
    public int? SeqId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

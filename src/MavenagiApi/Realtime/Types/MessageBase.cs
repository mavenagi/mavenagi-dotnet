using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record MessageBase
{
    [JsonPropertyName("seqId")]
    public int? SeqId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

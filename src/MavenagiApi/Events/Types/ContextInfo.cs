using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record ContextInfo
{
    [JsonPropertyName("additionalData")]
    public Dictionary<string, string> AdditionalData { get; set; } =
        new Dictionary<string, string>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

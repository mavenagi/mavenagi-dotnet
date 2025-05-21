using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record UserInfo
{
    [JsonPropertyName("id")]
    public EntityId? Id { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record EntityIdFilter
{
    [JsonPropertyName("referenceId")]
    public required string ReferenceId { get; set; }

    [JsonPropertyName("appId")]
    public required string AppId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record TriggerPartialUpdate
{
    /// <summary>
    /// Whether the trigger will be called by Maven.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

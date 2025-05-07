using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record PartialUpdateRequest
{
    /// <summary>
    /// The App ID of the trigger to update. If not provided, the ID of the calling app will be used.
    /// </summary>
    [JsonIgnore]
    public string? AppId { get; set; }

    public required TriggerPartialUpdate Body { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

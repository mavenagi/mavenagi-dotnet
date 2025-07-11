using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record SearchAppSettingsRequest
{
    /// <summary>
    /// Will return all settings which have the `$index` key set to the provided value.
    /// </summary>
    [JsonIgnore]
    public required string Index { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

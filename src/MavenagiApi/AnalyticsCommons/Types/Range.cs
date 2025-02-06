using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record Range
{
    /// <summary>
    /// Lower bound of the range (inclusive).
    /// </summary>
    [JsonPropertyName("from")]
    public double? From { get; set; }

    /// <summary>
    /// Upper bound of the range (exclusive).
    /// </summary>
    [JsonPropertyName("to")]
    public double? To { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record MetadataPrecondition
{
    /// <summary>
    /// The key that must be present in the metadata for a precondition to be met
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// If set, the value must match the metadata value for the given key
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    /// <summary>
    /// Operator to apply to this precondition
    /// </summary>
    [JsonPropertyName("operator")]
    public PreconditionOperator? Operator { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

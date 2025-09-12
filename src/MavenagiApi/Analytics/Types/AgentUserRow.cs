using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record AgentUserRow
{
    /// <summary>
    /// A unique identifier for each row, consisting of field names mapped to their respective values.
    /// This includes time groupings and any specified field groupings.
    /// </summary>
    [JsonPropertyName("identifier")]
    public Dictionary<AgentUserField, object?> Identifier { get; set; } =
        new Dictionary<AgentUserField, object?>();

    /// <summary>
    /// The actual row data, where keys represent column headers and values contain the respective metric results.
    /// </summary>
    [JsonPropertyName("data")]
    public object Data { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

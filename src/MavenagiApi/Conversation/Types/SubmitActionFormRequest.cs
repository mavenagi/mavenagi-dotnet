using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record SubmitActionFormRequest
{
    [JsonPropertyName("actionFormId")]
    public required string ActionFormId { get; set; }

    /// <summary>
    /// Map of parameter IDs to values provided by the user. All required action fields must be provided.
    /// </summary>
    [JsonPropertyName("parameters")]
    public object Parameters { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// Transient data which the Maven platform will not persist. This data will only be forwarded to actions taken. For example, one may put in user tokens as transient data.
    /// </summary>
    [JsonPropertyName("transientData")]
    public Dictionary<string, string>? TransientData { get; set; }

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

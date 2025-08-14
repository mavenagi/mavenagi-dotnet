using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ResponseConfigPrecondition
{
    [JsonPropertyName("useMarkdown")]
    public bool? UseMarkdown { get; set; }

    [JsonPropertyName("useForms")]
    public bool? UseForms { get; set; }

    [JsonPropertyName("useImages")]
    public bool? UseImages { get; set; }

    [JsonPropertyName("isCopilot")]
    public bool? IsCopilot { get; set; }

    [JsonPropertyName("responseLength")]
    public ResponseLength? ResponseLength { get; set; }

    /// <summary>
    /// Operator to apply to this precondition
    /// </summary>
    [JsonPropertyName("operator")]
    public PreconditionOperator? Operator { get; set; }

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

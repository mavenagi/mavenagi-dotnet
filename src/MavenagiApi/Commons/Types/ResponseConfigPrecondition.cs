using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

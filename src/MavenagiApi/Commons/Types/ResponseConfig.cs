using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ResponseConfig
{
    /// <summary>
    /// List of capabilities supported by the caller. Defaults to `[MARKDOWN, FORMS, IMAGES]`.
    ///
    /// - `MARKDOWN`: Whether the response should include markdown formatting. If not provided, the response will be plain text. Not respected while streaming.
    /// - `FORMS`: Whether the response should include forms. If provided, the caller needs to render action forms when returned from the ask API and allow submission of the forms with the submitActionForm API. If not provided, then actions which require user interaction will not be considered by the LLM. Removing this capability is recommended for surfaces which can not display UI (e.g. SMS, voice).
    /// - `IMAGES`: Whether the response should include images. Not yet supported.
    /// - `CHARTS_HIGHCHARTS_TS`: Whether the response should include a Highcharts typescript chart if applicable.
    /// - `ASYNC`: Whether the app that created this conversation supports asynchronous message delivery. If provided, messages may be sent to the app via the `handleMessage` function.
    /// </summary>
    [JsonPropertyName("capabilities")]
    public IEnumerable<Capability> Capabilities { get; set; } = new List<Capability>();

    /// <summary>
    /// Whether the response is for an human agent (true) or an end user (false). Defaults to false.
    /// </summary>
    [JsonPropertyName("isCopilot")]
    public required bool IsCopilot { get; set; }

    /// <summary>
    /// The desired response length. Defaults to ResponseLength.MEDIUM.
    /// </summary>
    [JsonPropertyName("responseLength")]
    public required ResponseLength ResponseLength { get; set; }

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

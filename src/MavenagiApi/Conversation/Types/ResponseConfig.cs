using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record ResponseConfig
{
    /// <summary>
    /// List of capabilities supported by the caller. Defaults to [MARKDOWN, FORMS, IMAGES].
    ///
    /// MARKDOWN: Whether the response should include markdown formatting. If not provided, the response will be plain text. Not respected while streaming.
    ///
    /// FORMS: Whether the response should include forms. If provided, the caller needs to render action forms when returned from the ask API and allow submission of the forms with the submitActionForm API. If not provided, then actions which require user interaction will not be considered by the LLM. Removing this capability is recommended for surfaces which can not display UI (e.g. SMS, voice).
    ///
    /// IMAGES: Whether the response should include images. Not yet supported.
    ///
    /// CHARTS_HIGHCHARTS_TS: Whether the response should include a Highcharts typescript chart if applicable.
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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

/// <summary>
/// This response should be rendered as a single button that starts an OAuth authorization flow.
/// </summary>
[Serializable]
public record BotOAuthButtonResponse
{
    /// <summary>
    /// Text that should be displayed to the user on the button.
    /// </summary>
    [JsonPropertyName("buttonName")]
    public required string ButtonName { get; set; }

    /// <summary>
    /// The OAuth authorization URL to open when the button is clicked.
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; set; }

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

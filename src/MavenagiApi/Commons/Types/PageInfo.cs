using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record PageInfo
{
    [JsonPropertyName("pageName")]
    public required string PageName { get; set; }

    [JsonPropertyName("pageUrl")]
    public string? PageUrl { get; set; }

    [JsonPropertyName("pageTitle")]
    public string? PageTitle { get; set; }

    [JsonPropertyName("linkUrl")]
    public string? LinkUrl { get; set; }

    [JsonPropertyName("elementId")]
    public string? ElementId { get; set; }

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

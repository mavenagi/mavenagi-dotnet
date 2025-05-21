using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record SurveyInfo
{
    [JsonPropertyName("surveyQuestion")]
    public required string SurveyQuestion { get; set; }

    [JsonPropertyName("surveyAnswer")]
    public string? SurveyAnswer { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

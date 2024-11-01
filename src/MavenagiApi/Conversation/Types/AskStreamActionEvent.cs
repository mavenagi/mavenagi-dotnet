using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record AskStreamActionEvent
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("formLabel")]
    public required string FormLabel { get; set; }

    [JsonPropertyName("fields")]
    public IEnumerable<ActionFormField> Fields { get; set; } = new List<ActionFormField>();

    [JsonPropertyName("submitLabel")]
    public required string SubmitLabel { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

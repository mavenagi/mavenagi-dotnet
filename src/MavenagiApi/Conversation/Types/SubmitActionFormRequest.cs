using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record SubmitActionFormRequest
{
    [JsonPropertyName("actionFormId")]
    public required string ActionFormId { get; set; }

    /// <summary>
    /// Map of parameter IDs to values provided by the user. All required action fields must be provided.
    /// </summary>
    [JsonPropertyName("parameters")]
    public object Parameters { get; set; } = new Dictionary<string, object?>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

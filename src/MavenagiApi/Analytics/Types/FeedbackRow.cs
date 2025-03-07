using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record FeedbackRow
{
    /// <summary>
    /// A unique identifier for each row, consisting of field names mapped to their respective values.
    /// This includes time groupings and any specified field groupings.
    /// </summary>
    [JsonPropertyName("identifier")]
    public Dictionary<FeedbackField, object?> Identifier { get; set; } =
        new Dictionary<FeedbackField, object?>();

    /// <summary>
    /// The actual row data, where keys represent column headers and values contain the respective metric results.
    /// </summary>
    [JsonPropertyName("data")]
    public object Data { get; set; } = new Dictionary<string, object?>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

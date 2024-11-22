using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record BotActionResponse
{
    [JsonPropertyName("actionId")]
    public required EntityId ActionId { get; set; }

    [JsonPropertyName("actionParameters")]
    public object ActionParameters { get; set; } = new Dictionary<string, object?>();

    [JsonPropertyName("actionResponse")]
    public required string ActionResponse { get; set; }

    /// <summary>
    /// True if the bot automatically took this action. False if the user manually submitted the actionForm.
    /// </summary>
    [JsonPropertyName("autoAction")]
    public required bool AutoAction { get; set; }

    [JsonPropertyName("actionError")]
    public string? ActionError { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

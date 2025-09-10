using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ConversationGetRequest
{
    /// <summary>
    /// The App ID of the conversation to get. If not provided the ID of the calling app will be used.
    /// </summary>
    [JsonIgnore]
    public string? AppId { get; set; }

    /// <summary>
    /// The language to translate the conversation analysis into
    /// </summary>
    [JsonIgnore]
    public string? TranslationLanguage { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

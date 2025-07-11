using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record Attachment : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The mime-type of the attachment. Supported types are:
    /// - image/jpeg
    /// - image/jpg
    /// - image/png
    /// - image/gif
    /// - image/webp
    /// - application/pdf
    /// - audio/aac
    /// - audio/mpeg
    /// - audio/mp4
    /// - video/mp4
    ///
    /// Image attachments will be sent to the LLM as additional data.
    /// Non-image attachments can be stored and downloaded from the API but will not be sent to the LLM.
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// The attachment data, up to 5MB.
    /// </summary>
    [JsonPropertyName("content")]
    public required string Content { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

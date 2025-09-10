using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record CreateOrganizationRequest
{
    /// <summary>
    /// The name of the organization.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The default language for the organization in ISO 639-1 code format.
    /// </summary>
    [JsonPropertyName("defaultLanguage")]
    public required string DefaultLanguage { get; set; }

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

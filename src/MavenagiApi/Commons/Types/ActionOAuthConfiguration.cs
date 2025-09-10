using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ActionOAuthConfiguration
{
    [JsonPropertyName("authorizationUrl")]
    public required string AuthorizationUrl { get; set; }

    [JsonPropertyName("tokenUrl")]
    public required string TokenUrl { get; set; }

    [JsonPropertyName("clientId")]
    public required string ClientId { get; set; }

    [JsonPropertyName("clientSecret")]
    public required string ClientSecret { get; set; }

    [JsonPropertyName("scopes")]
    public IEnumerable<string> Scopes { get; set; } = new List<string>();

    [JsonPropertyName("extraAuthParams")]
    public Dictionary<string, string>? ExtraAuthParams { get; set; }

    [JsonPropertyName("extraTokenParams")]
    public Dictionary<string, string>? ExtraTokenParams { get; set; }

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

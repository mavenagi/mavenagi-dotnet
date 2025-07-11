using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record AppUser : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Used to determine whether two users from different apps are the same
    /// </summary>
    [JsonPropertyName("identifiers")]
    public HashSet<AppUserIdentifier> Identifiers { get; set; } = new HashSet<AppUserIdentifier>();

    [JsonPropertyName("data")]
    public Dictionary<string, UserData> Data { get; set; } = new Dictionary<string, UserData>();

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

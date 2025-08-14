using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record ConversationsSearchRequest
{
    [JsonPropertyName("sort")]
    public ConversationField? Sort { get; set; }

    [JsonPropertyName("filter")]
    public ConversationFilter? Filter { get; set; }

    /// <summary>
    /// Page number to return, defaults to 0
    /// </summary>
    [JsonPropertyName("page")]
    public int? Page { get; set; }

    /// <summary>
    /// The size of the page to return, defaults to 20
    /// </summary>
    [JsonPropertyName("size")]
    public int? Size { get; set; }

    /// <summary>
    /// Whether to sort descending, defaults to true
    /// </summary>
    [JsonPropertyName("sortDesc")]
    public bool? SortDesc { get; set; }

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

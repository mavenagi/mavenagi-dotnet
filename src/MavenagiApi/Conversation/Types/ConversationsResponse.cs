using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record ConversationsResponse
{
    /// <summary>
    /// The conversations that match the search criteria
    /// </summary>
    [JsonPropertyName("conversations")]
    public IEnumerable<ConversationPreview> Conversations { get; set; } =
        new List<ConversationPreview>();

    /// <summary>
    /// The page being returned, starts at 0
    /// </summary>
    [JsonPropertyName("number")]
    public required int Number { get; set; }

    /// <summary>
    /// The number of elements in this page
    /// </summary>
    [JsonPropertyName("size")]
    public required int Size { get; set; }

    /// <summary>
    /// The total number of elements in the collection
    /// </summary>
    [JsonPropertyName("totalElements")]
    public required long TotalElements { get; set; }

    /// <summary>
    /// The total number of pages in the collection
    /// </summary>
    [JsonPropertyName("totalPages")]
    public required int TotalPages { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

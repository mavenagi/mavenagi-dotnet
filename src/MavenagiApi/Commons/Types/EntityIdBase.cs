using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

public record EntityIdBase
{
    /// <summary>
    /// Externally supplied ID to uniquely identify this object. Is globally unique when combined with all other entityId fields (type, appId, organizationId, agentId)
    /// </summary>
    [JsonPropertyName("referenceId")]
    public required string ReferenceId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

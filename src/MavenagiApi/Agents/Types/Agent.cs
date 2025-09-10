using System.Text.Json;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[Serializable]
public record Agent
{
    /// <summary>
    /// ID that uniquely identifies this action
    /// </summary>
    [JsonPropertyName("agentId")]
    public required EntityId AgentId { get; set; }

    /// <summary>
    /// The name of the agent.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// When the agent was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The environment of the agent. Default is `DEMO`.
    /// </summary>
    [JsonPropertyName("environment")]
    public required AgentEnvironment Environment { get; set; }

    /// <summary>
    /// The agent's default timezone. This is used when a timezone is not set on a conversation.
    /// </summary>
    [JsonPropertyName("defaultTimezone")]
    public required string DefaultTimezone { get; set; }

    /// <summary>
    /// The PII categories that are enabled for the agent.
    /// PII will be automatically redacted from all conversation message text.
    /// Attachments and form submissions are not affected.
    ///
    /// Defaults to `AbaRoutingNumber`, `CreditCardNumber`, `IpAddress`, `PhoneNumber`, `SwiftCode`,
    /// `UsBankAccountNumber`, `UsDriversLicenseNumber`, `UsIndividualTaxpayerIdentification`,
    /// `UsUkPassportNumber`, `UsSocialSecurityNumber`.
    /// </summary>
    [JsonPropertyName("enabledPiiCategories")]
    public HashSet<PiiCategory> EnabledPiiCategories { get; set; } = new HashSet<PiiCategory>();

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

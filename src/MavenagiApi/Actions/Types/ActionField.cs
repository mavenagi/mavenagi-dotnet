using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<ActionField>))]
public enum ActionField
{
    [EnumMember(Value = "AppId")]
    AppId,

    [EnumMember(Value = "Name")]
    Name,

    [EnumMember(Value = "LlmInclusionStatus")]
    LlmInclusionStatus,

    [EnumMember(Value = "UserInteractionRequired")]
    UserInteractionRequired,

    [EnumMember(Value = "CreatedAt")]
    CreatedAt,
}

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<QualityReason>))]
public enum QualityReason
{
    [EnumMember(Value = "MISSING_KNOWLEDGE")]
    MissingKnowledge,

    [EnumMember(Value = "MISSING_USER_INFORMATION")]
    MissingUserInformation,

    [EnumMember(Value = "MISSING_ACTION")]
    MissingAction,

    [EnumMember(Value = "NEEDS_USER_CLARIFICATION")]
    NeedsUserClarification,

    [EnumMember(Value = "UNSUPPORTED_FORMAT")]
    UnsupportedFormat,

    [EnumMember(Value = "INTERRUPTED")]
    Interrupted,

    [EnumMember(Value = "UNSUPPORTED_USER_BEHAVIOR")]
    UnsupportedUserBehavior,

    [EnumMember(Value = "UNKNOWN")]
    Unknown,
}

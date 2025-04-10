using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<Quality>))]
public enum Quality
{
    [EnumMember(Value = "GOOD")]
    Good,

    [EnumMember(Value = "NEEDS_IMPROVEMENT")]
    NeedsImprovement,

    [EnumMember(Value = "UNKNOWN")]
    Unknown,
}

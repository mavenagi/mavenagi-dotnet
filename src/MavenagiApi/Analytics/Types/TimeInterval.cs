using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<TimeInterval>))]
public enum TimeInterval
{
    [EnumMember(Value = "HOUR")]
    Hour,

    [EnumMember(Value = "DAY")]
    Day,

    [EnumMember(Value = "WEEK")]
    Week,

    [EnumMember(Value = "MONTH")]
    Month,

    [EnumMember(Value = "YEAR")]
    Year,
}

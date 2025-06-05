using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<FeedbackField>))]
public enum FeedbackField
{
    [EnumMember(Value = "Type")]
    Type,

    [EnumMember(Value = "CreatedBy")]
    CreatedBy,

    [EnumMember(Value = "CreatedAt")]
    CreatedAt,
}

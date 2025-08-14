using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<PreconditionGroupOperator>))]
public enum PreconditionGroupOperator
{
    [EnumMember(Value = "AND")]
    And,

    [EnumMember(Value = "OR")]
    Or,
}

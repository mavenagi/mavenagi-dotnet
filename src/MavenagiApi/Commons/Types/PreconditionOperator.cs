using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<PreconditionOperator>))]
public enum PreconditionOperator
{
    [EnumMember(Value = "NOT")]
    Not,
}

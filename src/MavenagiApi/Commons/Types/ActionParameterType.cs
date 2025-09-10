using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<ActionParameterType>))]
public enum ActionParameterType
{
    [EnumMember(Value = "STRING")]
    String,

    [EnumMember(Value = "BOOLEAN")]
    Boolean,

    [EnumMember(Value = "NUMBER")]
    Number,

    [EnumMember(Value = "SCHEMA")]
    Schema,

    [EnumMember(Value = "FILE")]
    File,

    [EnumMember(Value = "OAUTH")]
    Oauth,
}

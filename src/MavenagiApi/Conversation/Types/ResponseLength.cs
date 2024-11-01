using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<ResponseLength>))]
public enum ResponseLength
{
    [EnumMember(Value = "SHORT")]
    Short,

    [EnumMember(Value = "MEDIUM")]
    Medium,

    [EnumMember(Value = "LONG")]
    Long,
}

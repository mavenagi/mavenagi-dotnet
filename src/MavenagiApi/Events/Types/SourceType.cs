using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<SourceType>))]
public enum SourceType
{
    [EnumMember(Value = "WEB")]
    Web,

    [EnumMember(Value = "API")]
    Api,

    [EnumMember(Value = "SYSTEM")]
    System,
}

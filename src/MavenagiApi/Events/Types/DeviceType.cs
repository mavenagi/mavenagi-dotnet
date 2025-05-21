using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<DeviceType>))]
public enum DeviceType
{
    [EnumMember(Value = "DESKTOP")]
    Desktop,

    [EnumMember(Value = "MOBILE")]
    Mobile,

    [EnumMember(Value = "TABLET")]
    Tablet,

    [EnumMember(Value = "OTHER")]
    Other,
}

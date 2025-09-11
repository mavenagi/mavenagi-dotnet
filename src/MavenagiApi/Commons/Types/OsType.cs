using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<OsType>))]
public enum OsType
{
    [EnumMember(Value = "WINDOWS")]
    Windows,

    [EnumMember(Value = "MACOS")]
    Macos,

    [EnumMember(Value = "LINUX")]
    Linux,

    [EnumMember(Value = "ANDROID")]
    Android,

    [EnumMember(Value = "IOS")]
    Ios,

    [EnumMember(Value = "OTHER")]
    Other,
}

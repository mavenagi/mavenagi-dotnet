using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<BrowserType>))]
public enum BrowserType
{
    [EnumMember(Value = "CHROME")]
    Chrome,

    [EnumMember(Value = "FIREFOX")]
    Firefox,

    [EnumMember(Value = "SAFARI")]
    Safari,

    [EnumMember(Value = "OPERA")]
    Opera,

    [EnumMember(Value = "EDGE")]
    Edge,

    [EnumMember(Value = "OTHER")]
    Other,
}

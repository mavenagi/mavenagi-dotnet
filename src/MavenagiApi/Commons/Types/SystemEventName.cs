using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<SystemEventName>))]
public enum SystemEventName
{
    [EnumMember(Value = "APP_INSTALLED")]
    AppInstalled,

    [EnumMember(Value = "APP_UNINSTALLED")]
    AppUninstalled,

    [EnumMember(Value = "APP_UPDATED")]
    AppUpdated,
}

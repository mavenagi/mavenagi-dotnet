using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<AppUserIdentifyingPropertyType>))]
public enum AppUserIdentifyingPropertyType
{
    [EnumMember(Value = "EMAIL")]
    Email,

    [EnumMember(Value = "PHONE_NUMBER")]
    PhoneNumber,
}

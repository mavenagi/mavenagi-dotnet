using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<EventType>))]
public enum EventType
{
    [EnumMember(Value = "USER")]
    User,

    [EnumMember(Value = "SYSTEM")]
    System,
}

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<EventField>))]
public enum EventField
{
    [EnumMember(Value = "CREATED_AT")]
    CreatedAt,
}

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<DeliveryStatus>))]
public enum DeliveryStatus
{
    [EnumMember(Value = "DELIVERED")]
    Delivered,

    [EnumMember(Value = "FAILED")]
    Failed,

    [EnumMember(Value = "QUEUED")]
    Queued,
}

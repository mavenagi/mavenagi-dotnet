using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<AttachmentStatus>))]
public enum AttachmentStatus
{
    [EnumMember(Value = "PENDING")]
    Pending,

    [EnumMember(Value = "PROCESSING")]
    Processing,

    [EnumMember(Value = "ACCEPTED")]
    Accepted,

    [EnumMember(Value = "REJECTED")]
    Rejected,
}

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<InboxItemSeverity>))]
public enum InboxItemSeverity
{
    [EnumMember(Value = "LOW")]
    Low,

    [EnumMember(Value = "MEDIUM")]
    Medium,

    [EnumMember(Value = "HIGH")]
    High,
}

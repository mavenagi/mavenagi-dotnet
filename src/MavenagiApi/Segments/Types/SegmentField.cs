using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<SegmentField>))]
public enum SegmentField
{
    [EnumMember(Value = "CreatedAt")]
    CreatedAt,

    [EnumMember(Value = "Name")]
    Name,
}

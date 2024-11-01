using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<VisibilityType>))]
public enum VisibilityType
{
    [EnumMember(Value = "VISIBLE")]
    Visible,

    [EnumMember(Value = "PARTIALLY_VISIBLE")]
    PartiallyVisible,

    [EnumMember(Value = "HIDDEN")]
    Hidden,
}

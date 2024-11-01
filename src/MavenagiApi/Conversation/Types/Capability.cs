using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<Capability>))]
public enum Capability
{
    [EnumMember(Value = "MARKDOWN")]
    Markdown,

    [EnumMember(Value = "FORMS")]
    Forms,

    [EnumMember(Value = "IMAGES")]
    Images,
}
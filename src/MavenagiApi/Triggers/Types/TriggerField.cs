using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<TriggerField>))]
public enum TriggerField
{
    [EnumMember(Value = "CreatedAt")]
    CreatedAt,

    [EnumMember(Value = "Enabled")]
    Enabled,
}

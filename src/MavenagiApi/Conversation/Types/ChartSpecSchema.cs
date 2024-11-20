using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<ChartSpecSchema>))]
public enum ChartSpecSchema
{
    [EnumMember(Value = "HIGHCHARTS_TS")]
    HighchartsTs,
}

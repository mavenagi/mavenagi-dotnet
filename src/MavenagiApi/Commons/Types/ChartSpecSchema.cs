using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<ChartSpecSchema>))]
public enum ChartSpecSchema
{
    [EnumMember(Value = "HIGHCHARTS_TS")]
    HighchartsTs,
}

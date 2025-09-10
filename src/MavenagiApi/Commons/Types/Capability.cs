using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

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

    [EnumMember(Value = "CHARTS_HIGHCHARTS_TS")]
    ChartsHighchartsTs,

    [EnumMember(Value = "ASYNC")]
    Async,

    [EnumMember(Value = "OAUTH_BUTTONS")]
    OauthButtons,
}

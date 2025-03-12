using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<Sentiment>))]
public enum Sentiment
{
    [EnumMember(Value = "POSITIVE")]
    Positive,

    [EnumMember(Value = "NEGATIVE")]
    Negative,

    [EnumMember(Value = "NEUTRAL")]
    Neutral,

    [EnumMember(Value = "MIXED")]
    Mixed,

    [EnumMember(Value = "UNKNOWN")]
    Unknown,
}

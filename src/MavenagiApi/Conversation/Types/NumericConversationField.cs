using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<NumericConversationField>))]
public enum NumericConversationField
{
    [EnumMember(Value = "ThumbsUpCount")]
    ThumbsUpCount,

    [EnumMember(Value = "ThumbsDownCount")]
    ThumbsDownCount,

    [EnumMember(Value = "UserMessageCount")]
    UserMessageCount,

    [EnumMember(Value = "HandleTime")]
    HandleTime,

    [EnumMember(Value = "FirstResponseTime")]
    FirstResponseTime,
}

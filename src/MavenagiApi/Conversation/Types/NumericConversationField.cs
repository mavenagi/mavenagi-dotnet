using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<NumericConversationField>))]
public enum NumericConversationField
{
    [EnumMember(Value = "ThumbsUpCount")]
    ThumbsUpCount,

    [EnumMember(Value = "ThumbsDownCount")]
    ThumbsDownCount,

    [EnumMember(Value = "InsertCount")]
    InsertCount,

    [EnumMember(Value = "UserMessageCount")]
    UserMessageCount,

    [EnumMember(Value = "HandleTime")]
    HandleTime,

    [EnumMember(Value = "FirstResponseTime")]
    FirstResponseTime,
}

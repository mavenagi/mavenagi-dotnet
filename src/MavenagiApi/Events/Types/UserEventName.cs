using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<UserEventName>))]
public enum UserEventName
{
    [EnumMember(Value = "BUTTON_CLICKED")]
    ButtonClicked,

    [EnumMember(Value = "LINK_CLICKED")]
    LinkClicked,

    [EnumMember(Value = "CHAT_OPENED")]
    ChatOpened,

    [EnumMember(Value = "CHAT_CLOSED")]
    ChatClosed,
}

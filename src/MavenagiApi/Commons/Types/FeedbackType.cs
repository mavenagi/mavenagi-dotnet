using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<FeedbackType>))]
public enum FeedbackType
{
    [EnumMember(Value = "THUMBS_UP")]
    ThumbsUp,

    [EnumMember(Value = "THUMBS_DOWN")]
    ThumbsDown,

    [EnumMember(Value = "INSERT")]
    Insert,

    [EnumMember(Value = "HANDOFF")]
    Handoff,
}

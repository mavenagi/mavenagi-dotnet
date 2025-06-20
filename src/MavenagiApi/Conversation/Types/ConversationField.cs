using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<ConversationField>))]
public enum ConversationField
{
    [EnumMember(Value = "Category")]
    Category,

    [EnumMember(Value = "FirstResponseTime")]
    FirstResponseTime,

    [EnumMember(Value = "HandleTime")]
    HandleTime,

    [EnumMember(Value = "HumanAgents")]
    HumanAgents,

    [EnumMember(Value = "HumanAgentsWithInserts")]
    HumanAgentsWithInserts,

    [EnumMember(Value = "App")]
    App,

    [EnumMember(Value = "Sentiment")]
    Sentiment,

    [EnumMember(Value = "QualityReason")]
    QualityReason,

    [EnumMember(Value = "ResolutionStatus")]
    ResolutionStatus,

    [EnumMember(Value = "Quality")]
    Quality,

    [EnumMember(Value = "Users")]
    Users,

    [EnumMember(Value = "ResponseLength")]
    ResponseLength,

    [EnumMember(Value = "ThumbsUpCount")]
    ThumbsUpCount,

    [EnumMember(Value = "ThumbsDownCount")]
    ThumbsDownCount,

    [EnumMember(Value = "InsertCount")]
    InsertCount,

    [EnumMember(Value = "Tags")]
    Tags,

    [EnumMember(Value = "UserMessageCount")]
    UserMessageCount,

    [EnumMember(Value = "Languages")]
    Languages,

    [EnumMember(Value = "Actions")]
    Actions,

    [EnumMember(Value = "IncompleteActions")]
    IncompleteActions,

    [EnumMember(Value = "Sources")]
    Sources,

    [EnumMember(Value = "CreatedAt")]
    CreatedAt,
}

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<InboxItemType>))]
public enum InboxItemType
{
    [EnumMember(Value = "DUPLICATE_DOCUMENT")]
    DuplicateDocument,

    [EnumMember(Value = "DUPLICATE_KNOWLEDGE_BASE")]
    DuplicateKnowledgeBase,

    [EnumMember(Value = "MISSING_KNOWLEDGE")]
    MissingKnowledge,

    [EnumMember(Value = "LOW_QUALITY_KNOWLEDGE_BASE")]
    LowQualityKnowledgeBase,
}

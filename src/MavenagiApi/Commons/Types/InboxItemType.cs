using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<InboxItemType>))]
public enum InboxItemType
{
    [EnumMember(Value = "DUPLICATE_DOCUMENT")]
    DuplicateDocument,

    [EnumMember(Value = "MISSING_KNOWLEDGE")]
    MissingKnowledge,
}

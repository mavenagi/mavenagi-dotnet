using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<InboxItemFixType>))]
public enum InboxItemFixType
{
    [EnumMember(Value = "REMOVE_DOCUMENT")]
    RemoveDocument,

    [EnumMember(Value = "ADD_DOCUMENT")]
    AddDocument,
}

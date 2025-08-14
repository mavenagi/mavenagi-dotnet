using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<BotConversationMessageType>))]
public enum BotConversationMessageType
{
    [EnumMember(Value = "BOT_RESPONSE")]
    BotResponse,

    [EnumMember(Value = "BOT_SUGGESTION")]
    BotSuggestion,
}

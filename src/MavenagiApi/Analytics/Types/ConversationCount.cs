using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record ConversationCount
{
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

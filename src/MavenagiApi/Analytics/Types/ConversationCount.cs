using MavenagiApi.Core;

namespace MavenagiApi;

public record ConversationCount
{
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

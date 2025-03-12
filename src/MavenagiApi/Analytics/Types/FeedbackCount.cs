using MavenagiApi.Core;

namespace MavenagiApi;

public record FeedbackCount
{
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

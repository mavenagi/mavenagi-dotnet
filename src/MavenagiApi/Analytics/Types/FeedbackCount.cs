using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record FeedbackCount
{
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public record Count
{
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

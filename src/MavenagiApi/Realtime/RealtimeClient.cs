using MavenagiApi.Core;

namespace MavenagiApi;

public partial class RealtimeClient
{
    private RawClient _client;

    internal RealtimeClient(RawClient client)
    {
        _client = client;
    }
}

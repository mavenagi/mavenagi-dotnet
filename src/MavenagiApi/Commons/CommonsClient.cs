using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public partial class CommonsClient
{
    private RawClient _client;

    internal CommonsClient(RawClient client)
    {
        _client = client;
    }
}

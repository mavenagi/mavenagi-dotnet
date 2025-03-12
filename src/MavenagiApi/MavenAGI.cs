using MavenagiApi.Core;

namespace MavenagiApi;

public partial class MavenAGI
{
    private readonly RawClient _client;

    public MavenAGI(
        string organizationId,
        string agentId,
        string? appId = null,
        string? appSecret = null,
        ClientOptions? clientOptions = null
    )
    {
        appId ??= GetFromEnvironmentOrThrow(
            "MAVENAGI_APP_ID",
            "Please pass in appId or set the environment variable MAVENAGI_APP_ID."
        );
        appSecret ??= GetFromEnvironmentOrThrow(
            "MAVENAGI_APP_SECRET",
            "Please pass in appSecret or set the environment variable MAVENAGI_APP_SECRET."
        );
        var defaultHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-Organization-Id", organizationId },
                { "X-Agent-Id", agentId },
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "MavenagiApi" },
                { "X-Fern-SDK-Version", Version.Current },
                { "User-Agent", "mavenagi/1.0.8" },
            }
        );
        clientOptions ??= new ClientOptions();
        foreach (var header in defaultHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        _client = new RawClient(clientOptions);
        Actions = new ActionsClient(_client);
        Analytics = new AnalyticsClient(_client);
        AppSettings = new AppSettingsClient(_client);
        Commons = new CommonsClient(_client);
        Conversation = new ConversationClient(_client);
        Inbox = new InboxClient(_client);
        Knowledge = new KnowledgeClient(_client);
        Translations = new TranslationsClient(_client);
        Triggers = new TriggersClient(_client);
        Users = new UsersClient(_client);
    }

    public ActionsClient Actions { get; init; }

    public AnalyticsClient Analytics { get; init; }

    public AppSettingsClient AppSettings { get; init; }

    public CommonsClient Commons { get; init; }

    public ConversationClient Conversation { get; init; }

    public InboxClient Inbox { get; init; }

    public KnowledgeClient Knowledge { get; init; }

    public TranslationsClient Translations { get; init; }

    public TriggersClient Triggers { get; init; }

    public UsersClient Users { get; init; }

    private static string GetFromEnvironmentOrThrow(string env, string message)
    {
        return Environment.GetEnvironmentVariable(env) ?? throw new Exception(message);
    }
}

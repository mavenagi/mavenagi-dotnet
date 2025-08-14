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
                { "User-Agent", "mavenagi/1.2.0" },
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
        Agents = new AgentsClient(_client);
        Analytics = new AnalyticsClient(_client);
        AppSettings = new AppSettingsClient(_client);
        Assets = new AssetsClient(_client);
        Commons = new CommonsClient(_client);
        Conversation = new ConversationClient(_client);
        Events = new EventsClient(_client);
        Inbox = new InboxClient(_client);
        Knowledge = new KnowledgeClient(_client);
        Organizations = new OrganizationsClient(_client);
        Segments = new SegmentsClient(_client);
        Translations = new TranslationsClient(_client);
        Triggers = new TriggersClient(_client);
        Users = new UsersClient(_client);
    }

    public ActionsClient Actions { get; }

    public AgentsClient Agents { get; }

    public AnalyticsClient Analytics { get; }

    public AppSettingsClient AppSettings { get; }

    public AssetsClient Assets { get; }

    public CommonsClient Commons { get; }

    public ConversationClient Conversation { get; }

    public EventsClient Events { get; }

    public InboxClient Inbox { get; }

    public KnowledgeClient Knowledge { get; }

    public OrganizationsClient Organizations { get; }

    public SegmentsClient Segments { get; }

    public TranslationsClient Translations { get; }

    public TriggersClient Triggers { get; }

    public UsersClient Users { get; }

    private static string GetFromEnvironmentOrThrow(string env, string message)
    {
        return Environment.GetEnvironmentVariable(env) ?? throw new Exception(message);
    }
}

using System.Net.Http;
using System.Text.Json;
using System.Threading;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public partial class AnalyticsClient
{
    private RawClient _client;

    internal AnalyticsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieves structured conversation data formatted as a table, allowing users to group, filter, and define specific metrics to display as columns.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Analytics.GetConversationTableAsync(
    ///     new ConversationTableRequest
    ///     {
    ///         ConversationFilter = new ConversationFilter
    ///         {
    ///             Languages = new List&lt;string&gt;() { "en", "es" },
    ///         },
    ///         TimeGrouping = TimeInterval.Day,
    ///         FieldGroupings = new List&lt;GroupBy&gt;() { new GroupBy { Field = ConversationField.Category } },
    ///         ColumnDefinitions = new List&lt;ColumnDefinition&gt;()
    ///         {
    ///             new ColumnDefinition { Header = "count", Metric = new Count() },
    ///             new ColumnDefinition
    ///             {
    ///                 Header = "avg_first_response_time",
    ///                 Metric = new Average { TargetField = ConversationField.FirstResponseTime },
    ///             },
    ///             new ColumnDefinition
    ///             {
    ///                 Header = "percentile_handle_time",
    ///                 Metric = new Percentile
    ///                 {
    ///                     TargetField = ConversationField.HandleTime,
    ///                     Percentiles = new List&lt;double&gt;() { 25, 75 },
    ///                 },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<ConversationTableResponse> GetConversationTableAsync(
        ConversationTableRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = "/v1/tables/conversations",
                Body = request,
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<ConversationTableResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        try
        {
            switch (response.StatusCode)
            {
                case 404:
                    throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 400:
                    throw new BadRequestError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                case 500:
                    throw new ServerError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
            }
        }
        catch (JsonException)
        {
            // unable to map error response, throwing generic error
        }
        throw new MavenAGIApiException(
            $"Error with status code {response.StatusCode}",
            response.StatusCode,
            responseBody
        );
    }
}

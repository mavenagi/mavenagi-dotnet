using System.Net.Http;
using System.Text.Json;
using System.Threading;
using MavenagiApi.Core;

namespace MavenagiApi;

public partial class OrganizationsClient
{
    private RawClient _client;

    internal OrganizationsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieves structured conversation data across all organizations, formatted as a table,
    /// allowing users to group, filter, and define specific metrics to display as columns.
    ///
    /// &lt;Tip&gt;
    /// This endpoint requires additional permissions. Contact support to request access.
    /// &lt;/Tip&gt;
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Organizations.GetConversationTableAsync(
    ///     new ConversationTableRequest
    ///     {
    ///         ConversationFilter = new ConversationFilter
    ///         {
    ///             Languages = new List&lt;string&gt;() { "en", "es" },
    ///         },
    ///         TimeGrouping = TimeInterval.Day,
    ///         FieldGroupings = new List&lt;ConversationGroupBy&gt;()
    ///         {
    ///             new ConversationGroupBy { Field = ConversationField.Category },
    ///         },
    ///         ColumnDefinitions = new List&lt;ConversationColumnDefinition&gt;()
    ///         {
    ///             new ConversationColumnDefinition { Header = "count", Metric = new ConversationCount() },
    ///             new ConversationColumnDefinition
    ///             {
    ///                 Header = "avg_first_response_time",
    ///                 Metric = new ConversationAverage
    ///                 {
    ///                     TargetField = NumericConversationField.FirstResponseTime,
    ///                 },
    ///             },
    ///             new ConversationColumnDefinition
    ///             {
    ///                 Header = "percentile_handle_time",
    ///                 Metric = new ConversationPercentile
    ///                 {
    ///                     TargetField = NumericConversationField.HandleTime,
    ///                     Percentile = 25,
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
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "/v1/organizations/tables/conversations",
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<ConversationTableResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorMessage>(responseBody)
                        );
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

    /// <summary>
    /// Fetches conversation data across all organizations, visualized in a chart format.
    /// Supported chart types include pie chart, date histogram, and stacked bar charts.
    ///
    /// &lt;Tip&gt;
    /// This endpoint requires additional permissions. Contact support to request access.
    /// &lt;/Tip&gt;
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Organizations.GetConversationChartAsync(
    ///     new ConversationPieChartRequest
    ///     {
    ///         ConversationFilter = new ConversationFilter
    ///         {
    ///             Languages = new List&lt;string&gt;() { "en", "es" },
    ///         },
    ///         GroupBy = new ConversationGroupBy { Field = ConversationField.Category },
    ///         Metric = new ConversationCount(),
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<object> GetConversationChartAsync(
        object request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "/v1/organizations/charts/conversations",
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<object>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new MavenAGIException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<ErrorMessage>(responseBody));
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorMessage>(responseBody)
                        );
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
}

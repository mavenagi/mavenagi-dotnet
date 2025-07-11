using System.Net.Http;
using System.Text.Json;
using System.Threading;
using MavenagiApi.Core;

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
    /// <example><code>
    /// await client.Analytics.GetConversationTableAsync(
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
    ///             new ConversationColumnDefinition
    ///             {
    ///                 Header = "count",
    ///                 Metric = new ConversationMetric(
    ///                     new ConversationMetric.Count(new ConversationCount())
    ///                 ),
    ///             },
    ///             new ConversationColumnDefinition
    ///             {
    ///                 Header = "avg_first_response_time",
    ///                 Metric = new ConversationMetric(
    ///                     new ConversationMetric.Average(
    ///                         new ConversationAverage
    ///                         {
    ///                             TargetField = NumericConversationField.FirstResponseTime,
    ///                         }
    ///                     )
    ///                 ),
    ///             },
    ///             new ConversationColumnDefinition
    ///             {
    ///                 Header = "percentile_handle_time",
    ///                 Metric = new ConversationMetric(
    ///                     new ConversationMetric.Percentile(
    ///                         new ConversationPercentile
    ///                         {
    ///                             TargetField = NumericConversationField.HandleTime,
    ///                             Percentile = 25,
    ///                         }
    ///                     )
    ///                 ),
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<ConversationTableResponse> GetConversationTableAsync(
        ConversationTableRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "/v1/tables/conversations",
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
    /// Fetches conversation data visualized in a chart format. Supported chart types include pie chart, date histogram, and stacked bar charts.
    /// </summary>
    /// <example><code>
    /// await client.Analytics.GetConversationChartAsync(
    ///     new ConversationChartRequest(
    ///         new ConversationChartRequest.PieChart(
    ///             new ConversationPieChartRequest
    ///             {
    ///                 ConversationFilter = new ConversationFilter
    ///                 {
    ///                     Languages = new List&lt;string&gt;() { "en", "es" },
    ///                 },
    ///                 GroupBy = new ConversationGroupBy { Field = ConversationField.Category },
    ///                 Metric = new ConversationMetric(
    ///                     new ConversationMetric.Count(new ConversationCount())
    ///                 ),
    ///             }
    ///         )
    ///     )
    /// );
    /// </code></example>
    public async Task<ChartResponse> GetConversationChartAsync(
        ConversationChartRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "/v1/charts/conversations",
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
                return JsonUtils.Deserialize<ChartResponse>(responseBody)!;
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
    /// Retrieves structured feedback data formatted as a table, allowing users to group, filter,  and define specific metrics to display as columns.
    /// </summary>
    /// <example><code>
    /// await client.Analytics.GetFeedbackTableAsync(
    ///     new FeedbackTableRequest
    ///     {
    ///         FeedbackFilter = new FeedbackFilter
    ///         {
    ///             Types = new List&lt;FeedbackType&gt;() { FeedbackType.ThumbsUp, FeedbackType.Insert },
    ///         },
    ///         FieldGroupings = new List&lt;FeedbackGroupBy&gt;()
    ///         {
    ///             new FeedbackGroupBy { Field = FeedbackField.CreatedBy },
    ///         },
    ///         ColumnDefinitions = new List&lt;FeedbackColumnDefinition&gt;()
    ///         {
    ///             new FeedbackColumnDefinition
    ///             {
    ///                 Header = "feedback_count",
    ///                 Metric = new FeedbackMetric(new FeedbackMetric.Count(new FeedbackCount())),
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<FeedbackTableResponse> GetFeedbackTableAsync(
        FeedbackTableRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "/v1/tables/feedback",
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
                return JsonUtils.Deserialize<FeedbackTableResponse>(responseBody)!;
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

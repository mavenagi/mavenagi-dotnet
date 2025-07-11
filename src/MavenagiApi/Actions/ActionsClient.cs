using System.Net.Http;
using System.Text.Json;
using System.Threading;
using global::System.Threading.Tasks;
using MavenagiApi.Core;

namespace MavenagiApi;

public partial class ActionsClient
{
    private RawClient _client;

    internal ActionsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Update an action or create it if it doesn't exist
    /// </summary>
    /// <example><code>
    /// await client.Actions.CreateOrUpdateAsync(
    ///     new ActionRequest
    ///     {
    ///         ActionId = new EntityIdBase { ReferenceId = "get-balance" },
    ///         Name = "Get the user's balance",
    ///         Description = "This action calls an API to get the user's current balance.",
    ///         UserInteractionRequired = false,
    ///         UserFormParameters = new List&lt;ActionParameter&gt;() { },
    ///         Precondition = new Precondition(
    ///             new Precondition.Group(
    ///                 new PreconditionGroup
    ///                 {
    ///                     Operator = PreconditionGroupOperator.And,
    ///                     Preconditions = new List&lt;Precondition&gt;()
    ///                     {
    ///                         new Precondition(
    ///                             new Precondition.User(new MetadataPrecondition { Key = "userKey" })
    ///                         ),
    ///                         new Precondition(
    ///                             new Precondition.User(new MetadataPrecondition { Key = "userKey2" })
    ///                         ),
    ///                     },
    ///                 }
    ///             )
    ///         ),
    ///         Language = "en",
    ///     }
    /// );
    /// </code></example>
    public async Task<ActionResponse> CreateOrUpdateAsync(
        ActionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = "/v1/actions",
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
                return JsonUtils.Deserialize<ActionResponse>(responseBody)!;
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
    /// Get an action by its supplied ID
    /// </summary>
    /// <example><code>
    /// await client.Actions.GetAsync("get-balance");
    /// </code></example>
    public async Task<ActionResponse> GetAsync(
        string actionReferenceId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "/v1/actions/{0}",
                        ValueConvert.ToPathParameterString(actionReferenceId)
                    ),
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
                return JsonUtils.Deserialize<ActionResponse>(responseBody)!;
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
    /// Delete an action
    /// </summary>
    /// <example><code>
    /// await client.Actions.DeleteAsync("get-balance");
    /// </code></example>
    public async global::System.Threading.Tasks.Task DeleteAsync(
        string actionReferenceId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "/v1/actions/{0}",
                        ValueConvert.ToPathParameterString(actionReferenceId)
                    ),
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
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

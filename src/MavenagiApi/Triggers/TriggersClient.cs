using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public partial class TriggersClient
{
    private RawClient _client;

    internal TriggersClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Update an event trigger or create it if it doesn't exist.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Triggers.CreateOrUpdateAsync(
    ///     new EventTriggerRequest
    ///     {
    ///         TriggerId = new EntityIdBase { ReferenceId = "store-in-snowflake" },
    ///         Description = "Stores conversation data in Snowflake",
    ///         Type = EventTriggerType.ConversationCreated,
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<EventTriggerResponse> CreateOrUpdateAsync(
        EventTriggerRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Put,
                Path = "/v1/triggers",
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
                return JsonUtils.Deserialize<EventTriggerResponse>(responseBody)!;
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

    /// <summary>
    /// Get an event trigger by its supplied ID
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Triggers.GetAsync("store-in-snowflake");
    /// </code>
    /// </example>
    public async Task<EventTriggerResponse> GetAsync(
        string triggerReferenceId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = $"/v1/triggers/{triggerReferenceId}",
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<EventTriggerResponse>(responseBody)!;
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

    /// <summary>
    /// Delete an event trigger
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Triggers.DeleteAsync("store-in-snowflake");
    /// </code>
    /// </example>
    public async Task DeleteAsync(
        string triggerReferenceId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Delete,
                Path = $"/v1/triggers/{triggerReferenceId}",
                Options = options,
            },
            cancellationToken
        );
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
        }
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
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

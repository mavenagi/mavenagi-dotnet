using System.Net.Http;
using System.Text.Json;
using System.Threading;
using MavenagiApi.Core;

namespace MavenagiApi;

public partial class AppSettingsClient
{
    private RawClient _client;

    internal AppSettingsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Get app settings set during installation
    /// </summary>
    /// <example>
    /// <code>
    /// await client.AppSettings.GetAsync();
    /// </code>
    /// </example>
    public async Task<object> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v1/app-settings",
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

    /// <summary>
    /// Update app settings. Performs a merge of the provided settings with the existing app settings.
    ///
    /// - If a new key is provided, it will be added to the app settings.
    /// - If an existing key is provided, it will be updated.
    /// - No keys will be removed.
    ///
    /// Note that if an array value is provided it will fully replace an existing value as arrays cannot be merged.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.AppSettings.UpdateAsync(
    ///     new Dictionary&lt;string, object&gt;()
    ///     {
    ///         {
    ///             "string",
    ///             new Dictionary&lt;object, object?&gt;() { { "key", "value" } }
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<object> UpdateAsync(
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
                    Method = HttpMethodExtensions.Patch,
                    Path = "v1/app-settings",
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

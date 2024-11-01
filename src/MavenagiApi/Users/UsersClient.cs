using System.Net.Http;
using System.Text.Json;
using System.Threading;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public partial class UsersClient
{
    private RawClient _client;

    internal UsersClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Update a user or create it if it doesn't exist.
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Users.CreateOrUpdateAsync(
    ///     new AppUserRequest
    ///     {
    ///         UserId = new EntityIdBase { ReferenceId = "user-0" },
    ///         Identifiers = new HashSet&lt;AppUserIdentifier&gt;()
    ///         {
    ///             new AppUserIdentifier
    ///             {
    ///                 Value = "joe@myapp.com",
    ///                 Type = AppUserIdentifyingPropertyType.Email,
    ///             },
    ///         },
    ///         Data = new Dictionary&lt;string, UserData&gt;()
    ///         {
    ///             {
    ///                 "name",
    ///                 new UserData { Value = "Joe", Visibility = VisibilityType.Visible }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code>
    /// </example>
    public async Task<AppUserResponse> CreateOrUpdateAsync(
        AppUserRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Put,
                Path = "/v1/users",
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
                return JsonUtils.Deserialize<AppUserResponse>(responseBody)!;
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
    /// Get a user by its supplied ID
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Users.GetAsync("user-0");
    /// </code>
    /// </example>
    public async Task<AppUserResponse> GetAsync(
        string userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Get,
                Path = $"/v1/users/{userId}",
                Options = options,
            },
            cancellationToken
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            try
            {
                return JsonUtils.Deserialize<AppUserResponse>(responseBody)!;
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

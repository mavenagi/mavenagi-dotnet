using System.Net.Http;
using System.Text.Json;
using System.Threading;
using MavenagiApi.Core;

#nullable enable

namespace MavenagiApi;

public partial class TranslationsClient
{
    private RawClient _client;

    internal TranslationsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Translate text from one language to another
    /// </summary>
    /// <example>
    /// <code>
    /// await client.Translations.TranslateAsync(
    ///     new TranslationRequest { Text = "Hello world", TargetLanguage = "es" }
    /// );
    /// </code>
    /// </example>
    public async Task<TranslationResponse> TranslateAsync(
        TranslationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                BaseUrl = _client.Options.BaseUrl,
                Method = HttpMethod.Post,
                Path = "/v1/translations/translate",
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
                return JsonUtils.Deserialize<TranslationResponse>(responseBody)!;
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
